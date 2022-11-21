namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldInitialWarriorName()
        {
            // Arrange
            string expectedName = "Georgi";
            Warrior warrior = new Warrior(expectedName, 100, 100);

            // Act
            string actualName = warrior.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        //[TestCase(1)]
        //[TestCase(50)]
        [Test]
        public void ConstructorShouldInitialWarriorDamage()
        {
            // Arrange
            int expectedDamage = 100;
            Warrior warrior = new Warrior("Georgi", expectedDamage, 100);

            // Act
            int actualDamage = warrior.Damage;

            // Assert
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        //[TestCase(0)]
        //[TestCase(1)]
        //[TestCase(50)]
        //[TestCase(500)]
        [Test]
        public void ConstructorShouldInitialWarriorHP()
        {
            // Arrange
            int expectedHP = 100;
            Warrior warrior = new Warrior("Georgi", 100, expectedHP);

            // Act
            int actualHP = warrior.HP;

            // Assert
            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase("Georgi")]
        [TestCase("G")]
        [TestCase("Too long Warrior Name")]
        public void NameSetterShouldSetValueWithValidName(string name)
        {
            // Arrange
            Warrior warrior = new Warrior(name, 100, 100);

            // Act
            string expectedName = name;
            string actualName = warrior.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("         ")]
        public void NameSetterShouldThrowExceptionWithEmOrWhName(string name)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 100, 100);
            },
            "Name should not be empty or whitespace!");
        }

        [TestCase(1)]
        [TestCase(50)]
        public void DamageSetterShouldSetValueWithValidDamage(int damage)
        {
            // Arrange
            Warrior warrior = new Warrior("Georgi", damage, 100);

            // Act
            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            // Assert
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void DamageSetterShouldThrowExeptionWithZeroOrNegative(int damage)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Georgi", damage, 100);
            },
            "Damage value should be positive!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(100)]
        public void HPSetterShouldSetValueWithValid(int hp)
        {
            // Arrange
            Warrior warrior = new Warrior("Georgi", 100, hp);

            // Act
            int expectedHP = hp;
            int actualHp = warrior.HP;

            // Assert
            Assert.AreEqual(expectedHP, actualHp);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        public void HPSetterShouldThrowExeptionWithNegativeHP(int hp)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Georgi", 100, hp);
            },
            "HP should not be negative!");
        }

        [Test]
        public void VallidAttackWarriorNoKill()
        {
            // Arrange
            int warr1Damage = 70;
            int warr1Hp = 100;
            int warr2Damage = 50;
            int warr2Hp = 100;

            Warrior warrior1 = new Warrior("Georgi", warr1Damage, warr1Hp);
            Warrior warrior2 = new Warrior("John", warr2Damage, warr2Hp);

            // Act
            warrior1.Attack(warrior2);

            int warr1ExpectedHp = warr1Hp - warr2Damage;
            int warr2ExpectedHp = warr2Hp - warr1Damage;

            int warr1ActualHp = warrior1.HP;
            int warr2ActualHp = warrior2.HP;

            // Assert
            Assert.AreEqual(warr1ExpectedHp, warr1ActualHp);
            Assert.AreEqual(warr2ExpectedHp, warr2ActualHp);
        }

        [TestCase(69)]
        [TestCase(70)]
        public void VallidAttackWarriorWithKill(int warr2Hp)
        {
            // Arrange
            int warr1Damage = 70;
            int warr1Hp = 100;
            int warr2Damage = 50;

            Warrior warrior1 = new Warrior("Georgi", warr1Damage, warr1Hp);
            Warrior warrior2 = new Warrior("John", warr2Damage, warr2Hp);

            // Act
            warrior1.Attack(warrior2);

            int warr1ExpectedHp = warr1Hp - warr2Damage;
            int warr2ExpectedHp = 0;

            int warr1ActualHp = warrior1.HP;
            int warr2ActualHp = warrior2.HP;

            // Assert
            Assert.AreEqual(warr1ExpectedHp, warr1ActualHp);
            Assert.AreEqual(warr2ExpectedHp, warr2ActualHp);
        }

        [TestCase(0)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackingShouldThrowExeptionWhenAttackerHPIsBelowMin(int warr1Hp)
        {
            // Arrange
            int warr1Damage = 70;
            int warr2Damage = 50;
            int warr2Hp = 100;

            Warrior warrior1 = new Warrior("Georgi", warr1Damage, warr1Hp);
            Warrior warrior2 = new Warrior("John", warr2Damage, warr2Hp);

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            },
            "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackingShouldThrowExeptionWhenDefenderHPIsBelowMin(int warr2Hp)
        {
            // Arrange
            int warr1Damage = 70;
            int warr1Hp = 100;
            int warr2Damage = 50;

            Warrior warrior1 = new Warrior("Georgi", warr1Damage, warr1Hp);
            Warrior warrior2 = new Warrior("John", warr2Damage, warr2Hp);

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            },
            $"Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(55, 65)]
        [TestCase(55, 56)]
        public void AttackingShouldThrowExeptionWhenAttackerHPIsBelowDeffenderDamage(int warr1Hp, int warr2Damage)
        {
            // Arrange
            int warr1Damage = 70;
            int warr2Hp = 100;

            Warrior warrior1 = new Warrior("Georgi", warr1Damage, warr1Hp);
            Warrior warrior2 = new Warrior("John", warr2Damage, warr2Hp);

            // Act && Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            },
            "You are trying to attack too strong enemy");
        }
    }
}