namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Me");
            gym = new Gym("My Gym", 10);
        }

        [Test]
        public void AthleteShouldSetCorrectly()
        {
            Assert.AreEqual("Me", athlete.FullName);
            Assert.IsFalse(athlete.IsInjured);
        }
        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            string expectedName = "My Gym";
            int expectedSize = 10;

            Gym gym = new Gym(expectedName, expectedSize);

            string actualName = gym.Name;
            int actualSize = gym.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedSize, actualSize);
        }
        [Test]
        public void NameThrowWithInvalidName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                gym = new Gym(null, 5);
            },
            "Invalid gym name.");
        }
        [Test]
        public void CapacityThrowWithNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym("My", -5);
            },
            "Invalid gym capacity.");
        }
        [Test]
        public void CountReturnCountCorrectly()
        {
            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void AddCorrectly()
        {
            Athlete athlete2 = new Athlete("Aaa");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);
        }
        [Test]
        public void AddThrowWithFullCapacity()
        {
            gym = new Gym("Test", 1);

            Athlete athlete2 = new Athlete("Bbb");
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            },
            "The gym is full.");
        }
        [Test]
        public void RemoveCorrectly()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Me");

            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void RemoveThrowWithInvalidName()
        {
            gym.AddAthlete(athlete);
            Athlete athlete2 = new Athlete("Ccc");

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(athlete2.FullName);
            },
            $"The athlete {athlete2.FullName} doesn't exist.");
        }
        [Test]
        public void InjureAthleteCorrectly()
        {
            gym.AddAthlete(athlete);
            var inName = gym.InjureAthlete("Me");

            Assert.AreEqual("Me", inName.FullName);
        }
        [Test]
        public void InjureThrowWithInvalidName()
        {
            athlete = new Athlete("Me");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var inName = gym.InjureAthlete("Aaa");
            },
            $"The athlete {athlete.FullName} doesn't exist.");
        }
    }
}
