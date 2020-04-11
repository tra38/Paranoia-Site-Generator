using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Reflection;

namespace Paranoia_Site_Generator
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SqlStatement : Attribute
    {
        public string Statement { get; set; }

        public SqlStatement(string statement)
            => Statement = statement;
    }

    [SqlStatement("SELECT * FROM phpbb_forums" )]
    public class Forum
    {
        public int ForumId;
        public int CatId;
        public string ForumName;
        public string ForumDesc;
        public int ForumStats;
        public int ForumOrder;
        public int ForumPosts;
        public int ForumTopics;
        public int ForumLastPostId;
        public int PruneNext;
        public int PruneEnable;
        public int AuthView;
        public int AuthRead;
        public int AuthPost;
        public int AuthReply;
        public int AuthEdit;
        public int AuthDelete;
        public int AuthSticky;
        public int AuthAnnounce;
        public int AuthVote;
        public int AuthPollCreate;
        public int AuthAttachments;
    }

    public static class Factory
    {
        public static string ConnectionString           = "server=localhost;user=root;database=alphacomplex;port=3306;";

        public static IEnumerable<T> Build<T>()
            => Build<T>(GetSQLStatement<T>());

        public static IEnumerable<T> Build<T>( string sqlStatement )
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
                throw new Exception($"SQL Statement not found for { typeof(T).Name }");
        }
    }
}
