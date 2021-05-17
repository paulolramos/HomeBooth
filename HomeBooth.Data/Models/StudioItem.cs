using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class StudioItem
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Quanitity { get; set; }
        public string ItemType { get; set; }
        public string Condition { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
