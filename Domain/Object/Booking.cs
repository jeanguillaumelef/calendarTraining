using Domain.Interfaces;

namespace Domain.Object
{
    public class Booking
    {
        //having the key as DateTime might be resource hungry and not be scalable
        public IDictionary<DateTime, BookingDetails> Bookings;

        public Booking()
        {
            Bookings = new Dictionary<DateTime, BookingDetails>();
        }

        public bool BookHour(Client client, Patient patient, DateTime bookingTime)
        {
            if (bookingTime.ToUniversalTime() < DateTime.UtcNow)
            {
                return false;
            }

            var patientCopy = client.GetPatientsCopy();

            //using reference comparison. It is not well readable, might be better to use a Guid comparison
            if (patientCopy.Contains(patient) == false)
            {
                return false;
            }

            var booking = new BookingDetails() { Client = client, Patient = patient };
            bool success = Bookings.TryAdd(bookingTime, booking);

            return success;
        }
    }
}
