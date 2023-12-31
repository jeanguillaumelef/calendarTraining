﻿using Domain;
using Domain.Object;

namespace DomainTest
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        public void Booking_bookSlot_success()
        {
            int expectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            var success = booking.BookHour(client, patient.Id, bookingTime);

            var bookedSlot = booking.Bookings[bookingTime];

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsNotNull(bookedSlot);
            Assert.AreEqual(bookedSlot.PatientId, patient.Id);            
            Assert.AreEqual(bookedSlot.ClientId, client.Id);
            Assert.AreEqual(client.BookingTimes.First(), bookingTime);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Booking_bookPatientNotAssociatedToClient_fail()
        {
            int expectedNumberOfBooking = 0;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);

            Patient patient2 = new Patient("roger", "rabbit");
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();


            var success = booking.BookHour(client, patient2.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_bookSlotAlreadyTaken_fail()
        {
            int expectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();


            booking.BookHour(client, patient.Id, bookingTime);
            var success = booking.BookHour(client, patient.Id, bookingTime);

            var bookedSlot = booking.Bookings[bookingTime];

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsNotNull(bookedSlot);
            Assert.AreEqual(bookedSlot.PatientId, patient.Id);            
            Assert.AreEqual(bookedSlot.ClientId, client.Id);
            Assert.IsFalse(success);

        }

        [TestMethod]
        public void Booking_bookSlotInPast_fail()
        {
            int expectedNumberOfBooking = 0;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(1983, 10, 12, 11, 00, 00).ToUniversalTime();


            var success = booking.BookHour(client, patient.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_bookSlotWithNotAssociatedPatient_fail()
        {
            int expectedNumberOfBooking = 0;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");

            var randomPatient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            var success = booking.BookHour(client, randomPatient.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_cancelExistingBooking_success()
        {
            int expectedNumberOfBooking = 0;
            int intermediaryExpectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            booking.BookHour(client, patient.Id, bookingTime);

            Assert.AreEqual(intermediaryExpectedNumberOfBooking, booking.Bookings.Count);

            bool success = booking.CancelBooking(client.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Booking_cancelExistingBookingNotBelongingToClient_Fail()
        {
            int expectedNumberOfBooking = 1;
            int intermediaryExpectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client firstClient = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            firstClient.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            Client secondClient = new Client("Paul");

            booking.BookHour(firstClient, patient.Id, bookingTime);

            Assert.AreEqual(intermediaryExpectedNumberOfBooking, booking.Bookings.Count);

            bool success = booking.CancelBooking(secondClient.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_cancelInexistantBooking_Fail()
        {
            int expectedNumberOfBooking = 1;
            int intermediaryExpectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();
            DateTime inexistantBookingTime = new DateTime(2083, 10, 12, 12, 00, 00).ToUniversalTime();

            booking.BookHour(client, patient.Id, bookingTime);

            Assert.AreEqual(intermediaryExpectedNumberOfBooking, booking.Bookings.Count);

            bool success = booking.CancelBooking(client.Id, inexistantBookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_modifyExistingBooking_success()
        {
            int expectedNumberOfBooking = 1;
            BookingManagement booking = new BookingManagement();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();            

            booking.BookHour(client, patient.Id, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);

            DateTime newBookingTime = new DateTime(2083, 10, 12, 13, 00, 00).ToUniversalTime();
            bool success = booking.ModifyBookingTime(client, bookingTime, newBookingTime);             

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(booking.Bookings.ContainsKey(bookingTime));
            Assert.IsTrue(booking.Bookings.ContainsKey(newBookingTime));
            Assert.IsTrue(success);
        }
    }
}
