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
            Patient patient = new Patient("roger","rabbit");
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
    }
}
