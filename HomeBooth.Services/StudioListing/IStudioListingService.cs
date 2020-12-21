using System;
using System.Collections.Generic;

namespace HomeBooth.Services.StudioListing
{
    public interface IStudioListingService
    {
        ServiceResponse<List<Data.Models.Studio>> GetAllListings();
        ServiceResponse<List<Data.Models.Studio>> GetAllAvailableListings();
        ServiceResponse<Data.Models.Studio> GetListingById(int id);
        ServiceResponse<Data.Models.Studio> CreateListing(Data.Models.Studio listing);
        ServiceResponse<Data.Models.Studio> UpdateListing(int id, Data.Models.Studio listing);
        ServiceResponse<Data.Models.Studio> DeleteListing(int id);
    }
}
