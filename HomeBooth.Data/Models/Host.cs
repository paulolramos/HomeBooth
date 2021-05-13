using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class Host : ApplicationUser
    {
        public bool IsHost = true;
    }
}
