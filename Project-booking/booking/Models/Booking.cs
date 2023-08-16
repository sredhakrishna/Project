namespace booking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Description { get; set; }
        public float weight { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public float Amount{ get; set; }
    }
}
