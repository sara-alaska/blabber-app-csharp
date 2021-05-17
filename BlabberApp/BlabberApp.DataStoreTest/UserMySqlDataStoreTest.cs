using System.Collections.Generic;
using BlabberApp.DataStore;
using BlabberApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserMySqlDataStoreTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestReadAllOneRecord()
        {

            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );

            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            UserEntity usr = new UserEntity();
            usr.SetSysId("sara@example.com");
            usr.Name = "sara";

            var expected = typeof(IDomain[]);
            fixture.Create(usr);
            IDomain[] actual = fixture.ReadAll();
            Assert.IsInstanceOfType(actual, expected);
            Assert.AreEqual(1, actual.Length);

            fixture.DeleteAll();
        }

        [TestMethod]
        public void TestDeleteAll()
        {
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );

            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            fixture.DeleteAll();
            var actual = fixture.ReadAll();
            Assert.AreEqual(0, actual.Length);
        }

        [TestMethod]
        public void TestDelete()
        {
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            );

            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            fixture.DeleteAll();
            UserEntity usr = new UserEntity();
            usr.SetSysId("e@example.com");
            usr.Name = "Sara";
            usr.SetId(fixture.Create(usr));
            fixture.Delete(usr.GetId());
            var actual = fixture.ReadAll();
            Assert.AreEqual(0, actual.Length);
            fixture.DeleteAll();

        }

        [TestMethod]
        public void TestReadAllSuccess()
        {
            // arrange
            var expected = new List<UserEntity>().ToArray();
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;"
            ));
            // act
            var actual = fixture.ReadAll();
            // assert
            Assert.AreEqual(expected, actual);
            fixture.DeleteAll();
        }
    }
}