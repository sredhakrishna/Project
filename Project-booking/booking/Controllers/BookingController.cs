using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using booking.Models;
using booking.Services;

namespace booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBookingService productService;

        public ProductController(IBookingService _productService)
        {
            productService = _productService;
        }

        [HttpGet("user")]
        [Authorize(Roles = "user, admin")] // Both users and admins can access this endpoint
        public IEnumerable<Booking> ProductListForUser()
        {
            var productList = productService.GetBookingtList();
            return productList;
        }

        [HttpGet("admin")]
        [Authorize(Roles = "admin")] // Only admins can access this endpoint
        public IEnumerable<Booking> ProductListForAdmin()
        {
            var productList = productService.GetBookingtList();
            return productList;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")] // Both users and admins can access this endpoint
        public Booking GetBookingById(int id)
        {
            return productService.GetBookingById(id);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]  Only admins can access this endpoint
        public Booking AddBooking(Booking product)
        {
            return productService.AddBooking(product);
        }

        [HttpPut]
        [Authorize(Roles = "admin")] // Only admins can access this endpoint
        public Booking UpdateBooking(Booking product)
        {
            return productService.UpdateBooking(product);
        }

        [HttpDelete("{id}")]
       // [Authorize(Roles = "admin")] Only admins can access this endpoint
        public bool DeleteBooking(int id)
        {
            return productService.DeleteBooking(id);
        }
    }
}
