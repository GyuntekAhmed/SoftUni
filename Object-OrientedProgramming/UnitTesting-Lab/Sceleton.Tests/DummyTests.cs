using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health;
        private int experience;
        private Dummy deadDummy;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            health = 15;
            experience = 20;
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(-35, experience);
        }

        [Test]
        public void Test_DummyConstructorShouldSetDataProperly()
        {
            // Assert
            Assert.That(dummy.Health, Is.EqualTo(health));
        }

        [Test]
        public void Test_DummyShouldExceptionAttackedAndHealthIsZerro()
        {
            // Act
            dummy.TakeAttack(health);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(2);
            },
            "Dummy is dead.");
        }

        [Test]
        public void Test_DummyShouldExceptionAttackedAndHealthBellowZerro()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(2);
            },
            "Dummy is dead.");
        }

        [Test]
        public void Test_DummyShouldGiveExperienceWhenIsDead()
        {
            // Act
            int dummyExperience = deadDummy.GiveExperience();

            // Assert
            Assert.That(dummyExperience, Is.EqualTo(experience));
        }

        [Test]
        public void Test_DummyGiveExperienceShouldExceptionWhenIsAlive()
        {
            // Act
            deadDummy.GiveExperience();

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            },
            "Target is not dead.");
        }
    }
}