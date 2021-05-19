using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.DTO;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HomeBooth.Test.Services
{
    public class StudioListingServiceTest
    {
        [Fact]
        public void CreateListing()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var newStudio = new Studio { Name = "Chaos Records", Description = "The crazy studio" };
            var response = _studioListingService.CreateListing(newStudio);

            Assert.IsType<ServiceResponse<StudioListingDto>>(response);
            Assert.Equal("Chaos Records", response.Data.Name);
            Assert.Equal("The crazy studio", response.Data.Description);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void DeleteListing()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var response = _studioListingService.DeleteListing(2);
            Assert.IsType<ServiceResponse<StudioListingDto>>(response);
            Assert.IsType<StudioListingDto>(response.Data);
            Assert.True(response.IsSuccess);

            var studios = _context.Studios.ToList();
            Assert.Empty(studios);
        }

        [Fact]
        public void GetAllAvailableListings()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var response = _studioListingService.GetAllAvailableListings();

            Assert.IsType<ServiceResponse<List<StudioListingDto>>>(response);
            Assert.IsType<List<StudioListingDto>>(response.Data);
            Assert.Single(response.Data);
            Assert.False(response.Data[0].IsBooked);
        }

        [Fact]
        public void GetAllListings()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var response = _studioListingService.GetAllListings();

            Assert.IsType<ServiceResponse<List<StudioListingDto>>>(response);
            Assert.IsType<List<StudioListingDto>>(response.Data);
            Assert.Single(response.Data);
        }

        [Fact]
        public void GetListingById()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var response = _studioListingService.GetListingById(2);
            Assert.IsType<ServiceResponse<StudioListingDto>>(response);
            Assert.IsType<StudioListingDto>(response.Data);
            Assert.Equal(2, response.Data.Id);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void UpdateListing()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _studioListingService = new StudioListingService(_context, _mapper);

            var studio = _context.Studios.Find(2);
            studio.Name = "Basil's Place";

            var response = _studioListingService.UpdateListing(2, studio);
            Assert.IsType<ServiceResponse<StudioListingDto>>(response);
            Assert.IsType<StudioListingDto>(response.Data);
            Assert.Equal("Basil's Place", response.Data.Name);
            Assert.NotEqual("The Hive", response.Data.Name);
            Assert.True(response.IsSuccess);
        }
    }
}
