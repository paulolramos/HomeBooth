using System;
namespace HomeBooth.Web.Server.DTOs
{
    public class StudioScheduleDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
