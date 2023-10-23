using Domain.Interfaces;

namespace Domain.Object
{
    public class BookingManagement : IBookingManagement
    {
        //having the key as DateTime might be resource hungry and not be scalable
        //conceptual weakness of implicit expectation of having booking date time minutes and seconds set to 0 => maybe look to change format for day and separate hour slot
        public IDictionary<DateTime, BookingDetails> Bookings;

        public BookingManagement()
        {
            Bookings = new Dictionary<DateTime, BookingDetails>();
        }

        public bool BookHour(Client client, Patient patient, DateTime bookingTime)
        {
            bool success = false;

            if (CheckBookingIsPossible(client, patient,bookingTime))
            {
                var booking = new BookingDetails()
                {
                    BookingId = Guid.NewGuid(),
                    ClientId = client.Id,
                    PatientId = patient.Id
                };

                success = Bookings.TryAdd(bookingTime, booking);
                client.BookingIds.Add(booking.BookingId);
            }            

            return success;
        }

        private bool CheckBookingIsPossible(Client client, Patient patient, DateTime bookingTime)
        {
            if (client == null || patient == null)
            {
                return false;
            }

            if (bookingTime.ToUniversalTime() < DateTime.UtcNow)
            {
                return false;
            }            

            //using reference comparison. It is not really explicit/readable, might be better to use a Guid comparison
            if (client.Patients.Contains(patient) == false)
            {
                return false;
            }

            return true;
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
                if (bookingDetail.ClientId != id)
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
