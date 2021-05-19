using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeBooth.Services.DTO
{
    public class StudioListingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public float Rate { get; set; }
        public string Description { get; set; }
        public bool IsBooked { get; set; }
    }
}
