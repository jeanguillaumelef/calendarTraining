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

        //TODO refactor to have check and action separate
        public bool BookHour(Client client, Guid patientId, DateTime bookingTime)
        {
            bool success = false;

            if (CheckBookingIsPossible(client, patientId, bookingTime))
            {
                var booking = new BookingDetails()
                {
                    BookingId = Guid.NewGuid(),
                    ClientId = client.Id,
                    PatientId = patientId
                };

                success = Bookings.TryAdd(bookingTime, booking);
                client.BookingTimes.Add(bookingTime);
            }

            return success;
        }

        private bool CheckBookingIsPossible(Client client, Guid patientId, DateTime bookingTime)
        {
            if (client == null || patientId == Guid.Empty)
            {
                return false;
            }

            if (bookingTime.ToUniversalTime() < DateTime.UtcNow)
            {
                return false;
            }

            if (client.Patients.Count(x => x.Id == patientId) == 0)
            {
                return false;
            }

            return true;
        }

        public bool CancelBooking(Guid clientId, DateTime bookingTime)
        {
            bool cancelSuccess = false;
            var valueFound = Bookings.TryGetValue(bookingTime, out var bookingDetail);

            if (valueFound == false)
            {
                cancelSuccess = false;
            }
            else
            {
                if (bookingDetail==null || bookingDetail.ClientId != clientId)
                {
                    cancelSuccess = false;
                }
                else
                {
                    cancelSuccess = Bookings.Remove(bookingTime);
                }
            }

            return cancelSuccess;
        }

        public bool ModifyBookingTime(Client client, DateTime bookingTime, DateTime newBookingTime)
        {
            bool isModifyBookingSuccess = false;
            isModifyBookingSuccess = Bookings.TryGetValue(bookingTime, out var bookingDetail);

            if (isModifyBookingSuccess == false || bookingDetail == null)
            {
                return isModifyBookingSuccess;
            }

            isModifyBookingSuccess = CancelBooking(bookingDetail.ClientId, bookingTime);

            if (isModifyBookingSuccess == false) { return isModifyBookingSuccess; }

            isModifyBookingSuccess = BookHour(client, bookingDetail.PatientId, newBookingTime);

            if (isModifyBookingSuccess == false) { return isModifyBookingSuccess; }

            return isModifyBookingSuccess;
        }
    }
}
