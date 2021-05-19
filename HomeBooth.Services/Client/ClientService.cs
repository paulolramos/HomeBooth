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
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly HomeBoothDbContext _db;

        public ClientService(IMapper mapper, HomeBoothDbContext dbContext)
        {
            _mapper = mapper;
            _db = dbContext;
        }

        /// <summary>
        /// Adds a new client to database
        /// </summary>
        /// <param name="client"></param>
        /// <returns>ServiceResponse<ApplicationUserDto></returns>
        public ServiceResponse<ApplicationUserDto> CreateClient(Client client)
        {
            try
            {
                client.CreatedOn = DateTime.UtcNow;
                _db.Clients.Add(client);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(client),
                    IsSuccess = true,
                    Message = $"client {client.Id} has been created",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(client),
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Deletes client from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteClient(string id)
        {
            var time = DateTime.UtcNow;
            var client = _db.Clients.Find(id);

            if (client == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Unable to find client",
                    Time = time
                };
            }
            else
            {
                try
                {
                    _db.Clients.Remove(client);
                    _db.SaveChanges();

                    return new ServiceResponse<bool>
                    {
                        Data = true,
                        IsSuccess = true,
                        Message = $"Deleted {client.Id} from database",
                        Time = time
                    };
                }
                catch (Exception ex)
                {
                    return new ServiceResponse<bool>
                    {
                        Data = false,
                        IsSuccess = false,
                        Message = ex.Message,
                        Time = time
                    };
                }
            }
        }

        /// <summary>
        /// Gets all clients from database
        /// </summary>
        /// <returns>ServiceResponse<List<ApplicationUserDto>></returns>
        public ServiceResponse<List<ApplicationUserDto>> GetAllClients()
        {
            try
            {
                var clients = _db.Clients
                    .OrderBy(client => client.LastName)
                    .AsNoTracking()
                    .ToList();

                return new ServiceResponse<List<ApplicationUserDto>>
                {
                    Data = _mapper.Map<List<ApplicationUserDto>>(clients),
                    IsSuccess = true,
                    Message = "All clients retrieved",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<ApplicationUserDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Gets client by Id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResponse<ApplicationUserDto></returns>
        public ServiceResponse<ApplicationUserDto> GetClientById(string id)
        {
            try
            {
                var client = _db.Clients.Find(id);

                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(client),
                    IsSuccess = true,
                    Message = $"Successfully retrieved client {client.Id}",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Update client in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns>ServiceResponse<ApplicationUserDto></returns>
        public ServiceResponse<ApplicationUserDto> UpdateClient(Client client)
        {
            try
            {
                _db.Clients.Update(client);
                _db.SaveChanges();

                return new ServiceResponse<ApplicationUserDto>
                {
                    Data = _mapper.Map<ApplicationUserDto>(client),
                    IsSuccess = true,
                    Message = $"Successfully updated client {client.Id}",
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
