using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.StudioListing;
using Xunit;

namespace HomeBooth.Test.Services
{
    public class StudioListingServiceTest
    {
        private readonly Studio studio = new()
        {
            CreatedOn = DateTime.UtcNow,
            Name = "The Hive",
            Host = new Host
            {
                CreatedOn = DateTime.UtcNow,
                Email = "test@email.com",
                FirstName = "Basil",
                LastName = "Pilsner",
                PhoneNumber = "XXX-XXX-XXX",
            },
            Address = new StudioAddress
            {
                AddressLine1 = "",
                AddressLine2 = "",
                City = "",
                State = "",
                PostalCode = "",
                Country = "",
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
                    Name = "",
                    ItemType = "",
                    Condition = "",
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

        [Fact]
        public void CreateListing()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);
            var response = _studioListingService.CreateListing(studio);

            Assert.IsType<ServiceResponse<Studio>>(response);
            Assert.Equal("The Hive", response.Data.Name);
            Assert.Equal("We are the best studio", response.Data.Description);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void DeleteListing()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);

            _studioListingService.CreateListing(this.studio);
            var response = _studioListingService.DeleteListing(this.studio.Id);
            Assert.IsType<ServiceResponse<Studio>>(response);
            Assert.IsType<Studio>(response.Data);
            Assert.True(response.IsSuccess);

            var studios = _context.Studios.ToList();
            Assert.Empty(studios);
        }

        [Fact]
        public void GetAllAvailableListings()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);

            _studioListingService.CreateListing(this.studio);
            var response = _studioListingService.GetAllAvailableListings();

            Assert.IsType<ServiceResponse<List<Studio>>>(response);
            Assert.IsType<List<Studio>>(response.Data);
            Assert.Single(response.Data);
            Assert.False(response.Data[0].IsBooked);
        }

        [Fact]
        public void GetAllListings()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);

            _studioListingService.CreateListing(this.studio);
            var response = _studioListingService.GetAllListings();

            Assert.IsType<ServiceResponse<List<Studio>>>(response);
            Assert.IsType<List<Studio>>(response.Data);
            Assert.Single(response.Data);
        }

        [Fact]
        public void GetListingById()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);

            _studioListingService.CreateListing(this.studio);

            var response = _studioListingService.GetListingById(this.studio.Id);
            Assert.IsType<ServiceResponse<Studio>>(response);
            Assert.IsType<Studio>(response.Data);
            Assert.Equal(response.Data.Id, this.studio.Id);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void UpdateListing()
        {
            using var _context = TestContext.GetContext();
            var _studioListingService = new StudioListingService(_context);

            var createdStudioResponse = _studioListingService.CreateListing(this.studio);
            var updatedStudio = createdStudioResponse.Data;
            updatedStudio.Name = "Basil's Place";

            var response = _studioListingService.UpdateListing(this.studio.Id, updatedStudio);
            Assert.IsType<ServiceResponse<Studio>>(response);
            Assert.IsType<Studio>(response.Data);
            Assert.Equal("Basil's Place", response.Data.Name);
            Assert.NotEqual("The Hive", response.Data.Name);
            Assert.True(response.IsSuccess);
        }
    }
}
