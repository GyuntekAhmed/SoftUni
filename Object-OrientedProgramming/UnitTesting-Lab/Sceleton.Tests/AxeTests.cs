using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(axe.AttackPoints, Is.EqualTo(attackPoints));
                Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints));
            });
        }

        [Test]
        public void Test_AxeAttackPointsShouldDurabilityPointsAfterEachAttack()
        {
            // Act
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints - 5));
        }

        [Test]
        public void Test_AxeAttackShouldThrowExceptionWhen_DurabilityAreZerro()
        {
            // Arrange
            axe = new Axe(10, 0);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            },
            "Axe is broken.");
        }

        [Test]
        public void Test_AxeAttackShouldThrowExceptionWhen_DurabilityAreNegative()
        {
            // Arrange
            axe = new Axe(10, -3);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}