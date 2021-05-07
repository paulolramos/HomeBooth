﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class Studio
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public StudioOwner Owner { get; set; }
        public StudioAddress Address { get; set; }
        public float Rate { get; set; }
        public string Description { get; set; }
        public List<StudioSchedule> Schedules { get; set; }
        public List<StudioItem> Equipment { get; set; }
        public List<StudioService> Services { get; set; }
        public bool IsBooked { get; set; }
    }
}