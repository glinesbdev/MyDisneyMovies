using System.Data.SqlClient;

namespace MyDisneyMovies.Data
{
    public static class DatabaseManager
    {
        /// <summary>
        /// Opens a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns></returns>
        public static SqlConnection Connect(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
