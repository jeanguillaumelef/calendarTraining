using Domain.Interfaces;

namespace Domain.Object
{
    public class Booking : IBooking
    {
        //having the key as DateTime might be resource hungry and not be scalable
        //conceptual weakness of implicit expectation of having booking date time minutes and seconds set to 0 => maybe look to change format for day and separate hour slot
        public IDictionary<DateTime, BookingDetails> Bookings;

        public Booking()
        {
            Bookings = new Dictionary<DateTime, BookingDetails>();
        }

        public bool BookHour(Client client, Patient patient, DateTime bookingTime)
        {
            //explicitely fail for bookingtime null
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

        public bool CancelBooking(Guid id, DateTime bookingTime)
        {
            bool cancelSuccess = false;
            var valueFound = Bookings.TryGetValue(bookingTime, out var bookingDetail);

            if (valueFound == false)
            {
                cancelSuccess = false;
            }
            else
            {
//we disable the warning because the responsibility of the value not being null is in the BookHour function
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (bookingDetail.Client.Id != id)
                {
                    cancelSuccess = false;
                }
                else
                {
                    cancelSuccess = Bookings.Remove(bookingTime);
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.                
            }

            return cancelSuccess;
        }
    }
}
