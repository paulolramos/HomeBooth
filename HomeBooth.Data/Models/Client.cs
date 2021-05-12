using System;
using System.ComponentModel.DataAnnotations;

namespace HomeBooth.Data.Models
{
    public class Client : ApplicationUser
    {
        public bool IsClient = true;
    }
}
