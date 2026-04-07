using Microsoft.Data.SqlClient;

public interface IConnection
{
    SqlConnection GetConnection();
}
