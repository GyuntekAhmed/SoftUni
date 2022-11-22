namespace FightingArena.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Georgi", 100, 100);
            warrior2 = new Warrior("John", 50, 100);
        }

        [Test]
        public void Test_ArenaConstructor()
        {
            // Arrange
            Arena defaultArena = new Arena();

            // Assert
            Assert.IsNotNull(defaultArena.Warriors);
        }

        [Test]
        public void Test_EnrollShouldWithNonExistingWarriorSucces()
        {

            this.arena.Enroll(warrior1);

            bool isWarriorEnroll = this.arena.Warriors.Contains(warrior1);

            Assert.IsTrue(isWarriorEnroll);
        }

        [Test]
        public void Test_EnrollShouldThrowExeptionWithExistingWarrior()
        {
            this.arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior1);
            },
            "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Test_EnrollShouldThrowExeptionWithSameWarriorName()
        {
            warrior2 = new Warrior("Georgi", 55, 66);

            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior2);
            },
            "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Test_CountShouldReturnEnrolledCount()
        {
            // Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            int expectedCount = 2;
            int actualCount = arena.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_CountShouldReturnZerroWhenNoWarriorEnrolled()
        {
            int expectedCount = 0;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldThrowExceptionWithNonExistingAttacker()
        {
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior1.Name,warrior2.Name);
            },
            $"There is no fighter with name {warrior1.Name} enrolled for the fights!");
        }
        
        [Test]
        public void FightShouldThrowExceptionWithNonExistingDefender()
        {
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior1.Name,warrior2.Name);
            },
            $"There is no fighter with name {warrior2.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldSuccesWithValidWarriors()
        {
            int warrior1ExpectedHp = warrior1.HP - warrior2.Damage;
            int warrior2ExpectedHp = warrior2.HP - warrior1.Damage;

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight(warrior1.Name, warrior2.Name);

            int actualWarrior1Hp = arena.Warriors.First(w => w.Name == warrior1.Name).HP;
            int actualWarrior2Hp = arena.Warriors.First(w => w.Name == warrior2.Name).HP;

            Assert.AreEqual(warrior1ExpectedHp, actualWarrior1Hp);
            Assert.AreEqual(warrior2ExpectedHp, actualWarrior2Hp);
        }
    }
}
