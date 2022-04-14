using Microsoft.AspNetCore.Identity;

namespace hmrc_booking_system_backend.Models
{
    public class UserInfo
    {
        public int id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}