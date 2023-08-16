using booking.Models;

namespace booking.Services
{
   
        public interface IBookingService
        {
            public IEnumerable<Booking> GetBookingtList();
            public Booking GetBookingById(int id);
            public Booking AddBooking(Booking product);
            public Booking UpdateBooking(Booking product);
            public bool DeleteBooking(int Id);
        }
    
}
