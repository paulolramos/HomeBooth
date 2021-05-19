using System;
using System.Collections.Generic;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HomeBooth.Test
{
    public class TestContext
    {

        private static HomeBoothDbContext SeedTestContext(HomeBoothDbContext testContext)
        {

            List<Client> testClients = new()
            {
                new Client
                {
                    Id = "id1",
                    CreatedOn = DateTime.UtcNow,
                    Email = "test@email.com",
                    FirstName = "Basil",
                    LastName = "Pilsner",
                    PhoneNumber = "XXX-XXX-XXXX",
                },
                new Client
                {
                    Id = "id2",
                    CreatedOn = DateTime.UtcNow,
                    Email = "test2@email.com",
                    FirstName = "Fatboi",
                    LastName = "Pilsner",
                    PhoneNumber = "XXX-XXX-XXXX",
                },
            };

            List<Host> testHosts = new()
            {
                new Host
                {
                    Id = "1",
                    CreatedOn = DateTime.UtcNow,
                    Email = "roger@email.com",
                    FirstName = "Roger",
                    LastName = "Waters",
                    PhoneNumber = "XXX-XXX-XXX"
                },
                new Host
                {
                    Id = "2",
                    CreatedOn = DateTime.UtcNow,
                    Email = "david@email.com",
                    FirstName = "David",
                    LastName = "Gilmour",
                    PhoneNumber = "XXX-XXX-XXX"
                },
            };

            Studio testStudio = new()
            {
                Id = 2,
                CreatedOn = DateTime.UtcNow,
                Name = "The Hive",
                Host = testHosts[0],
                Address = new StudioAddress
                {
                    AddressLine1 = "3522 Oak Ave",
                    AddressLine2 = "",
                    City = "Nashville",
                    State = "TN",
                    PostalCode = "23428",
                    Country = "USA",
                    CreatedOn = DateTime.UtcNow,
                },
                Description = "We are the best studio",
                Services = new List<StudioService>
            {
                new StudioService
                {
                    Description ="The best producing ever",
                    ServiceName = "Mixing"
                },
                new StudioService
                {
                    Description ="The best mastering ever",
                    ServiceName = "Mastering"
                },
            },
                Rate = 20,
                StudioItems = new List<StudioItem>
            {
                new StudioItem
                {
                    Name = "SM57",
                    ItemType = "Microphone",
                    Condition = "New",
                    Quanitity = 4,
                    CreatedOn = DateTime.UtcNow,
                }
            },
                Schedules = new List<StudioSchedule>
            {
                new StudioSchedule
                {

                }
            },
                IsBooked = false,
            };

            testContext.Hosts.AddRange(testHosts);
            testContext.Clients.AddRange(testClients);
            testContext.Studios.Add(testStudio);
            testContext.SaveChanges();

            foreach (var entity in testContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            return testContext;
        }


        public static HomeBoothDbContext GetContext()
        {
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions { });
            var builderOptions = new DbContextOptionsBuilder<HomeBoothDbContext>()
                    .EnableSensitiveDataLogging()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            var testContext = new HomeBoothDbContext(builderOptions, operationalStoreOptions);
            SeedTestContext(testContext);
            return testContext;
        }

    }

}
