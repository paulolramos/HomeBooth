using System.Collections.Generic;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;

namespace HomeBooth.Services
{
    public interface IStudioListingService
    {
        ServiceResponse<List<StudioListingDto>> GetAllListings();
        ServiceResponse<List<StudioListingDto>> GetAllAvailableListings();
        ServiceResponse<StudioListingDto> GetListingById(int id);
        ServiceResponse<StudioListingDto> CreateListing(CreateUpdateStudioDto listing);
        ServiceResponse<StudioListingDto> UpdateListing(int id, CreateUpdateStudioDto listing);
        ServiceResponse<StudioListingDto> DeleteListing(int id);
    }
}
