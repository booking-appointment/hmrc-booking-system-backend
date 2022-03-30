using Microsoft.AspNetCore.Identity;

namespace hmrc_booking_system_backend.Models
{
    public class Note
    {
        public int id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


    }
}