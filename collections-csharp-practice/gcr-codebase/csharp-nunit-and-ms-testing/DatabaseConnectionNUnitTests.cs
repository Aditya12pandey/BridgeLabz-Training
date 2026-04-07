using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class DatabaseConnectionNUnitTests
    {
        private DatabaseConnection _dbConnection;

        [SetUp]
        public void SetUp()
        {
            // Runs BEFORE each test
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [Test]
        public void Connect_ShouldEstablishConnection()
        {
            Assert.IsTrue(_dbConnection.IsConnected);
        }

        [Test]
        public void Disconnect_ShouldCloseConnection()
        {
            _dbConnection.Disconnect();

            Assert.IsFalse(_dbConnection.IsConnected);
        }

        [TearDown]
        public void TearDown()
        {
            // Runs AFTER each test
            _dbConnection.Disconnect();
        }
    }
}
