using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class DatabaseConnectionMSTests
    {
        private DatabaseConnection _dbConnection;

        [TestInitialize]
        public void TestInitialize()
        {
            // Runs BEFORE each test
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [TestMethod]
        public void Connect_ShouldEstablishConnection()
        {
            Assert.IsTrue(_dbConnection.IsConnected);
        }

        [TestMethod]
        public void Disconnect_ShouldCloseConnection()
        {
            _dbConnection.Disconnect();

            Assert.IsFalse(_dbConnection.IsConnected);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Runs AFTER each test
            _dbConnection.Disconnect();
        }
    }
}
