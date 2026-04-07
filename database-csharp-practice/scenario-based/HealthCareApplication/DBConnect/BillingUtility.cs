using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class BillingUtility
{
    private readonly IConnection _connection;

    public BillingUtility(IConnection connection)
    {
        _connection = connection;
    }

    // UC-5.1 Generate Bill for Visit
    public void GenerateBill()
    {
        Console.Write("Enter Visit ID: ");
        int visitId = int.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_GenerateBill", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VisitID", visitId);

        conn.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Bill generated successfully (if visit was valid).");
    }

    // UC-5.2 Record Payment
    public void RecordPayment()
    {
        Console.Write("Enter Bill ID: ");
        int billId = int.Parse(Console.ReadLine());

        Console.Write("Enter Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Payment Mode (Cash/Card/UPI): ");
        string mode = Console.ReadLine();

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_RecordPayment", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillID", billId);
        cmd.Parameters.AddWithValue("@Amount", amount);
        cmd.Parameters.AddWithValue("@PaymentMode", mode);

        conn.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Payment recorded successfully.");
    }

    // UC-5.3 View Outstanding Bills
    public void ViewOutstandingBills()
    {
        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_ViewOutstandingBills", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nPatientID\tName\tPending Bills\tTotal Due");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["PatientID"]}\t\t" +
                $"{reader["PatientName"]}\t" +
                $"{reader["PendingBills"]}\t\t" +
                $"{reader["TotalDue"]}"
            );
        }
    }

    // UC-5.4 Revenue Report
    public void GenerateRevenueReport()
    {
        Console.Write("From Date (yyyy-mm-dd): ");
        DateTime fromDate = DateTime.Parse(Console.ReadLine());

        Console.Write("To Date (yyyy-mm-dd): ");
        DateTime toDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Minimum Revenue Amount: ");
        decimal minAmount = decimal.Parse(Console.ReadLine());

        using SqlConnection conn = _connection.GetConnection();
        using SqlCommand cmd = new SqlCommand("sp_RevenueReport", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", fromDate);
        cmd.Parameters.AddWithValue("@ToDate", toDate);
        cmd.Parameters.AddWithValue("@MinAmount", minAmount);

        conn.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nDate\t\tDoctor\t\tSpeciality\tRevenue");

        bool hasData = false;
        while (reader.Read())
        {
            hasData = true;
            Console.WriteLine($"{Convert.ToDateTime(reader["BillDate"]):yyyy-MM-dd}\t" +$"{reader["DoctorName"]}\t" +$"{reader["SpecialityName"]}\t" +$"{reader["TotalRevenue"]}");
        }

        if (!hasData)
            Console.WriteLine("No revenue records found.");
    }
}
