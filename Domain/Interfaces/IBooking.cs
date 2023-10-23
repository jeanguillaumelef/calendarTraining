using Domain.Object;

namespace Domain.Interfaces
{
    public interface IBooking
    {
        bool BookHour(Client client, Patient patient, DateTime bookingTime);
        bool CancelBooking(Guid id, DateTime bookingTime);
    }
}