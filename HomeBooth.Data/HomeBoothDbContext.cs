using HomeBooth.Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HomeBooth.Data
{
    public class HomeBoothDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public HomeBoothDbContext(
            DbContextOptions<HomeBoothDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<StudioAddress> StudioAddresses { get; set; }
        public DbSet<StudioItem> StudioItems { get; set; }
        public DbSet<StudioOwner> StudioOwners { get; set; }
        public DbSet<StudioSchedule> StudioSchedules { get; set; }
        public DbSet<StudioService> StudioServices { get; set; }
    }
}
