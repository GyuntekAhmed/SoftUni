using NUnit.Framework;
using System;

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
            [Test]
            public void ConstructorShouldSetCorrectly()
            {
                garage = new Garage("My Garage", 3);

                Assert.AreEqual("My Garage", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [Test]
            public void NameShouldSetNameCorrectly()
            {
                string expectedName = "My Garage";

                garage = new Garage(expectedName, 2);

                string actualName = garage.Name;

                Assert.AreEqual(expectedName, actualName);
            }
            [Test]
            public void NameThrowsWithInvalidName()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage(null, 1);
                },
                "Invalid garage name.");
            }
            [Test]
            public void MechanicsShouldSetCorrectly()
            {
                int expectedMechanics = 2;

                garage = new Garage("My Garage", expectedMechanics);

                int actualMechanics = garage.MechanicsAvailable;

                Assert.AreEqual(expectedMechanics, actualMechanics);
            }
            [Test]
            public void MechanicsThrowWithZeroValue()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage("My Garage", 0);
                },
                "At least one mechanic must work in the garage.");
            }
            [Test]
            public void MechanicsThrowWithNegativeValue()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage("My Garage", -1);
                },
                "At least one mechanic must work in the garage.");
            }
            [Test]
            public void CarsInGarageCorrectly()
            {
                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);
            }
            [Test]
            public void AddCarCorrectly()
            {
                Car car2 = new Car("BMW", 21);

                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [Test]
            public void AddCarThrowWhenNoMechanicAvailable()
            {
                Garage garage = new Garage("Garage", 1);
                Car car2 = new Car("BMW", 11);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car2);
                },
                "No mechanic available.");
            }
            [Test]
            public void FixCarCorrectly()
            {
                car = new Car("Hyundai", 1);

                garage.AddCar(car);

                var isFixed = garage.FixCar(car.CarModel);

                Assert.AreEqual("Hyundai", isFixed.CarModel);
            }
            [Test]
            public void FixCarThrowWithInvalidCarModel()
            {
                string model = "BMW";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Car car1 = garage.FixCar(model);
                });
            }
            [Test]
            public void RemoveFixedCarCorrectly()
            {
                garage.AddCar(car);
                var fixedCar = garage.FixCar(car.CarModel);
                fixedCar.NumberOfIssues = 0;

                var removedCar = garage.RemoveFixedCar();

                Assert.AreEqual(1, removedCar);
            }
            [Test]
            public void RemoveFixedCarThrow()
            {
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                },
                "No fixed cars available.");
            }
        }
    }
}