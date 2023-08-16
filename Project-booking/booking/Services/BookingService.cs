using booking.Data;
using booking.Models;
using booking.Services;

namespace booking.Services
{
    public class BookingService : IBookingService
    {
        private readonly DBContextClass _dbContext;

        public BookingService(DBContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Booking> GetBookingtList()
        {
            return _dbContext.Bookings.ToList();
        }
        public Booking GetBookingById(int id)
        {
            return _dbContext.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
        }

        public Booking AddBooking(Booking product)
        {
            var result = _dbContext.Bookings.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Booking UpdateBooking(Booking product)
        {
            var result = _dbContext.Bookings.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteBooking(int Id)
        {
            var filteredData = _dbContext.Bookings.Where(x => x.BookingId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
