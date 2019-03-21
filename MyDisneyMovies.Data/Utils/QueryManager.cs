using MyDisneyMovies.Data.Helpers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MyDisneyMovies.Data.Utils
{
    /// <summary>
    /// A collection of queries to get database information for <see cref="T"/>.
    /// </summary>
    public static class QueryManager<T> where T : class, new()
    {
        #region Public Methods

        /// <summary>
        /// Gets all data for <see cref="T"/>.
        /// </summary>
        /// <returns></returns>
        public static List<T> Select(IEnumerable<string> columns = null, string table = null)
        {
            using (SqlConnection connection = DatabaseManager.Connect(ConnectionStringHelper.MyDisneyMovies))
            using (SqlCommand command = QueryBuilder<T>.BuildSqlCommand(QueryBuilder<T>.SelectQuery(columns, table), connection))
            {
                List<T> movies = new List<T>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T movie = new T();
                    List<string> columnNames = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();

                    foreach (string column in columnNames)
                    {
                        foreach (PropertyInfo property in typeof(T).GetProperties())
                        {
                            if (column == property.Name)
                            {
                                property.SetValue(movie, reader[column]);
                                break;
                            }
                        }
                    }

                    movies.Add(movie);
                }

                return movies;
            }
        }

        /// <summary>
        /// Basic INSERT query into the default class table using the name of <see cref="typeof(T)"/>.
        /// </summary>
        /// <param name="values">The values to be inserted into each column.</param>
        /// <returns></returns>
        public static void Insert(IEnumerable<object> values)
        {
            using (SqlConnection connection = DatabaseManager.Connect(ConnectionStringHelper.MyDisneyMovies))
            using (SqlCommand command = QueryBuilder<T>.BuildSqlCommand(QueryBuilder<T>.InsertQuery(values), connection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Basic INSERT query into either the default class table using the name of <see cref="typeof(T)"/> 
        /// or a specified table with specified column names and values. 
        /// </summary>
        /// <param name="columnNamesAndValues">The names and values of each table column.</param>
        /// <param name="table">The name of the table. If null, uses the name of <see cref="typeof(T)"/>.</param>
        /// <returns></returns>
        public static void Insert(Dictionary<string, object> columnNamesAndValues, string table = null)
        {
            using (SqlConnection connection = DatabaseManager.Connect(ConnectionStringHelper.MyDisneyMovies))
            using (SqlCommand command = QueryBuilder<T>.BuildSqlCommand(QueryBuilder<T>.InsertQuery(columnNamesAndValues, table), connection))
            {
                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
