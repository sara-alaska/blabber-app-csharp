using BlabberApp.DataStore;
using BlabberApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabMySqlDatastoreTest
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
            UserEntity user = new UserEntity();

            BlabMySqlDataStore fixtureBlab = new BlabMySqlDataStore(conn);
            BlabEntity blab = new BlabEntity();

            user.SetSysId("abc@mail.com");
            user.Name = "test";
            user.SetId(fixture.Create(user));

            blab.message = "Test message";
            blab.userId = user.GetId();

            var expected = typeof(IDomain[]);
            fixtureBlab.Create(blab);
            IDomain[] actual = fixtureBlab.ReadAll();
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

            BlabMySqlDataStore fixture = new BlabMySqlDataStore(conn);
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

            BlabMySqlDataStore fixture = new BlabMySqlDataStore(conn);
            fixture.DeleteAll();
            BlabEntity blab = new BlabEntity();

            UserMySqlDataStore fixtureUser = new UserMySqlDataStore(conn);
            UserEntity user = new UserEntity();

            user.SetSysId("abc@mail.com");
            user.Name = "test";
            user.SetId(fixtureUser.Create(user));

            blab.message = "Test message";
            blab.userId = user.GetId();
            blab.SetId(fixture.Create(blab));
            fixture.Delete(blab.GetId());
            var actual = fixture.ReadAll();
            Assert.AreEqual(0, actual.Length);
            fixture.DeleteAll();

        }

    }
}
