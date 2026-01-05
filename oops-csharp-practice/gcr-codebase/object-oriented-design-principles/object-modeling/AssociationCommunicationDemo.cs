using System;
using System.Collections.Generic;

// Patient class (associated with Doctor)
class Patient
{
    public string PatientName;

    public Patient(string patientName)
    {
        PatientName = patientName;
    }
}

// Doctor class (associated with Patient)
class Doctor
{
    public string DoctorName;
    private List<Patient> consultedPatients;

    public Doctor(string doctorName)
    {
        DoctorName = doctorName;
        consultedPatients = new List<Patient>();
    }

    // Communication method
    public void Consult(Patient patient)
    {
        consultedPatients.Add(patient);

        Console.WriteLine(
            "Consultation: Dr. " + DoctorName +
            " is consulting patient " + patient.PatientName
        );
    }

    public void ShowPatients()
    {
        Console.WriteLine("\nPatients consulted by Dr. " + DoctorName + ":");
        foreach (Patient patient in consultedPatients)
        {
            Console.WriteLine("- " + patient.PatientName);
        }
    }
}

// Hospital class (manages doctors and patients)
class Hospital
{
    public string HospitalName;
    private List<Doctor> doctors;
    private List<Patient> patients;

    public Hospital(string hospitalName)
    {
        HospitalName = hospitalName;
        doctors = new List<Doctor>();
        patients = new List<Patient>();
    }

    public void AddDoctor(Doctor doctor)
    {
        doctors.Add(doctor);
    }

    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }

    public void ShowHospitalDetails()
    {
        Console.WriteLine("\nHospital: " + HospitalName);

        Console.WriteLine("\nDoctors:");
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine("- Dr. " + doctor.DoctorName);
        }

        Console.WriteLine("\nPatients:");
        foreach (Patient patient in patients)
        {
            Console.WriteLine("- " + patient.PatientName);
        }
    }
}

// Concept-focused main class
class AssociationCommunicationDemo
{
    static void Main()
    {
        // Hospital
        Hospital hospital = new Hospital("City Care Hospital");

        // Doctors (independent objects)
        Doctor d1 = new Doctor("Sharma");
        Doctor d2 = new Doctor("Mehta");

        // Patients (independent objects)
        Patient p1 = new Patient("Rahul");
        Patient p2 = new Patient("Priya");

        // Add doctors and patients to hospital
        hospital.AddDoctor(d1);
        hospital.AddDoctor(d2);

        hospital.AddPatient(p1);
        hospital.AddPatient(p2);

        // Association + Communication (many-to-many)
        d1.Consult(p1);
        d1.Consult(p2);

        d2.Consult(p2);

        // Display details
        hospital.ShowHospitalDetails();

        d1.ShowPatients();
        d2.ShowPatients();
    }
}
