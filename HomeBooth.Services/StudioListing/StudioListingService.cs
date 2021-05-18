using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeBooth.Services
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
            try
            {
                _db.Studios.Add(listing);
                _db.SaveChanges();

                return new ServiceResponse<Studio>
                {
                    Data = listing,
                    IsSuccess = true,
                    Message = $"Successfully created studio {listing.Id} to database",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Studio>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Studio> DeleteListing(int id)
        {
            try
            {
                var studio = _db.Studios.Find(id);
                if (studio is not null)
                {
                    _db.Studios.Remove(studio);
                    _db.SaveChanges();

                    return new ServiceResponse<Studio>
                    {
                        Data = studio,
                        IsSuccess = true,
                        Message = $"Studio Listing {studio.Id} successfully deleted.",
                        Time = DateTime.UtcNow
                    };
                }
                else
                {
                    return new ServiceResponse<Studio>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Unable to find Studio Listing",
                        Time = DateTime.UtcNow
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Studio>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<List<Studio>> GetAllAvailableListings()
        {
            try
            {
                var studios = (from s in _db.Studios
                               where s.IsBooked == false
                               select s).ToList();

                return new ServiceResponse<List<Studio>>
                {
                    Data = studios,
                    IsSuccess = true,
                    Message = "Available studios successfully retrieved.",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Studio>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<List<Studio>> GetAllListings()
        {
            try
            {
                var studios = (from s in _db.Studios
                               .Include(s => s.Address)
                               select s
                               ).ToList();

                if (studios.Count == 0)
                {
                    return new ServiceResponse<List<Studio>>
                    {
                        Data = studios,
                        IsSuccess = true,
                        Message = "No studios found.",
                        Time = DateTime.UtcNow
                    };
                }

                return new ServiceResponse<List<Studio>>
                {
                    Data = studios,
                    IsSuccess = true,
                    Message = "Studios successfully retrieved.",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Studio>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Studio> GetListingById(int id)
        {
            try
            {
                var studio = _db.Studios.Find(id);

                if (studio is not null)
                {
                    return new ServiceResponse<Studio>
                    {
                        Data = studio,
                        IsSuccess = true,
                        Message = $"Successfully retrieved studio {studio.Id} from database",
                        Time = DateTime.UtcNow
                    };
                }
                else
                {
                    return new ServiceResponse<Studio>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to find studio",
                        Time = DateTime.UtcNow
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Studio>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Studio> UpdateListing(int id, Studio listing)
        {
            try
            {
                var studio = _db.Studios.Find(id);

                if (studio is not null)
                {
                    _db.Studios.Update(listing);
                    _db.SaveChanges();

                    return new ServiceResponse<Studio>
                    {
                        Data = studio,
                        IsSuccess = true,
                        Message = $"Successfully updated studio {studio.Id}.",
                        Time = DateTime.UtcNow
                    };
                }
                else
                {
                    return new ServiceResponse<Studio>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to find studio",
                        Time = DateTime.UtcNow
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Studio>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
