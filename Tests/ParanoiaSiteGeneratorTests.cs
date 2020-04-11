using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paranoia_Site_Generator;

namespace Tests
{
    [TestClass]
    public class ParanoiaSiteGeneratorTests
    {
        [TestMethod]
        public void ThrowsExceptionIfNoSqlStatementProvided()
            => Assert.ThrowsException<SqlStatementException>( ( ) => Factory.Build<DummyClass>( ) );
    }
}
