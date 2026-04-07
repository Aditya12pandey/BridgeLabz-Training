using System;
using System.Data;
using Microsoft.Data.SqlClient;

class SpecialityUtility : ISpecialityUtility
{
    private readonly IConnection _connection;

    public SpecialityUtility(IConnection connection)
    {
        _connection = connection;
    }

    public void AddSpeciality()
    {
        Console.Write("Speciality Name: ");
        string name = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_AddSpeciality", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SpecialityName", name);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Speciality added successfully");
    }

    public void UpdateSpeciality()
    {
        Console.Write("Speciality ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Speciality Name: ");
        string name = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_UpdateSpeciality", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@SpecialityID", id);
        cmd.Parameters.AddWithValue("@SpecialityName", name);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Speciality updated successfully");
    }

    public void ViewSpecialities()
    {
        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewSpecialities", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("--- Specialities ---");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["SpecialityID"]}, Name: {reader["SpecialityName"]}");
        }
    }

    public void DeleteSpeciality()
    {
        Console.Write("Speciality ID: ");
        int id = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_DeleteSpeciality", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SpecialityID", id);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Speciality deleted successfully (if no doctors assigned)");
    }
}
