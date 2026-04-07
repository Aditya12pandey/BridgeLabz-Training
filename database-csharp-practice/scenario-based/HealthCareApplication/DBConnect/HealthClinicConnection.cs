using Microsoft.Data.SqlClient;

public class HealthClinicConnection : IConnection
{
    private static string connectionString ="Server=aryan\\SQLEXPRESS;Database=HospitalDataBase;Trusted_Connection=True;TrustServerCertificate=True";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
