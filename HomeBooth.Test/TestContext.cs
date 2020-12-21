using System;
using HomeBooth.Data;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HomeBooth.Test
{
    public class TestContext
    {
        public static HomeBoothDbContext GetContext()
        {
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions { });
            var builderOptions = new DbContextOptionsBuilder<HomeBoothDbContext>()
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new HomeBoothDbContext(builderOptions, operationalStoreOptions);
        }
    }

}
