using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class PatientUtility
{
    private readonly IConnection _connection;

    public PatientUtility(IConnection connection)
    {
        _connection = connection;
    }

    public void RegisterPatient()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("DOB (yyyy-mm-dd): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Blood Group: ");
        string bloodGroup = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_RegisterPatient", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@DOB", dob);
        cmd.Parameters.AddWithValue("@Phone", phone);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Address", address);
        cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Patient registered successfully");
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void UpdatePatient()
    {
        Console.Write("Patient ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("DOB (yyyy-mm-dd): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Blood Group: ");
        string bloodGroup = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_UpdatePatient", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientID", id);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@DOB", dob);
        cmd.Parameters.AddWithValue("@Phone", phone);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Address", address);
        cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);

        conn.Open();
        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "Patient updated" : "Patient not found");
    }

    public void SearchPatient()
    {
        Console.Write("Enter Name / Phone / PatientID: ");
        string search = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_SearchPatient", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SearchValue", search);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"ID: {reader["PatientID"]}, Name: {reader["Name"]}, Phone: {reader["Phone"]}, Email: {reader["Email"]}"
            );
        }
    }

    public void ViewPatientHistory()
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewPatientVisitHistory", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientID", patientId);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Date: {reader["VisitDate"]}, Doctor ID: {reader["DoctorId"]}, Diagnosis: {reader["Diagnosis"]}");
        }
    }
}
