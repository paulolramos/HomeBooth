using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.Client;
using Xunit;

namespace HomeBooth.Test.ServiceTests
{
    public class ClientServiceTest
    {
        private readonly Client testClient = new Client
        {
            CreatedOn = DateTime.UtcNow,
            Email = "test@email.com",
            FirstName = "Basil",
            LastName = "Pilsner",
            PhoneNumber = "XXX-XXX-XXXX",
        };

        private readonly List<Client> testClients = new List<Client>
        {
            new Client
            {
                CreatedOn = DateTime.UtcNow,
                Email = "test@email.com",
                FirstName = "Basil",
                LastName = "Pilsner",
                PhoneNumber = "XXX-XXX-XXXX",
            },
            new Client
            {
                CreatedOn = DateTime.UtcNow,
                Email = "test2@email.com",
                FirstName = "Fatboi",
                LastName = "Pilsner",
                PhoneNumber = "XXX-XXX-XXXX",
            },
        };

        [Fact]
        public void ShouldCreateClient()
        {
            using var _context = TestContext.GetContext();
            var _clientService = new ClientService(_context);

            var response = _clientService.CreateClient(testClient);
            Assert.IsType<ServiceResponse<Client>>(response);
            Assert.Equal("Basil", response.Data.FirstName);
            Assert.Equal("Pilsner", response.Data.LastName);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldDeleteClient()
        {
            using var _context = TestContext.GetContext();
            var _clientService = new ClientService(_context);

            _clientService.CreateClient(testClient);
            var response = _clientService.DeleteClient(testClient.Id);
            Assert.IsType<ServiceResponse<bool>>(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(0, _context.Clients.Count());
        }

        [Fact]
        public void ShouldGetAllClients()
        {
            using var _context = TestContext.GetContext();
            var _clientService = new ClientService(_context);

            foreach (var client in testClients)
            {
                _clientService.CreateClient(client);
            }

            var response = _clientService.GetAllClients();
            Assert.IsType<ServiceResponse<List<Client>>>(response);
            Assert.True(response.IsSuccess);
            Assert.Equal(2, _context.Clients.Count());
        }

        [Fact]
        public void ShouldGetClientById()
        {
            using var _context = TestContext.GetContext();
            var _clientService = new ClientService(_context);

            var response = _clientService.CreateClient(testClient);
            var client = _clientService.GetClientById(response.Data.Id);

            Assert.IsType<ServiceResponse<Client>>(client);
            Assert.Equal("Basil", response.Data.FirstName);
            Assert.Equal("Pilsner", response.Data.LastName);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldUpdateClient()
        {
            using var _context = TestContext.GetContext();
            var _clientService = new ClientService(_context);

            var response = _clientService.CreateClient(testClient);
            var createdClient = response.Data;
            createdClient.FirstName = "Rudy";
            var updateResponse = _clientService.UpdateClient(createdClient);

            Assert.IsType<ServiceResponse<Client>>(updateResponse);
            Assert.True(updateResponse.IsSuccess);
            Assert.Equal("Rudy", updateResponse.Data.FirstName);
            Assert.Equal("Pilsner", updateResponse.Data.LastName);
        }
    }
}
