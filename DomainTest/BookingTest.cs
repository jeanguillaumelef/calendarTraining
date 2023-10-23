using Domain;
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
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();


            var success = booking.BookHour(client, patient, bookingTime);

            var bookedSlot = booking.Bookings[bookingTime];

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsNotNull(bookedSlot);
            Assert.AreEqual(bookedSlot.Patient.Name, patient.Name);
            Assert.AreEqual(bookedSlot.Patient.AnimalType, patient.AnimalType);
            Assert.AreEqual(bookedSlot.Client.Id, client.Id);
            Assert.IsTrue(success);

        }

        [TestMethod]
        public void Booking_bookPatientNotAssociatedToClient_fail()
        {
            int expectedNumberOfBooking = 0;
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);

            Patient patient2 = new Patient("roger", "rabbit");
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();


            var success = booking.BookHour(client, patient2, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_bookSlotAlreadyTaken_fail()
        {
            int expectedNumberOfBooking = 1;
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();


            booking.BookHour(client, patient, bookingTime);
            var success = booking.BookHour(client, patient, bookingTime);

            var bookedSlot = booking.Bookings[bookingTime];

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsNotNull(bookedSlot);
            Assert.AreEqual(bookedSlot.Patient.Name, patient.Name);
            Assert.AreEqual(bookedSlot.Patient.AnimalType, patient.AnimalType);
            Assert.AreEqual(bookedSlot.Client.Id, client.Id);
            Assert.IsFalse(success);

        }

        [TestMethod]
        public void Booking_bookSlotInPast_fail()
        {
            int expectedNumberOfBooking = 0;
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(1983, 10, 12, 11, 00, 00).ToUniversalTime();


            var success = booking.BookHour(client, patient, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_bookSlotWithNotAssociatedPatient_fail()
        {
            int expectedNumberOfBooking = 0;
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");

            var randomPatient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            var success = booking.BookHour(client, randomPatient, bookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Booking_cancelExistingBooking_success()
        {
            int expectedNumberOfBooking = 0;
            int intermediaryExpectedNumberOfBooking = 1;
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            booking.BookHour(client, patient, bookingTime);

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
            Booking booking = new Booking();
            Client firstClient = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            firstClient.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();

            Client secondClient = new Client("Paul");

            booking.BookHour(firstClient, patient, bookingTime);

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
            Booking booking = new Booking();
            Client client = new Client("Paul");
            Patient patient = new Patient("roger", "rabbit");
            client.AddPatient(patient);
            DateTime bookingTime = new DateTime(2083, 10, 12, 11, 00, 00).ToUniversalTime();
            DateTime inexistantBookingTime = new DateTime(2083, 10, 12, 12, 00, 00).ToUniversalTime();

            booking.BookHour(client, patient, bookingTime);

            Assert.AreEqual(intermediaryExpectedNumberOfBooking, booking.Bookings.Count);

            bool success = booking.CancelBooking(client.Id, inexistantBookingTime);

            Assert.AreEqual(expectedNumberOfBooking, booking.Bookings.Count);
            Assert.IsFalse(success);
        }
    }
}
