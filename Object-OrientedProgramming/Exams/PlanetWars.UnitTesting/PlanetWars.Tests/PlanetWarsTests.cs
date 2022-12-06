using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Venom", 200);
            }
            [Test]
            public void PlanetConstructorShouldSetNameCorrectly()
            {
                Planet planet = new Planet("Venius", 200);

                string expectedName = "Venius";
                string actualName = planet.Name;

                Assert.AreEqual(expectedName, actualName);
            }

            [Test]
            public void PlanetConstructorShouldSetBudgetCorrectly()
            {
                Planet planet = new Planet("Venius", 200);

                double expextedBudget = 200;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expextedBudget, actualBudget);
            }

            [Test]
            public void PlanetNameThrowWithInvalidName()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(null, 200);
                },
                "Invalid planet Name");
            }

            [Test]
            public void PlanetBudgetThrowWithInvalidBudget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("Venom", -1);
                },
                "Budget cannot drop below Zero!");
            }

            [Test]
            public void ConstructorShouldCreateCollectionOfWeaponsCorrectly()
            {
                int expectedCount = 0;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void WeaponConstructorSetCorrectlyNewWeapon()
            {
                string expectedName = "Nuclear";
                double expectedPrice = 350;
                int expectedLevel = 10;

                Weapon weapon = new Weapon(expectedName, expectedPrice, expectedLevel);

                string actualName = weapon.Name;
                double actualPrice = weapon.Price;
                int actualLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedPrice, actualPrice);
                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [Test]
            public void WeaponThrowWithInvalidPrice()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Nuclear", -1, 5);
                },
                "Price cannot be negative.");
            }

            [Test]
            public void IncreaseDestructionLevelCorrectly()
            {
                int expectedLevel = 8;

                Weapon weapon = new Weapon("Nuclear", 200, 7);

                weapon.IncreaseDestructionLevel();

                int actualLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [Test]
            public void ProfitShouldSetBudgetCorrectly()
            {
                planet.Profit(50);

                double expectedBudget = 250;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void SpendFundsCorrectly()
            {
                planet.SpendFunds(30);

                double expectedBudget = 170;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void SpendFundsThrowWithInvalidAmount()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(2000);
                },
                "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponCorrectly()
            {
                Weapon weapon = new Weapon("Nuclear", 350, 8);
                planet.AddWeapon(weapon);

                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void AddWeaponThrowWenWeaponIsAdded()
            {
                Weapon weapon = new Weapon("Nuclear", 350, 8);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                },
                $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void RemoveWeaponCorrectly()
            {
                Weapon weapon = new Weapon("Nuclear", 350, 8);

                planet.RemoveWeapon("Nuclear");

                Assert.AreEqual("Nuclear", weapon.Name);
            }

            [Test]
            public void UpgradeWeaponCorrectly()
            {
                Weapon weapon = new Weapon("Nuclear", 350, 8);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Nuclear");

                double expectedLevel = 9;
                double actualLevel = planet.MilitaryPowerRatio;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [Test]
            public void UpgradeWeaponThrowWithNonExistingName()
            {
                string weaponName = "Uraaa";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weaponName);
                },
                $"{weaponName} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void DestructOpponentCorrectly()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);

                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 4);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);

                var expectedResult = "PlanetTwo is destructed!";

                Assert.That(planetOne.DestructOpponent(planetTwo), Is.EqualTo(expectedResult));
            }

            [Test]
            public void DestructOpponent_Throws_IfOpponentIsTooStrong()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);

                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 2);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() => planetOne.DestructOpponent(planetTwo),
                    $"{planetTwo.Name} is too strong to declare war to!");
            }

            [Test]
            public void IsNuclearIsTrue()
            {
                Weapon weapon = new Weapon("Nuclear", 350, 11);

                Assert.IsTrue(weapon.IsNuclear);
            }
        }
    }
}
