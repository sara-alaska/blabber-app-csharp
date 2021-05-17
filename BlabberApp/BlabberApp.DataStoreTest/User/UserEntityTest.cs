using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserEntityTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestConstructorSuccess()
        {
            // arrange act
            var expected = new InMemory();
            var actual = new InMemory();
            // assert
            Assert.AreEqual(expected.Count(), actual.Count());
        }
        [TestMethod]
        public void TestConstructorFailure()
        {
            // arrange
            var expected = new InMemory();
            var actual = new InMemory();
            // act
            actual.Add(new UserEntity());
            // assert
            Assert.AreNotEqual(expected.Count(), actual.Count());
        }
        [TestMethod]
        public void TestConstructorOverrideSuccess()
        {
            // arrange
            UserEntity[] users = {
                new UserEntity(),
                new UserEntity(),
                new UserEntity(),
                new UserEntity()
            };
            var expected = 4;
            // act
            var fixture = new InMemoryUser(users);
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountSuccess()
        {
            // arrange
            var expected = 1;
            var fixture = new InMemory();
            // act
            fixture.Create(new UserEntity());
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRemoveSuccess()
        {
            // arrange
            var fixture = new InMemory();
            var expected = 0;
            var usr = new UserEntity();
            usr.SetSysId("foobar@usa.us");
            // act
            usr.SetId(fixture.Create(usr));
            var actual = fixture.Count();
            Assert.AreEqual(1, actual);
            fixture.Remove(usr.GetId());
            actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }

        

        
      


       
    }
}