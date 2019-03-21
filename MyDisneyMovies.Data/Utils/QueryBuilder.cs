using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyDisneyMovies.Data.Utils
{
    /// <summary>
    /// Responsible for buliding queries.
    /// Queries are built based on the <see cref="typeof(T)"/>
    /// and will use the name of the class as the table name by default.
    /// 
    /// Example: QueryManager<MovieEntity>.SelectQuery();
    /// Result: SELECT * FROM MovieEntity;
    /// 
    /// Example: QueryManager<MovieEntity>.SelectQuery(new List<string> { "Title", "Overview", "PosterPath" });
    /// Result: SELECT Title, Overview, PosterPath FROM MovieEntity;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QueryBuilder<T>
    {
        #region Public Methods

        /// <summary>
        /// Basic SELECT query that selects all or specified columns from a table.
        /// </summary>
        /// <param name="columns">The names of the columns to select from.</param>
        /// <param name="table">The table to use in the query. If null, uses the name of <see cref="T"/></param>
        public static string SelectQuery(IEnumerable<string> columns = null, string table = null)
        {
            string sql = columns?.Count() > 0 ? $"SELECT {BuildColumnList(columns)}" : "SELECT *";
            sql += table == null ? $" FROM {typeof(T).Name};" : $" FROM {table};";

            return sql;
        }

        /// <summary>
        /// Basic INSERT query into the default class table using the name of <see cref="typeof(T)"/>.
        /// </summary>
        /// <param name="values">The values to be inserted into each column.</param>
        /// <returns></returns>
        public static string InsertQuery(IEnumerable<object> values)
        {
            string sql = $"INSERT INTO {typeof(T).Name} ({BuildColumnList(typeof(T).GetProperties().Select(prop => prop.Name).ToList())}) VALUES (";

            foreach (object value in values)
            {
                if (value is string)
                    sql += $"'{value}'";
                else
                    sql += value.ToString();

                if (value != values.Last())
                    sql += ", ";
                else
                    sql += ");";
            }

            return sql;
        }

        /// <summary>
        /// Basic INSERT query into either the default class table using the name of <see cref="typeof(T)"/> 
        /// or a specified table with specified column names and values. 
        /// </summary>
        /// <param name="columnNamesAndValues">The names and values of each table column.</param>
        /// <param name="table">The name of the table. If null, uses the name of <see cref="typeof(T)"/>.</param>
        /// <returns></returns>
        public static string InsertQuery(Dictionary<string, object> columnNamesAndValues, string table = null)
        {
            string sql = table == null ? $"INSERT INTO {typeof(T).Name} (" : $"INSERT INTO {table} (";
            sql += $"{BuildColumnList(columnNamesAndValues.Keys)}) VALUES (";

            foreach (object value in columnNamesAndValues.Values)
            {
                if (value is string)
                    sql += $"'{value}'";
                else
                    sql += value.ToString();

                if (value != columnNamesAndValues.Values.Last())
                    sql += ", ";
                else
                    sql += ");";
            }


            return sql;
        }

        /// <summary>
        /// Builds and returns a <see cref="SqlCommand"/>.
        /// </summary>
        /// <param name="sql">The SQL string.</param>
        /// <param name="connection">The active <see cref="SqlConnection"/>.</param>
        /// <param name="parameters">A key value set of parameters to add to the command which contains the name of the parameter and the value.</param>
        /// <param name="commandType">The <see cref="CommandType"/> to use.</param>
        /// <returns></returns>
        public static SqlCommand BuildSqlCommand(string sql, SqlConnection connection, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text)
        {
            SqlCommand command = new SqlCommand(sql, connection)
            {
                CommandType = commandType
            };

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> pair in parameters)
                {
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                }
            }

            return command;
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Builds a string of column names for easier query building.
        /// </summary>
        /// <param name="columnNames">The enumerable of column names.</param>
        /// <returns></returns>
        private static string BuildColumnList(IEnumerable<string> columnNames)
        {
            string result = string.Empty;

            for (int i = 0; i < columnNames.Count(); i++)
            {
                result += columnNames.ElementAt(i);

                if (columnNames.ElementAt(i) != columnNames.Last())
                    result += ", ";
            }

            return result;
        }

        #endregion
    }
}
