namespace BlabberApp.Domain.Tests
{
    using BlabberApp.Domain;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BlabEntityTests
    {
        private BlabEntity _testClass;
        private string _message;
        private UserEntity _user;

        [SetUp]
        public void SetUp()
        {
            _message = "TestValue1759214493";
            _user = new UserEntity();
            _testClass = new BlabEntity(_message, _user);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new BlabEntity();
            Assert.That(instance, Is.Not.Null);
            instance = new BlabEntity(_message);
            Assert.That(instance, Is.Not.Null);
            instance = new BlabEntity(_user);
            Assert.That(instance, Is.Not.Null);
            instance = new BlabEntity(_message, _user);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullUser()
        {
            Assert.Throws<ArgumentNullException>(() => new BlabEntity(default(UserEntity)));
            Assert.Throws<ArgumentNullException>(() => new BlabEntity("TestValue1426467036", default(UserEntity)));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotConstructWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new BlabEntity(value));
            Assert.Throws<ArgumentNullException>(() => new BlabEntity(value, new UserEntity()));
        }
    }
}