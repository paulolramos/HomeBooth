using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class StudioOwner : ApplicationUser
    {
        public bool IsStudioOwner = true;
    }
}
