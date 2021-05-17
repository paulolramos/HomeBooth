﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float Price { get; set; }
        public string Comment { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancelled { get; set; }

        [MaxLength(32)]
        public string ClientContact { get; set; }

        [MaxLength(32)]
        public string StudioContact { get; set; }


        public string ClientId { get; set; }
        public Client Client { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }

        public int StudioServiceId { get; set; }
        public StudioService StudioService { get; set; }

    }
}
