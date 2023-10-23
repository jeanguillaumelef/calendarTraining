namespace Domain.Object
{
    public class BookingDetails
    {
        public required Client Client { get; set; }
        public required Patient Patient { get; set;}
    }
}
