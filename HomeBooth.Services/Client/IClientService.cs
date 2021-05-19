using System;
using System.Collections.Generic;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;

namespace HomeBooth.Services
{
    public interface IClientService
    {
        ServiceResponse<List<ApplicationUserDto>> GetAllClients();
        ServiceResponse<ApplicationUserDto> GetClientById(string id);
        ServiceResponse<ApplicationUserDto> CreateClient(Client client);
        ServiceResponse<ApplicationUserDto> UpdateClient(Client client);
        ServiceResponse<bool> DeleteClient(string id);
    }
}
