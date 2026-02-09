using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class DoctorUtility
{
    private readonly IConnection _connection;

    public DoctorUtility(IConnection connection)
    {
        _connection = connection;
    }

    // UC-2.1 Add Doctor
    public void AddDoctor()
    {
        Console.Write("Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Contact: ");
        string contact = Console.ReadLine();

        Console.Write("Consultation Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());

        Console.Write("Speciality ID: ");
        int specialityId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_AddDoctor", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Contact", contact);
        cmd.Parameters.AddWithValue("@ConsultationFee", fee);
        cmd.Parameters.AddWithValue("@SpecialtyId", specialityId);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Doctor added successfully");
    }

    // UC-2.2 Update Doctor Speciality
    public void UpdateDoctorSpeciality()
    {
        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("New Speciality ID: ");
        int specialityId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_UpdateDoctorSpeciality", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DoctorId", doctorId);
        cmd.Parameters.AddWithValue("@SpecialityId", specialityId);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Doctor speciality updated");
    }

    // UC-2.3 View Doctors by Speciality
    public void ViewDoctorsBySpeciality()
    {
        Console.Write("Speciality Name: ");
        string specialityName = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewDoctorsBySpeciality", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SpecialityName", specialityName);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["DoctorID"]}, " +$"Name: {reader["Name"]}, " + $"Contact: {reader["Contact"]}, " +$"Fee: {reader["ConsultationFee"]}, " +$"Speciality: {reader["SpecialityName"]}");
        }
    }

    // UC-2.4 Deactivate Doctor
    public void DeactivateDoctor()
    {
        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_DeactivateDoctor", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DoctorID", doctorId);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Doctor deactivated (if no future appointments)");
    }
}
