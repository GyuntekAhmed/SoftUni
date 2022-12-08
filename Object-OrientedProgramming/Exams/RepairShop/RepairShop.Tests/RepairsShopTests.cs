using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car("Hyundai", 1835);
                garage = new Garage("My Garage", 3);
            }

            [Test]
            public void CarConstructorShouldSetCorrectly()
            {
                string expectedName = "Hyundai";
                string actualName = car.CarModel;

                int expectedNumber = 1835;
                int actualNumber = car.NumberOfIssues;

                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedNumber, actualNumber);
            }
        }
    }
}