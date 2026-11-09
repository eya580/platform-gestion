using Microsoft.Data.SqlClient;

public class Database
{
    public static Microsoft.Data.SqlClient.SqlConnection GetConnection()
    {
        string cs = @"Data Source=(localdb)\MSSQLLocalDB;
                      Initial Catalog=MyDatabase;
                      Integrated Security=True;";

        return new Microsoft.Data.SqlClient.SqlConnection(cs);
    }
}