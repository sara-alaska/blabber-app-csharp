using BlabberApp.DataStore;
using BlabberApp.Domain;
using BlabberApp.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlabberApp.WebApiTest
{
    [TestClass]
    public class BlabControllerTest
    {
        static MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
    "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;");

        BlabsController blabsController = new BlabsController();
        UserMySqlDataStore userDatastore = new UserMySqlDataStore(conn);
        BlabMySqlDataStore blabDatastore = new BlabMySqlDataStore(conn);


        [TestMethod]
        public void Get()
        {
            blabsController.Delete();
            UserEntity expectedUser = new UserEntity();
            expectedUser.Name = "Someuser";
            expectedUser.SetSysId("user@mail.com");
            expectedUser.SetId(userDatastore.Create(expectedUser));
            
            BlabEntity expected = new BlabEntity();
            expected.message = "Message test";
            expected.userId = expectedUser.GetId();
            blabsController.Create(expected);
            OkObjectResult result = (OkObjectResult)blabsController.Get();
            List<BlabEntity> blabList = (List<BlabEntity>)result.Value;
            BlabEntity actual = blabList[0];
            Assert.AreEqual(expected.message, actual.message);
        }


        [TestMethod]
        public void Delete()
        {
            blabsController.Delete();
            var actual = blabDatastore.ReadAll();
            Assert.AreEqual(0, actual.Length);
        }


        [TestMethod]
        public void DeleteById()
        {
            UserEntity expectedUser = new UserEntity();
            expectedUser.Name = "Someuser";
            expectedUser.SetSysId("user@mail.com");
            expectedUser.SetId(userDatastore.Create(expectedUser));

            BlabEntity expected = new BlabEntity();
            expected.message = "Message test";
            expected.userId = expectedUser.GetId();
            expected.SetId(blabDatastore.Create(expected));
            blabsController.Delete(expected.GetId());
            var actual = blabDatastore.ReadAll();
            Assert.AreEqual(0, actual.Length);
        }


        [TestMethod]
        public void GetById()
        {
            blabsController.Delete();
            UserEntity expectedUser = new UserEntity();
            expectedUser.Name = "Someuser";
            expectedUser.SetSysId("user@mail.com");
            expectedUser.SetId(userDatastore.Create(expectedUser));

            BlabEntity expected = new BlabEntity();
            expected.message = "Message test";
            expected.userId = expectedUser.GetId();
            expected.SetId(blabDatastore.Create(expected));
            OkObjectResult result = (OkObjectResult)blabsController.Get(expected.GetId());
            BlabEntity actual = (BlabEntity)result.Value;
            Assert.AreEqual(expected.message, actual.message);
        }


        [TestMethod]
        public void Create()
        {
            blabsController.Delete();
            UserEntity expectedUser = new UserEntity();
            expectedUser.Name = "Someuser";
            expectedUser.SetSysId("user@mail.com");
            expectedUser.SetId(userDatastore.Create(expectedUser));
            BlabEntity expected = new BlabEntity();
            expected.message = "Message testttt";
            expected.userId = expectedUser.GetId();
            blabsController.Create(expected);

            IDomain[] blabsFromDb = blabDatastore.ReadAll();
            Assert.AreEqual(1, blabsFromDb.Length);
        }


        [TestMethod]
        public void Update()
        {
            blabsController.Delete();
            UserEntity expectedUser = new UserEntity();
            expectedUser.Name = "Someuser";
            expectedUser.SetSysId("user@mail.com");
            expectedUser.SetId(userDatastore.Create(expectedUser));

            BlabEntity expected = new BlabEntity();
            expected.message = "Message test";
            expected.userId = expectedUser.GetId();
            expected.SetId(blabDatastore.Create(expected));
            expected.message = "Updated";
            blabsController.Update(expected.GetId(), expected);

            IDomain[] blabsFromDb = blabDatastore.ReadAll();
            BlabEntity first = (BlabEntity)blabsFromDb[0];
            Assert.AreEqual(first.message, expected.message);
        }
    }
}
