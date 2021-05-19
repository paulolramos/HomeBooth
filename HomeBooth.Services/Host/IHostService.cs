using System;
using System.Collections.Generic;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;

namespace HomeBooth.Services
{
    public interface IHostService
    {
        ServiceResponse<List<ApplicationUserDto>> GetAllHosts();
        ServiceResponse<ApplicationUserDto> GetHostById(string id);
        ServiceResponse<ApplicationUserDto> CreateHost(Host host);
        ServiceResponse<ApplicationUserDto> UpdateHost(Host host);
        ServiceResponse<ApplicationUserDto> DeleteHost(string id);
    }
}
