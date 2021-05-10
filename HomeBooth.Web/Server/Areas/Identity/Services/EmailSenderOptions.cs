using System;
namespace HomeBooth.Web.Server.Areas.Identity.Services
{
    public class EmailSenderOptions
    {
        public const string EmailSender = "EmailSender";

        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
