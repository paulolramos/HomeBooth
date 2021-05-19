using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;
using Microsoft.EntityFrameworkCore;

namespace HomeBooth.Services
{
    public class HostService : IHostService
    {
        private readonly IMapper _mapper;
        private readonly HomeBoothDbContext _db;

        public HostService(IMapper mapper, HomeBoothDbContext context)
        {
            _mapper = mapper;
            _db = context;
        }

        public ServiceResponse<ApplicationUserDto> CreateHost(Host host)
        {
            try
            {
                host.CreatedOn = DateTime.UtcNow;
                _db.Hosts.Add(host);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(host),
                    IsSuccess = true,
                    Message = $"Successfully add host {host.Id} to database",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<ApplicationUserDto> DeleteHost(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.Hosts.Find(id);

                if (host == null)
                {
                    return new ServiceResponse<ApplicationUserDto>
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

                    return new ServiceResponse<ApplicationUserDto>
                    {
                        Data = _mapper.Map<ApplicationUserDto>(host),
                        IsSuccess = true,
                        Message = $"Successfully deleted host {id}",
                        Time = now
                    };

                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<List<ApplicationUserDto>> GetAllHosts()
        {
            try
            {
                var hosts = _db.Hosts.AsNoTracking().ToList();
                return new ServiceResponse<List<ApplicationUserDto>>
                {
                    Data = _mapper.Map<List<ApplicationUserDto>>(hosts),
                    IsSuccess = true,
                    Message = "successfully retrieved all hosts",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<ApplicationUserDto>>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<ApplicationUserDto> GetHostById(string id)
        {
            var now = DateTime.UtcNow;
            try
            {
                var host = _db.Hosts.Find(id);
                if (host == null)
                {
                    return new ServiceResponse<ApplicationUserDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"Unable to locate host {id}",
                        Time = now
                    };
                }
                else
                {
                    return new ServiceResponse<ApplicationUserDto>
                    {
                        Data = _mapper.Map<ApplicationUserDto>(host),
                        IsSuccess = true,
                        Message = $"Successfully located host {host.Id}",
                        Time = now
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = now
                };
            }
        }

        public ServiceResponse<ApplicationUserDto> UpdateHost(Host host)
        {
            try
            {
                _db.Update(host);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(host),
                    IsSuccess = true,
                    Message = $"Successfully updated host {host.Id}",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
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
