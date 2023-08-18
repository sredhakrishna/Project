using System.ComponentModel.DataAnnotations;

namespace ParcelProject.Model
{
    public class AdminUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //[Required]
        //public string Role { get; set; }
        
    }
}
