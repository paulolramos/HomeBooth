using System;
namespace HomeBooth.Data.Models
{
    public class StudioSchedule
    {
        public int Id { get; set; }
        public int StudioId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
