using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeBooth.Services
{
    public class HostService : IHostService
    {
        private readonly HomeBoothDbContext _db;

        public HostService(HomeBoothDbContext context)
        {
            _db = context;
        }

        public ServiceResponse<Data.Models.Host> CreateHost(Data.Models.Host host)
        {
            try
            {
                host.CreatedOn = DateTime.UtcNow;
                _db.Hosts.Add(host);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Host>
                {
                    Data = host,
                    IsSuccess = true,
                    Message = $"Successfully add host {host.Id} to database",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Host>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Data.Models.Host> DeleteHost(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.Hosts.Find(id);

                if (host == null)
                {
                    return new ServiceResponse<Data.Models.Host>
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

                    return new ServiceResponse<Data.Models.Host>
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
                return new ServiceResponse<Data.Models.Host>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<List<Data.Models.Host>> GetAllHosts()
        {
            try
            {
                var hosts = _db.Hosts.AsNoTracking().ToList();
                return new ServiceResponse<List<Data.Models.Host>>
                {
                    Data = hosts,
                    IsSuccess = true,
                    Message = "successfully retrieved all hosts",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<Data.Models.Host>>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<Data.Models.Host> GetHostById(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.Hosts.Find(id);
                if (host == null)
                {
                    return new ServiceResponse<Data.Models.Host>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to locate host {id}",
                        Time = now
                    };
                }
                else
                {
                    return new ServiceResponse<Data.Models.Host>
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
                return new ServiceResponse<Data.Models.Host>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<Data.Models.Host> UpdateHost(Data.Models.Host host)
        {
            try
            {
                _db.Update(host);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Host>
                {
                    Data = host,
                    IsSuccess = true,
                    Message = $"Successfully updated host {host.Id}",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Host>
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
