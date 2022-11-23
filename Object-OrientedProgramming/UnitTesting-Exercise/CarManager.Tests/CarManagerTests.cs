namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_ConstructorShouldInitialMake()
        {
            // Arrange
            string expectedMake = "Hyundai";
            Car car = new Car(expectedMake, "SantaFe", 10, 80);
            // Act
            string actualMake = car.Make;
            // Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void ConstructorShouldInitialModel()
        {
            // Arrange
            string expectedModel = "SantaFe";
            Car car = new Car("Hyundai", expectedModel, 10, 80);
            //Act
            string actualModel = car.Model;
            // Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ConstructorShouldInitialFuelConsumption()
        {
            // Arrange
            double expectedFuelCons = 10.00;
            Car car = new Car("Hyundai", "SantaFe", expectedFuelCons, 80);

            // Act
            double actualFuelCons = car.FuelConsumption;

            // Assert
            Assert.AreEqual(expectedFuelCons, actualFuelCons);
        }

        [Test]
        public void ConstructorShouldInitialFuelCapacity()
        {
            // Arrange
            double expectedFuelCapacity = 80.00;
            Car car = new Car("Hyundai", "Santafe", 10, expectedFuelCapacity);

            // Act
            double actualFuelCapacity = car.FuelCapacity;

            // Assert
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase("Hyundai")]
        [TestCase("H")]
        [TestCase("H y u n d a i")]
        public void MakeSetterShouldSetValueWithValidMake(string expectedMake)
        {
            // Arrange
            Car car = new Car(expectedMake, "Santafe", 10, 80);
            // Act
            string actualMake = car.Make;
            // Assert
            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowExceptionWithNullOrEmptyMake(string expectedMake)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(expectedMake, "Santafe", 10, 80);
            },
            "Make cannot be null or empty!");
        }

        [TestCase("SantaFe")]
        [TestCase("S")]
        [TestCase("S a n t a")]
        public void ModelSetterShouldSetValueWithValidModel(string expectedModel)
        {
            // Arrange
            Car car = new Car("Hyundai", expectedModel, 10, 80);
            // Act
            string actualModel = car.Model;
            // Assert
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowExceptionWithNullOrEmptyModel(string expectedModel)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Hyundai", expectedModel, 10, 80);
            },
            "Model cannot be null or empty!");
        }

        [TestCase(1)]
        [TestCase(1000)]
        public void ConsumptionSetterShouldSetValueWithValidConsumption(double expectedConsumption)
        {
            // Arrange
            Car car = new Car("Hyundai", "Santafe", expectedConsumption, 80);
            // Act
            double actualConsumption = car.FuelConsumption;
            // Assert
            Assert.AreEqual(expectedConsumption, actualConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void ConsumptionSetterShouldThrowExceptionWithZeroOrNegativeCons(double expConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Hyundai", "Santafe", expConsumption, 80);
            },
            "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void AmountSetterShouldSetValueWithValidAmount()
        {
            // Arrange]
            int expectedAmount = 0;
            Car car = new Car("Hyundai", "Santafe", 10, 80);
            // Act
            double actualAmount = car.FuelAmount;
            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        //[Test]
        //public void AmountSetterShouldThrowExceptionWithNehativeAmount()
        //{
        //    Car car = new Car("Hyundai", "Santafe", 10, 80);
        //    bool amountIsNegative = car.FuelAmount < 0;

        //    Assert.IsFalse(amountIsNegative, "Fuel amount cannot be negative!");
        //}

        [TestCase(1)]
        [TestCase(111)]
        public void CapacityShouldSetValueWithValidCapacity(double expectedCapacity)
        {
            // Arrange
            Car car = new Car("Hyundai", "Santafe", 10, expectedCapacity);
            // Act
            double actualCapacity = car.FuelCapacity;
            // Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void CapacityShouldThrowExceptionWithZeroOrNegativeCapacity(double expCapacity)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Hyundai", "Santafe", 10, expCapacity);
            },
            "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(1)]
        [TestCase(50)]
        public void RefuelCorrectly(double expFueluel)
        {
            // Arrange
            Car car = new Car("Hyundai", "Santafe", 10, 80);
            // Act
            car.Refuel(expFueluel);
            double actualFuel = car.FuelAmount;
            // Assert
            Assert.AreEqual(expFueluel, actualFuel);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-21)]
        public void RefuelShouldThrowExceptionWithZeroOrNegativeRefuel(double expFuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Hyundai", "Santafe", 10, 80);
                car.Refuel(expFuel);
            });
        }

        public void TestIfRefuelMoreThanCapacity()
        {
            Car car = new Car("Hyundai", "Santafe", 10, 300);
            car.Refuel(350);
            double expectedFuel = 300;

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [Test]
        public void DriveCorrectly()
        {
            Car car = new Car("Hyundai", "Santafe", 15, 300);

            car.Refuel(10);
            car.Drive(10);

            double expectedFuel = 8.5;

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [Test]
        public void TestDrivingTooMuchDistance()
        {
            Car car = new Car("Hyundai", "Santafe", 15, 300);

            car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(10);
            },
            "You don't have enough fuel to drive!");
        }

        [Test]
        public void TestRefuelWithZero()
        {
            Car car = new Car("Hyundai", "Santafe", 15, 300);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }
    }
}