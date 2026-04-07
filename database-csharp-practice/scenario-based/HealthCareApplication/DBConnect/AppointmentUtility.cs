using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class AppointmentUtility
{
    private readonly IConnection _connection;

    public AppointmentUtility(IConnection connection)
    {
        _connection = connection;
    }

    // UC-3.1 Book Appointment
    public void BookAppointment()
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("Appointment Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Appointment Time (HH:mm): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_BookAppointment", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientID", patientId);
        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
        cmd.Parameters.AddWithValue("@AppointmentDate", date);
        cmd.Parameters.AddWithValue("@AppointmentTime", time);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Appointment booked successfully");
    }

    // UC-3.2 Check Doctor Availability
    public void CheckDoctorAvailability()
    {
        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("dp_CheckDoctorAvailability", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DoctorID", doctorId);
        cmd.Parameters.AddWithValue("@AppointmentDate", date);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Booked Slots:");
        while (reader.Read())
        {
            Console.WriteLine(
                $"Time: {reader["AppointmentTime"]}, Count: {reader["BookedCount"]}"
            );
        }
    }

    // UC-3.3 Cancel Appointment
    public void CancelAppointment()
    {
        Console.Write("Appointment ID: ");
        int appointmentId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_CancelAppointment", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Appointment cancelled");
    }

    // UC-3.4 Reschedule Appointment
    public void RescheduleAppointment()
    {
        Console.Write("Appointment ID: ");
        int appointmentId = int.Parse(Console.ReadLine());

        Console.Write("New Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        Console.Write("New Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("New Time (HH:mm): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_RescheduleAppointment", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
        cmd.Parameters.AddWithValue("@NewDoctorID", doctorId);
        cmd.Parameters.AddWithValue("@NewDate", date);
        cmd.Parameters.AddWithValue("@NewTime", time);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Appointment rescheduled");
    }

    // UC-3.5 View Daily Schedule
    public void ViewDailySchedule()
    {
        Console.Write("Schedule Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewDailySchedule", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ScheduleDate", date);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nDaily Schedule:");
        while (reader.Read())
        {
            Console.WriteLine($"Time: {reader["AppointmentTime"]}, " +$"Patient: {reader["PatientName"]}, " + $"Doctor: {reader["DoctorName"]}, " + $"Status: {reader["Status"]}"
            );
        }
    }
}
