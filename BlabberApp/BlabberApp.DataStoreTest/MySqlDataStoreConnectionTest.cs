using System;
using System.Data;
using BlabberApp.DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class MySqlDataStoreConnectionTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestConstructor()
        {
            // arrange
            MySqlDataStoreConnection fixture = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );
            // act & assert
            try
            {
                fixture.Open();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
            try
            {
                fixture.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        public void TestCreateCommand()
        {
            // arrange
            MySqlDataStoreConnection fixture = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );
            // act
            var actual = fixture.CreateCommand();
            // assert
            Assert.IsTrue(actual is IDbCommand);
        }
    }
}