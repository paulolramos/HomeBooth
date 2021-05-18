using System;
using System.Collections.Generic;

namespace HomeBooth.Services
{
    public interface IHostService
    {
        ServiceResponse<List<Data.Models.Host>> GetAllHosts();
        ServiceResponse<Data.Models.Host> GetHostById(string id);
        ServiceResponse<Data.Models.Host> CreateHost(Data.Models.Host host);
        ServiceResponse<Data.Models.Host> UpdateHost(Data.Models.Host host);
        ServiceResponse<Data.Models.Host> DeleteHost(string id);
    }
}
