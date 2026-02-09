create database HospitalDataBase;

use HospitalDataBase;

--Patient table

create table Patients(
   PatientId int identity(1,1) primary key,
   Name varchar(100) not null,
   DOB date not null,
   Phone varchar(15) unique,
   Email varchar(100) unique,
   Address varchar(255),
   BloodGroup varchar(5)
);

--Specialities table

create table Specialities(
    SpecialityId int Identity primary key,
    SpecialityName varchar(100) unique not null
 );


--Doctors table

create table Doctors(
   DoctorID int identity primary key,
   Name varchar,
   Contact varchar(15),
   ConsultationFee decimal(10,2),
   SpecialityId int,
   IsActive bit default 1,
   foreign key (SpecialityID) references Specialities(SpecialityId)
);


 --Appointments table

 create table Appointments(
    AppointmentID int identity primary key,
    PatientID int ,
    DoctorID int,
    AppointmentDate date,
    AppointmentTime time,
    Status varchar(20),
    foreign key(PatientId) references Patients(PatientID),
    foreign key(DoctorId) references Doctors(DoctorID)
 );
 
 --Visits table

create table Visits (
    VisitID INT IDENTITY PRIMARY KEY,
    AppointmentID INT,
    Diagnosis NVARCHAR(255),
    Notes NVARCHAR(255),
    VisitDate DATE,
    foreign key (AppointmentID) references Appointments(AppointmentID)
);

--Prescription table

CREATE TABLE Prescriptions (
    PrescriptionID INT IDENTITY PRIMARY KEY,
    VisitID INT,
    MedicineName NVARCHAR(100),
    Dosage NVARCHAR(50),
    Duration NVARCHAR(50),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

--Bills table

CREATE TABLE Bills (
    BillID INT IDENTITY PRIMARY KEY,
    VisitID INT,
    TotalAmount DECIMAL(10,2),
    PaymentStatus NVARCHAR(20) DEFAULT 'UNPAID',
    BillDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (VisitID) REFERENCES Visits(VisitID)
);

--Payment transaction table

CREATE TABLE PaymentTransactions (
    PaymentID INT IDENTITY PRIMARY KEY,
    BillID INT,
    Amount DECIMAL(10,2),
    PaymentMode NVARCHAR(50),
    PaymentDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (BillID) REFERENCES Bills(BillID)
);

--Audit table

 create table AuditLog(
   AuditID int identity primary key,
   TableName varchar(50),
   Action varchar(20),
   RecordID int,
   ActionDate DateTime default getdate() 
 );




--UC-1.1 Register patients
go
CREATE PROCEDURE sp_RegisterPatient(@Name NVARCHAR(100), @DOB DATE, @Phone NVARCHAR(15),
 @Email NVARCHAR(100), @Address NVARCHAR(255), @BloodGroup NVARCHAR(5))
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Patients WHERE Phone=@Phone OR Email=@Email)
        begin 
        print 'Patient already exists.';
        return;
    end
        INSERT INTO Patients (Name, DOB, Phone, Email, Address, BloodGroup) VALUES
        (@Name,@DOB,@Phone,@Email,@Address,@BloodGroup)
END
go

--UC-1.2 Update patients

CREATE PROCEDURE sp_UpdatePatient(@PatientID INT,@Name NVARCHAR(100),@DOB DATE,
 @Phone NVARCHAR(15),@Email NVARCHAR(100),
 @Address NVARCHAR(255),@BloodGroup NVARCHAR(5))
AS
BEGIN
    UPDATE Patients
    SET Name=@Name,DOB=@DOB,Phone=@Phone,Email=@Email,Address=@Address,BloodGroup=@BloodGroup
    WHERE PatientID=@PatientID
END

--UC-1.3 Search patients record
create procedure sp_SearchPatient @SearchValue varchar(100)
as 
begin
  select * from Patients where name like '%' + @SearchValue + '%' or Phone = @SearchValue or PatientID = TRY_CAST(@SearchValue AS INT)
end

--UC-1.4 View patient history

CREATE PROCEDURE sp_ViewPatientVisitHistory @PatientID INT
AS
BEGIN
    SELECT v.VisitDate,a.DoctorId,v.Diagnosis
    FROM Appointments a
    JOIN Visits v ON a.AppointmentID = v.AppointmentID
    WHERE a.PatientID = @PatientID
    ORDER BY v.VisitDate ASC
END

select * from Patients;

--UC-2.1 Add Doctor Profile
go 
create procedure sp_AddDoctor(@Name VARCHAR(100),@Contact VARCHAR(15),@ConsultationFee DECIMAL(10,2),@SpecialtyId INT)
as 
begin 
  if exists(select 1 from Doctors where Contact= @Contact)
  begin 
    print 'Doctor already exists.';
    return;
  end
  insert into Doctors(Name, Contact, ConsultationFee, SpecialityID)
  values(@Name, @Contact, @ConsultationFee, @SpecialtyId);
end
go

--UC-2.2 Assign/Update Doctor Speciality

go 
create procedure sp_UpdateDoctorSpeciality(@DoctorId int,@SpecialityId int)
as 
begin
  BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorId = @DoctorId)
    BEGIN
        PRINT 'Doctor not found.';
        ROLLBACK;
        RETURN;
    END

    UPDATE Doctors
    SET SpecialityId = @SpecialityId
    WHERE DoctorId = @DoctorId;

    COMMIT;
end
go

--UC-2.3 View Doctors by speciality

go
create procedure sp_ViewDoctorsBySpeciality(@SpecialityName varchar(100))
as
begin
  select d.DoctorID,d.Name,d.Contact,d.ConsultationFee,s.SpecialityName
  from Doctors d join specialities s on d.SpecialityID = s.SpecialityID
  where s.SpecialityName = @SpecialityName and d.IsActive=1;
end 
go

--UC-2.4 Deacrtivate Doctor Profile
GO
CREATE PROCEDURE sp_DeactivateDoctor
(
 @DoctorID INT
)
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM Appointments
        WHERE DoctorID = @DoctorID
          AND AppointmentDate >= CAST(GETDATE() AS DATE)
          AND Status = 'SCHEDULED'
    )
    BEGIN
        PRINT 'Doctor has future appointments. Cannot deactivate.';
        RETURN;
    END

    UPDATE Doctors
    SET IsActive = 0
    WHERE DoctorID = @DoctorID;
END
GO

--Appointment audit table

create table Appointment_Audit(
   AuditID int identity primary key,
   AppointmentID int,
   Action varchar(50),
   ActionDate DateTime Default getdate()
);


--UC-3.1 Book new appointment

CREATE PROCEDURE sp_BookAppointment(@PatientID INT,@DoctorID INT,@AppointmentDate DATE,@AppointmentTime TIME)
AS
BEGIN
    -- check patient
    IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientID = @PatientID)
    BEGIN
        PRINT 'Invalid Patient';
        RETURN;
    END

    -- check doctor
    IF NOT EXISTS (
        SELECT 1 
        FROM Doctors 
        WHERE DoctorID = @DoctorID AND IsActive = 1
    )
    BEGIN
        PRINT 'Invalid or Inactive Doctor';
        RETURN;
    END
    --check slot availability

  if exists(select 1 from Appointments where DoctorID = @DoctorID AND AppointmentDate = @AppointmentDate AND AppointmentTime = @AppointmentTime AND Status = 'SCHEDULED')
  begin
    print 'Slot already Booked';
    return;
  end
   insert into Appointments(PatientID, DoctorID, AppointmentDate, AppointmentTime, Status)
    VALUES
    (@PatientID, @DoctorID, @AppointmentDate, @AppointmentTime, 'SCHEDULED');

END
GO

--UC-3.2 Check Doctor Availability
go
create procedure dp_CheckDoctorAvailability(@DoctorID INT,@AppointmentDate DATE)
as 
begin
  select AppointmentTime,COUNT(*) AS BookedCount from Appointments where DoctorID = @DoctorID
      AND AppointmentDate = @AppointmentDate AND Status = 'SCHEDULED'
      GROUP BY AppointmentTime
      ORDER BY AppointmentTime;
end
go

--UC-3.3 Cancel Appointment

create procedure sp_CancelAppointment(@AppointmentID int)
as
begin 
   begin transaction;
   IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
   BEGIN
        PRINT 'Appointment not found';
        ROLLBACK;
        RETURN;
    END
   update Appointments
   set Status='Cancelled'
   where AppointmentID=@AppointmentID;
   INSERT INTO Appointment_Audit (AppointmentID, Action)
   VALUES (@AppointmentID, 'CANCELLED');
   commit;
end
go

--UC-3.4 Reschedule Appointment

GO
CREATE PROCEDURE sp_RescheduleAppointment(@AppointmentID INT,@NewDoctorID INT,@NewDate DATE,@NewTime TIME)
AS
BEGIN
    BEGIN TRANSACTION;

    -- check appointment
    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
BEGIN
        PRINT 'Appointment not found';
        ROLLBACK;
        RETURN;
    END

    -- check slot
    IF EXISTS (SELECT 1 FROM Appointments WHERE DoctorID = @NewDoctorID AND AppointmentDate = @NewDate AND AppointmentTime = @NewTime AND Status = 'SCHEDULED')
    BEGIN
        PRINT 'New slot not available';
        ROLLBACK;
        RETURN;
    END

    UPDATE Appointments
    SET DoctorID = @NewDoctorID,
        AppointmentDate = @NewDate,
        AppointmentTime = @NewTime
    WHERE AppointmentID = @AppointmentID;
    COMMIT;
END
GO

--UC-3.5 View Daily Appointment Schedule

GO
CREATE PROCEDURE sp_ViewDailySchedule(@ScheduleDate DATE)
AS
BEGIN
    SELECT 
        a.AppointmentTime,
        p.Name AS PatientName,
        d.Name AS DoctorName,
        a.Status
    FROM Appointments a
    JOIN Patients p ON a.PatientID = p.PatientID
    JOIN Doctors d ON a.DoctorID = d.DoctorID
    WHERE a.AppointmentDate = @ScheduleDate
    ORDER BY a.AppointmentTime;
END
GO

--UC-4.1 Record Patient visit

GO
CREATE PROCEDURE sp_RecordPatientVisit(@AppointmentID INT,@Diagnosis NVARCHAR(255),@Notes NVARCHAR(255),@VisitDate DATE)
AS
BEGIN
    BEGIN TRANSACTION;

    -- check appointment
    IF NOT EXISTS (SELECT 1 FROM Appointments  WHERE AppointmentID = @AppointmentID AND Status = 'SCHEDULED')
    BEGIN
        PRINT 'Invalid or already completed appointment';
        ROLLBACK;
        RETURN;
    END

    -- insert visit
    INSERT INTO Visits (AppointmentID, Diagnosis, Notes, VisitDate)
    VALUES (@AppointmentID, @Diagnosis, @Notes, @VisitDate);

    -- update appointment status
    UPDATE Appointments
    SET Status = 'COMPLETED'
    WHERE AppointmentID = @AppointmentID;
    COMMIT;
END
GO

--UC-4.2 View Patient Medical History

GO
CREATE PROCEDURE sp_ViewPatientMedicalHistory( @PatientID INT)
AS
BEGIN
    SELECT v.VisitDate,d.Name AS DoctorName,v.Diagnosis,v.Notes,p.MedicineName,p.Dosage,p.Duration
    FROM Appointments a
    JOIN Visits v ON a.AppointmentID = v.AppointmentID
    JOIN Doctors d ON a.DoctorID = d.DoctorID
    LEFT JOIN Prescriptions p ON v.VisitID = p.VisitID
    WHERE a.PatientID = @PatientID
    ORDER BY v.VisitDate DESC;
END
GO

--UC-4.3 Add prescription details

CREATE TYPE PrescriptionType AS TABLE(MedicineName NVARCHAR(100),Dosage NVARCHAR(50),Duration NVARCHAR(50));
GO
CREATE PROCEDURE sp_AddPrescriptions(@VisitID INT,@Prescriptions PrescriptionType READONLY)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Visits WHERE VisitID = @VisitID)
    BEGIN
        PRINT 'Invalid Visit';
        RETURN;
    END
    INSERT INTO Prescriptions (VisitID, MedicineName, Dosage, Duration)
    SELECT @VisitID,MedicineName,Dosage,Duration
    FROM @Prescriptions;
END
GO

--UC-5.1 Generate Bill for visit

go
create procedure sp_GenerateBill(@VisitID int)
as 
begin
   DECLARE @DoctorFee DECIMAL(10,2);
    -- validate visit
    IF NOT EXISTS (SELECT 1 FROM Visits WHERE VisitID = @VisitID)
    BEGIN
        PRINT 'Invalid Visit';
        RETURN;
    END
    --get consultation fee
    select @DoctorFee=d.ConsultationFee
    from Visits v join Appointments a on v.AppointmentID=a.AppointmentID join Doctors d on a.DoctorID=d.doctorID where v.VisitID=@VisitID

    --insert bill
    insert into Bills(VisitID,TotalAmount)
    values(@VisitID,@DoctorFee)
end
go

--UC-5.2 Record Payment
go 
create procedure sp_RecordPayment(@BillID int, @Amount DECIMAL(10,2),@PaymentMode VARCHAR(50))
as 
begin
  begin transaction;
  IF NOT EXISTS (
        SELECT 1 FROM Bills 
        WHERE BillID = @BillID AND PaymentStatus = 'UNPAID'
    )
    BEGIN
        PRINT 'Invalid or already paid bill';
        ROLLBACK;
        RETURN;
    END

    --update bill
    update Bills
    set PaymentStatus='PAID' where BillID=@BillID

     -- insert payment transaction
    INSERT INTO PaymentTransactions (BillID, Amount, PaymentMode)
    VALUES (@BillID, @Amount, @PaymentMode);
    commit;
end
go

--UC-5.3View Outstanding Bills

GO
CREATE PROCEDURE sp_ViewOutstandingBills
AS
BEGIN
    SELECT 
        p.PatientID,
        p.Name AS PatientName,
        COUNT(b.BillID) AS PendingBills,
        SUM(b.TotalAmount) AS TotalDue
    FROM Bills b
    JOIN Visits v ON b.VisitID = v.VisitID
    JOIN Appointments a ON v.AppointmentID = a.AppointmentID
    JOIN Patients p ON a.PatientID = p.PatientID
    WHERE b.PaymentStatus = 'UNPAID'
    GROUP BY p.PatientID, p.Name;
END
GO

--UC-5.4 Generate Revenue Report

GO
CREATE PROCEDURE sp_RevenueReport(@FromDate DATE,@ToDate DATE,@MinAmount DECIMAL(10,2))
AS
BEGIN
    SELECT 
        b.BillDate,
        d.Name AS DoctorName,
        s.SpecialityName,
        SUM(b.TotalAmount) AS TotalRevenue
    FROM Bills b
    JOIN Visits v ON b.VisitID = v.VisitID
    JOIN Appointments a ON v.AppointmentID = a.AppointmentID
    JOIN Doctors d ON a.DoctorID = d.DoctorID
    JOIN Specialities s ON d.SpecialityID = s.SpecialityID
    WHERE b.PaymentStatus = 'PAID'
      AND b.BillDate BETWEEN @FromDate AND @ToDate
    GROUP BY b.BillDate, d.Name, s.SpecialityName
    HAVING SUM(b.TotalAmount) >= @MinAmount
    ORDER BY b.BillDate;
END
GO


--UC-6.1: Manage Specialty Lookup

--Add Speciality
GO
CREATE PROCEDURE sp_AddSpeciality(@SpecialityName VARCHAR(100))
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Specialities WHERE SpecialityName = @SpecialityName)
    BEGIN
        PRINT 'Speciality already exists';
        RETURN;
    END

    INSERT INTO Specialities (SpecialityName)
    VALUES (@SpecialityName);
END
GO

--Update Speciality

GO
CREATE PROCEDURE sp_UpdateSpeciality(@SpecialityID INT,@SpecialityName VARCHAR(100))
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Specialities 
        WHERE SpecialityID = @SpecialityID
    )
    BEGIN
        PRINT 'Speciality not found';
        RETURN;
    END

    UPDATE Specialities
    SET SpecialityName = @SpecialityName
    WHERE SpecialityID = @SpecialityID;
END
GO

--View all speciality

GO
CREATE PROCEDURE sp_ViewSpecialities
AS
BEGIN
    SELECT SpecialityID, SpecialityName
    FROM Specialities
    ORDER BY SpecialityName;
END
GO

--Delete speciality
GO
CREATE PROCEDURE sp_DeleteSpeciality(@SpecialityID INT)
AS
BEGIN
    -- check if speciality exists
    IF NOT EXISTS (SELECT 1 FROM Specialities WHERE SpecialityID = @SpecialityID)
    BEGIN
        PRINT 'Speciality not found';
        RETURN;
    END

    -- check foreign key usage
    IF (
        SELECT COUNT(*) 
        FROM Doctors 
        WHERE SpecialityID = @SpecialityID
       ) > 0
    BEGIN
        PRINT 'Cannot delete speciality. Doctors are assigned to it.';
        RETURN;
    END

    DELETE FROM Specialities
    WHERE SpecialityID = @SpecialityID;
END
GO

