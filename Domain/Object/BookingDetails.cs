namespace Domain.Object
{
    public class BookingDetails
    {
        public required Guid ClientId { get; set; }
        public required Patient Patient { get; set;}
    }
}
