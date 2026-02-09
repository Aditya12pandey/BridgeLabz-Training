using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class VisitUtility
{
    private readonly IConnection _connection;

    public VisitUtility(IConnection connection)
    {
        _connection = connection;
    }

    // UC-4.1 Record Patient Visit
    public void RecordPatientVisit()
    {
        Console.Write("Appointment ID: ");
        int appointmentId = int.Parse(Console.ReadLine());

        Console.Write("Diagnosis: ");
        string diagnosis = Console.ReadLine();

        Console.Write("Notes: ");
        string notes = Console.ReadLine();

        Console.Write("Visit Date (yyyy-mm-dd): ");
        DateTime visitDate = DateTime.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_RecordPatientVisit", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
        cmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
        cmd.Parameters.AddWithValue("@Notes", notes);
        cmd.Parameters.AddWithValue("@VisitDate", visitDate);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Visit recorded successfully");
    }

    // UC-4.2 View Patient Medical History
    public void ViewPatientMedicalHistory()
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewPatientMedicalHistory", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientID", patientId);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n--- Medical History ---");
        while (reader.Read())
        {
            Console.WriteLine(
                $"Date: {reader["VisitDate"]}, " +
                $"Doctor: {reader["DoctorName"]}, " +
                $"Diagnosis: {reader["Diagnosis"]}, " +
                $"Notes: {reader["Notes"]}, " +
                $"Medicine: {reader["MedicineName"]}, " +
                $"Dosage: {reader["Dosage"]}, " +
                $"Duration: {reader["Duration"]}"
            );
        }
    }

    // UC-4.3 Add Prescriptions (Table-Valued Parameter)
    public void AddPrescriptions()
    {
        Console.Write("Visit ID: ");
        int visitId = int.Parse(Console.ReadLine());

        DataTable prescriptionTable = new DataTable();
        prescriptionTable.Columns.Add("MedicineName", typeof(string));
        prescriptionTable.Columns.Add("Dosage", typeof(string));
        prescriptionTable.Columns.Add("Duration", typeof(string));

        while (true)
        {
            Console.Write("Medicine Name (or 'done'): ");
            string medicine = Console.ReadLine();
            if (medicine.ToLower() == "done")
                break;

            Console.Write("Dosage: ");
            string dosage = Console.ReadLine();

            Console.Write("Duration: ");
            string duration = Console.ReadLine();

            prescriptionTable.Rows.Add(medicine, dosage, duration);
        }

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_AddPrescriptions", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VisitID", visitId);

        SqlParameter tvp = cmd.Parameters.AddWithValue("@Prescriptions", prescriptionTable);
        tvp.SqlDbType = SqlDbType.Structured;

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Prescriptions added successfully");
    }
}
