using System;
using System.Collections.Generic;
using HomeBooth.Data;
using HomeBooth.Data.Models;

namespace HomeBooth.Services.StudioListing
{
    public class StudioListingService : IStudioListingService
    {
        private readonly HomeBoothDbContext _db;
        public StudioListingService(HomeBoothDbContext homeBoothDbContext)
        {
            _db = homeBoothDbContext;
        }

        public ServiceResponse<Studio> CreateListing(Studio listing)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Studio> DeleteListing(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Studio>> GetAllAvailableListings()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Studio>> GetAllListings()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Studio> GetListingById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Studio> UpdateListing(int id, Studio listing)
        {
            throw new NotImplementedException();
        }
    }
}
