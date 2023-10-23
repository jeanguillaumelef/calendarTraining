namespace Domain.Object
{
    public class BookingDetails
    {
        public required Guid BookingId { get; set; }
        public required Guid ClientId { get; set; }
        public required Guid PatientId { get; set;}
    }
}
