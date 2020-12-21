using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class StudioOwner
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
