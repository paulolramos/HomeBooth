using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.DTO;
using Xunit;

namespace HomeBooth.Test.Services
{
    public class ClientServiceTest
    {
        [Fact]
        public void ShouldCreateClient()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _clientService = new ClientService(_mapper, _context);

            var newClient = new Client
            {
                CreatedOn = DateTime.UtcNow,
                Email = "test@gmail.com",
                FirstName = "Rudy",
                LastName = "Pilsner",
                PhoneNumber = "424-757-8007",
            };

            var response = _clientService.CreateClient(newClient);

            Assert.IsType<ServiceResponse<HomeBooth.Services.DTO.ApplicationUserDto>>(response);
            Assert.Equal("Rudy", response.Data.FirstName);
            Assert.Equal("Pilsner", response.Data.LastName);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldDeleteClient()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _clientService = new ClientService(_mapper, _context);

            var response = _clientService.DeleteClient("id1");

            Assert.IsType<ServiceResponse<bool>>(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(1, _context.Clients.Count());
        }

        [Fact]
        public void ShouldGetAllClients()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _clientService = new ClientService(_mapper, _context);

            var response = _clientService.GetAllClients();

            Assert.IsType<ServiceResponse<List<HomeBooth.Services.DTO.ApplicationUserDto>>>(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(2, _context.Clients.Count());
        }

        [Fact]
        public void ShouldGetClientById()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _clientService = new ClientService(_mapper, _context);

            var client = _clientService.GetClientById("id2");

            Assert.IsType<ServiceResponse<HomeBooth.Services.DTO.ApplicationUserDto>>(client);
            Assert.Equal("Fatboi", client.Data.FirstName);
            Assert.Equal("Pilsner", client.Data.LastName);
            Assert.True(client.IsSuccess);
        }

        [Fact]
        public void ShouldUpdateClient()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _clientService = new ClientService(_mapper, _context);

            var client = _context.Clients.Find("id1");

            client.FirstName = "Rudy";
            var updateResponse = _clientService.UpdateClient(client);

            Assert.IsType<ServiceResponse<HomeBooth.Services.DTO.ApplicationUserDto>>(updateResponse);
            Assert.True(updateResponse.IsSuccess);
            Assert.Equal("Rudy", updateResponse.Data.FirstName);
            Assert.Equal("Pilsner", updateResponse.Data.LastName);
        }
    }
}
