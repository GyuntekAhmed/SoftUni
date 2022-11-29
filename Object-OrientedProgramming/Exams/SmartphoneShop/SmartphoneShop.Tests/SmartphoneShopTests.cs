using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;
        private Smartphone smartphone;
        string modelName = "Samsung";
        int maximumCharge = 100;
        private int capacity = 5;

        [SetUp]
        public void SetUp()
        {
            shop = new Shop(capacity);
            smartphone = new Smartphone(modelName, maximumCharge);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-1);
            },
            "Invalid capacity.");
        }

        [Test]
        public void AddCorrectly()
        {
            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddPhoneShouldThrowExceptionWhenModelAllreadyExist()
        {
            Smartphone smartphone2 = new Smartphone(modelName, maximumCharge);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone2);
            },
            $"The phone model {smartphone.ModelName} already exist.");
        }

        [Test]
        public void AddPhoneShouldThrowExceptionWhenShopIsFull()
        {
            shop = new Shop(1);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Nooooo", 10));
            },
            "The shop is full.");
        }

        [Test]
        public void RemoveCorrectly()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenModelNotExist()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Noooo");
            },
            $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void TestPhoneShouldReduceBattery()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 40);

            Assert.AreEqual(maximumCharge - 40, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenModelNotExist()
        {
            string currentName = "No no no";

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(currentName, 20);
            },
            $"The phone model {currentName} doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenIsBatteryLow()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, maximumCharge + 200);
            },
            $"The phone model {modelName} is low on batery.");
        }

        [Test]
        public void ChargePhoneShouldThrowExceptionWhenModelNotExist()
        {
            string currentName = "No no no";

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(currentName);
            },
            $"The phone model {currentName} doesn't exist.");
        }

        [Test]
        public void ChargePhoneShouldSetBatteryCorrectly()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 20);
            shop.ChargePhone(modelName);

            Assert.AreEqual(maximumCharge, smartphone.CurrentBateryCharge);
        }
    }
}