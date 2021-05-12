using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeBooth.Services.Host
{
    public class HostService : IHostService
    {
        private readonly HomeBoothDbContext _db;

        public HostService(HomeBoothDbContext context)
        {
            _db = context;
        }

        public ServiceResponse<StudioOwner> CreateHost(StudioOwner host)
        {
            try
            {
                host.CreatedOn = DateTime.UtcNow;
                _db.StudioOwners.Add(host);
                _db.SaveChanges();

                return new ServiceResponse<StudioOwner>
                {
                    Data = host,
                    IsSuccess = true,
                    Message = $"Successfully add host {host.Id} to database",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioOwner>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<StudioOwner> DeleteHost(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.StudioOwners.Find(id);

                if (host == null)
                {
                    return new ServiceResponse<StudioOwner>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to located host {id}",
                        Time = now
                    };
                }
                else
                {
                    _db.Remove(host);
                    _db.SaveChanges();

                    return new ServiceResponse<StudioOwner>
                    {
                        Data = host,
                        IsSuccess = true,
                        Message = $"Successfully deleted host {id}",
                        Time = now
                    };

                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioOwner>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<List<StudioOwner>> GetAllHosts()
        {
            try
            {
                var hosts = _db.StudioOwners.AsNoTracking().ToList();
                return new ServiceResponse<List<StudioOwner>>
                {
                    Data = hosts,
                    IsSuccess = true,
                    Message = "successfully retrieved all hosts",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<StudioOwner>>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<StudioOwner> GetHostById(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.StudioOwners.Find(id);
                if (host == null)
                {
                    return new ServiceResponse<StudioOwner>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to locate host {id}",
                        Time = now
                    };
                }
                else
                {
                    return new ServiceResponse<StudioOwner>
                    {
                        Data = host,
                        IsSuccess = true,
                        Message = $"Successfully located host {host.Id}",
                        Time = now
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioOwner>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<StudioOwner> UpdateHost(StudioOwner host)
        {
            try
            {
                _db.Update(host);
                _db.SaveChanges();

                return new ServiceResponse<StudioOwner>
                {
                    Data = host,
                    IsSuccess = true,
                    Message = $"Successfully updated host {host.Id}",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StudioOwner>
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
