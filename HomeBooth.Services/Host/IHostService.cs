using System;
using System.Collections.Generic;

namespace HomeBooth.Services.Host
{
    public interface IHostService
    {
        ServiceResponse<List<Data.Models.StudioOwner>> GetAllHosts();
        ServiceResponse<Data.Models.StudioOwner> GetHostById(int id);
        ServiceResponse<Data.Models.StudioOwner> CreateHost(Data.Models.StudioOwner host);
        ServiceResponse<Data.Models.StudioOwner> UpdateHost(Data.Models.StudioOwner host);
        ServiceResponse<Data.Models.StudioOwner> DeleteHost(int id);
    }
}
