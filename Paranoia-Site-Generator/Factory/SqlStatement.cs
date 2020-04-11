using System;
namespace Paranoia_Site_Generator
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SqlStatement : Attribute
    {
        public string Statement { get; set; }

        public SqlStatement(string statement)
            => Statement = statement;
    }

    public class SqlStatementException : Exception
    {
        public SqlStatementException(string typeName) : base($"SQL Statement not found for { typeName }")
        { }
    }
}
