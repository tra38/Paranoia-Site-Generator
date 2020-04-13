using System.Collections.Generic;
using System.Reflection;
using Dapper;
using MySql.Data.MySqlClient;

namespace Paranoia_Site_Generator
{
    public static class Factory
    {
        public static string ConnectionString = "server=localhost;user=root;database=alphacomplex;port=3306;";

        public static IEnumerable<T> Build<T>()
            => Build<T>(GetSQLStatement<T>());

        public static IEnumerable<T> Build<T>(string sqlStatement)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using (var conn = new MySqlConnection(ConnectionString))
            {
                return conn.Query<T>(sqlStatement);
            }
        }

        public static string GetSQLStatement<T>( )
        {
            var attribute = typeof(T).GetCustomAttribute<SqlStatement>(true);

            if (attribute != null)
                return attribute.Statement;
            else
                throw new SqlStatementException(typeof(T).Name);
        }
    }

}
