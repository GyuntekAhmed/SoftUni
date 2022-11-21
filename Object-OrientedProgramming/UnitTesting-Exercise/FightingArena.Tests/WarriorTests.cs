namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldInitialWariorName()
        {
            // Arrange
            string ExpectedName = "Georgi";
            Warrior warrior = new Warrior(ExpectedName, 100, 100);

            string actualName = warrior.Name;

            // Assert
            Assert.AreEqual(ExpectedName, actualName);
        }
    }
}