using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Services.DTO
{
    public class CreateUpdateStudioDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Rate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsBooked { get; set; }
    }
}
