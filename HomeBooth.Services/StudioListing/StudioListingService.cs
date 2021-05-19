using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;

namespace HomeBooth.Services
{
    public class StudioListingService : IStudioListingService
    {
        private readonly HomeBoothDbContext _db;
        private readonly IMapper _mapper;

        public StudioListingService(HomeBoothDbContext homeBoothDbContext, IMapper mapper)
        {
            _db = homeBoothDbContext;
            _mapper = mapper;
        }

        public ServiceResponse<StudioListingDto> CreateListing(CreateUpdateStudioDto listing)
        {
            var studio = _mapper.Map<Studio>(listing);
            studio.CreatedOn = DateTime.UtcNow;
            studio.UpdatedOn = DateTime.UtcNow;

            try
            {
                _db.Studios.Add(studio);
                _db.SaveChanges();

                return new ServiceResponse<StudioListingDto>
                {
                    Data = _mapper.Map<StudioListingDto>(studio),
                    IsSuccess = true,
                    Message = $"Successfully created studio {studio.Id} to database",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioListingDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<StudioListingDto> DeleteListing(int id)
        {
            try
            {
                var studio = _db.Studios.Find(id);
                if (studio is not null)
                {
                    _db.Studios.Remove(studio);
                    _db.SaveChanges();

                    return new ServiceResponse<StudioListingDto>
                    {
                        Data = _mapper.Map<StudioListingDto>(studio),
                        IsSuccess = true,
                        Message = $"Studio Listing {studio.Id} successfully deleted.",
                        Time = DateTime.UtcNow
                    };
                }
                else
                {
                    return new ServiceResponse<StudioListingDto>
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
                return new ServiceResponse<StudioListingDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<List<StudioListingDto>> GetAllAvailableListings()
        {
            try
            {
                var studios = (from s in _db.Studios
                               where s.IsBooked == false
                               select s).ToList();

                return new ServiceResponse<List<StudioListingDto>>
                {
                    Data = _mapper.Map<List<StudioListingDto>>(studios),
                    IsSuccess = true,
                    Message = "Available studios successfully retrieved.",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<StudioListingDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<List<StudioListingDto>> GetAllListings()
        {
            try
            {
                var studios = (from s in _db.Studios
                               .Include(s => s.Address)
                               select s
                               ).ToList();

                if (studios.Count == 0)
                {
                    return new ServiceResponse<List<StudioListingDto>>
                    {
                        Data = _mapper.Map<List<StudioListingDto>>(studios),
                        IsSuccess = true,
                        Message = "No studios found.",
                        Time = DateTime.UtcNow
                    };
                }

                return new ServiceResponse<List<StudioListingDto>>
                {
                    Data = _mapper.Map<List<StudioListingDto>>(studios),
                    IsSuccess = true,
                    Message = "Studios successfully retrieved.",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<StudioListingDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<StudioListingDto> GetListingById(int id)
        {
            try
            {
                var studio = _db.Studios.Find(id);

                if (studio is not null)
                {
                    return new ServiceResponse<StudioListingDto>
                    {
                        Data = _mapper.Map<StudioListingDto>(studio),
                        IsSuccess = true,
                        Message = $"Successfully retrieved studio {studio.Id} from database",
                        Time = DateTime.UtcNow
                    };
                }
                else
                {
                    return new ServiceResponse<StudioListingDto>
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
                return new ServiceResponse<StudioListingDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<StudioListingDto> UpdateListing(int id, CreateUpdateStudioDto listing)
        {
            var studio = _mapper.Map<Studio>(listing);
            studio.Id = id;

            try
            {
                _db.Studios.Update(studio);
                _db.SaveChanges();

                return new ServiceResponse<StudioListingDto>
                {
                    Data = _mapper.Map<StudioListingDto>(studio),
                    IsSuccess = true,
                    Message = $"Successfully updated studio {studio.Id}.",
                    Time = DateTime.UtcNow
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioListingDto>
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
