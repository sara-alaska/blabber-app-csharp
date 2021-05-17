using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BlabberApp.Domain;
using BlabberApp.DataStore;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabEntityTest
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
            var expected = new InMemoryBlab();
            var actual = new InMemoryBlab();
            // assert
            Assert.AreEqual(expected.Count(), actual.Count());
        }

        [TestMethod]
        public void TestConstructorFailure()
        {
            // arrange
            var expected = new InMemoryBlab();
            var actual = new InMemoryBlab();
            // act
            actual.Add(new BlabEntity());
            // assert
            Assert.AreNotEqual(expected.Count(), actual.Count());
        }

        [TestMethod]
        public void TestConstructorOverrideSuccess()
        {
            // arrange
            BlabEntity[] blabs = {
                new BlabEntity(),
                new BlabEntity(),
                new BlabEntity(),
                new BlabEntity()
            };
            var expected = 4;
            // act
            var fixture = new InMemoryBlab(blabs);
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCountSuccess()
        {
            // arrange
            var expected = 1;
            var fixture = new InMemoryBlab();
            // act
            fixture.Create(new BlabEntity());
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMessageRemoveSuccess()
        {
            // arrange
            var fixture = new InMemoryBlab();
            var expected = 0;
            var blb = new BlabEntity();
            blb.message = "This is blab.";
            // act
            fixture.Create(blb);
            var actual = fixture.Count();
            Assert.AreEqual(1, actual);
            fixture.Remove("This is blab.");
            actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveFailure()
        {
            // arrange
            var fixture = new InMemoryBlab();
            var blb = new BlabEntity();
            // act assert
            fixture.Create(blb);
            var actual = fixture.Count();
            Assert.AreEqual(1, actual);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("1"));
        }

        [TestMethod]
        public void TestRemoveFailure2()
        {
            // arrange
            var fixture = new InMemoryBlab();
            // act assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("1"));
        }

        [TestMethod]
        public void TestFindMessageSuccess()
        {
            // arrange
            var fixture = new InMemoryBlab();
            var expected = new BlabEntity();
            expected.message = ("Blab");
            // act
            fixture.Create(expected);
            var actual = fixture.Find("Blab");
            // assert
            Assert.AreEqual(expected.message, actual.message);
        }

        [TestMethod]
        public void TestFindFailure()
        {
            // arrange
            var fixture = new InMemoryBlab();
            // act assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("foobar@usa.com"));
        }

    }
}
