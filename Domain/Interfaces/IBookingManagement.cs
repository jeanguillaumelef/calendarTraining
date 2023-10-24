using Domain.Object;

namespace Domain.Interfaces
{
    public interface IBookingManagement
    {
        bool BookHour(Client client, Guid patientId, DateTime bookingTime);
        bool CancelBooking(Guid id, DateTime bookingTime);
    }
}