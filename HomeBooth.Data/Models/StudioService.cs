using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class StudioService
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public float AdditionalCost { get; set; }
    }
}
