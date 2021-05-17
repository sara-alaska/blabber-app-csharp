namespace BlabberApp.DataStore.Tests.Blab
{
    using BlabberApp.DataStore.Blab;
    using System;
    using NUnit.Framework;
    using BlabberApp.Domain;

    public class InMemoryBlabTests
    {
        private InMemoryBlab _testClass;
        private BlabEntity[] _blabs;

        [SetUp]
        public void SetUp()
        {
            _blabs = new[] { new BlabEntity(), new BlabEntity(), new BlabEntity() };
            _testClass = new InMemoryBlab(_blabs);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new InMemoryBlab();
            Assert.That(instance, Is.Not.Null);
            instance = new InMemoryBlab(_blabs);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullBlabs()
        {
            Assert.Throws<ArgumentNullException>(() => new InMemoryBlab(default(BlabEntity[])));
        }

        [Test]
        public void CanCallAdd()
        {
            var blab = new BlabEntity();
            _testClass.Add(blab);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallAddWithNullBlab()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Add(default(BlabEntity)));
        }

        [Test]
        public void CanCallCount()
        {
            var result = _testClass.Count();
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CanCallCreate()
        {
            var blabEntity = new BlabEntity();
            _testClass.Create(blabEntity);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateWithNullBlabEntity()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Create(default(BlabEntity)));
        }

        [Test]
        public void CanCallDelete()
        {
            var message = "TestValue1152780776";
            _testClass.Delete(message);
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallDeleteWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Delete(value));
        }

        [Test]
        public void CanCallFind()
        {
            var message = "TestValue1592361327";
            var result = _testClass.Find(message);
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallFindWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Find(value));
        }

        [Test]
        public void CanCallRead()
        {
            var message = "TestValue646566176";
            var result = _testClass.Read(message);
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallReadWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Read(value));
        }

        [Test]
        public void CanCallRemove()
        {
            var message = "TestValue694387102";
            _testClass.Remove(message);
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallRemoveWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Remove(value));
        }
    }
}