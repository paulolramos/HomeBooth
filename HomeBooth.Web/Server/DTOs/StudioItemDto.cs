using System;
namespace HomeBooth.Web.Server.DTOs
{
    public class StudioItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Quanitity { get; set; }
        public string ItemType { get; set; }
        public string Condition { get; set; }
    }
}
