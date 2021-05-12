using System;
using System.Collections.Generic;

namespace HomeBooth.Services.Client
{
    public interface IClientService
    {
        ServiceResponse<List<Data.Models.Client>> GetAllClients();
        ServiceResponse<Data.Models.Client> GetClientById(string id);
        ServiceResponse<Data.Models.Client> CreateClient(Data.Models.Client client);
        ServiceResponse<Data.Models.Client> UpdateClient(Data.Models.Client client);
        ServiceResponse<bool> DeleteClient(string id);
    }
}
