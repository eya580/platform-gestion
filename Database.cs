
using System.Data.SqlClient;

namespace GestionPret
{
    public static class Database
    {
        private static string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=DataPretsDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
