namespace BookigApp.Tests
{
    using System;

    using FrontDeskApp;
    using NUnit.Framework;

    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(3, 30);
            booking = new Booking(1, room, 3);
            hotel = new Hotel("Silistra", 1);
        }

        [Test]
        public void RoomConstructorShouldInitialCorrectly()
        {
            int expectedBedCapacity = 2;
            double expectedPricePerNight = 30;

            Room room = new Room(expectedBedCapacity, expectedPricePerNight);

            int actualBedCapacity = room.BedCapacity;
            double actualPricePerNight = room.PricePerNight;

            Assert.AreEqual(expectedBedCapacity, actualBedCapacity);
            Assert.AreEqual(expectedPricePerNight, actualPricePerNight);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void BedCapacitySetterShouldSetValueWithValidCapacity(int expCapacity)
        {
            room = new Room(expCapacity, 30);

            int actualCapacity = room.BedCapacity;

            Assert.AreEqual(expCapacity, actualCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void BedCapacitySetterShouldThrowExceptionWithInvalidCapacity(int expCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(expCapacity, 50);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void PriceSetterShouldThrowExceptionWithInvalidPrice(double expPrice)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                room = new Room(4, expPrice);
            });
        }

        [Test]
        public void BookingRoomConstructorShouldInitialCorrectly()
        {
            int expNumber = 2;
            Room expRoom = room;
            int expDuration = 2;

            booking = new Booking(expNumber, expRoom, expDuration);

            int actualNumber = booking.BookingNumber;
            Room actualRoom = booking.Room;
            int actualDuration = booking.ResidenceDuration;

            Assert.AreEqual(expNumber, actualNumber);
            Assert.AreEqual(expRoom, actualRoom);
            Assert.AreEqual(expDuration, actualDuration);
        }

        //[TestCase("Silistra")]
        //[TestCase("S")]
        //[TestCase("S i l i s t r a")]
        //public void FullNameShouldSetValueWithValidName(string expName)
        //{
        //    hotel = new Hotel(expName, 2);

        //    string actualName = hotel.FullName;

        //    Assert.AreEqual(expName, actualName);
        //}


        [Test]
        public void HotelCtor_SetsNameAndCategoryCorrectly()
        {
            var hotel = new Hotel("Kavaler", 3);

            string expectedName = "Kavaler";
            int expectedCategory = 3;
            var expectedTurnover = 0;

            Assert.That(hotel.FullName, Is.EqualTo(expectedName));
            Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }

        [Test]
        public void HotelCtor_ThrowsExceptionForInvalidNameAndCategory()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 5));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 6));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 0));
        }

        [Test]
        public void AddRoom_AddsRoomsCorrectly()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(3, 57);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }
        [Test]
        public void BookRoom_ThrowsForAdults()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(2, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 0, 3, 200));
        }

        [Test]
        public void BookRoom_ThrowsForChildren()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 3, 200));
        }

        [Test]
        public void BookRoom_ThrowsForDuration()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 1, 0, 200));
        }

        [Test]
        public void BookRoom_NoBookingForNotEnoughBeds()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(3, 53);
            hotel.AddRoom(room);

            hotel.BookRoom(4, 1, 2, 200);

            Assert.That(hotel.Turnover.Equals(0));
        }

        [Test]
        public void BookRoom_WorksProperly()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(5, 53);
            hotel.AddRoom(room);

            hotel.BookRoom(4, 1, 2, 106);
            double expectedTurnover = 106;

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
            Assert.That(hotel.Bookings.Count.Equals(1));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }

        [Test]
        public void BookRoom_NoBookingIfTooLowBudget()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(5, 53);
            hotel.AddRoom(room);

            hotel.BookRoom(4, 1, 2, 100);
            double expectedTurnover = 0;

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
            Assert.That(hotel.Bookings.Count.Equals(0));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }
    }
}