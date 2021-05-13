using System;
using System.Collections.Generic;
using System.Linq;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.Host;
using Xunit;

namespace HomeBooth.Test.Services
{
    public class HostServiceTest
    {
        private readonly Host host = new Host
        {
            CreatedOn = DateTime.UtcNow,
            Email = "roger@email.com",
            FirstName = "Roger",
            LastName = "Waters",
            PhoneNumber = "XXX-XXX-XXX"
        };

        private readonly List<Host> hosts = new List<Host>
        {
            new Host
            {
                CreatedOn = DateTime.UtcNow,
                Email = "roger@email.com",
                FirstName = "Roger",
                LastName = "Waters",
                PhoneNumber = "XXX-XXX-XXX"
            },
            new Host
            {
                CreatedOn = DateTime.UtcNow,
                Email = "david@email.com",
                FirstName = "David",
                LastName = "Gilmour",
                PhoneNumber = "XXX-XXX-XXX"
            },
        };

        [Fact]
        public void ShouldGetAllHosts()
        {
            using var _context = TestContext.GetContext();
            var _hostService = new HostService(_context);

            foreach (var host in hosts)
            {
                _hostService.CreateHost(host);
            }
            var response = _hostService.GetAllHosts();

            Assert.IsType<ServiceResponse<List<Host>>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal(2, response.Data.Count);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldGetHostById()
        {
            using var _context = TestContext.GetContext();
            var _hostService = new HostService(_context);

            var createdHost = _hostService.CreateHost(host);

            var response = _hostService.GetHostById(createdHost.Data.Id);
            Assert.IsType<ServiceResponse<Host>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Roger", response.Data.FirstName);
        }

        [Fact]
        public void ShouldCreateHost()
        {
            using var _context = TestContext.GetContext();
            var _hostService = new HostService(_context);

            var response = _hostService.CreateHost(host);

            Assert.True(response.Data.IsHost);
            Assert.IsType<ServiceResponse<Host>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Roger", response.Data.FirstName);
        }

        [Fact]
        public void ShouldUpdateHost()
        {
            using var _context = TestContext.GetContext();
            var _hostService = new HostService(_context);

            var hostResponse = _hostService.CreateHost(host);

            // Update
            hostResponse.Data.FirstName = "Richard";
            hostResponse.Data.LastName = "Wright";
            var updatedHost = hostResponse.Data;
            var response = _hostService.UpdateHost(updatedHost);

            Assert.IsType<ServiceResponse<Host>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Richard", response.Data.FirstName);
            Assert.Equal("Wright", response.Data.LastName);
        }

        [Fact]
        public void ShouldDeleteHost()
        {
            using var _context = TestContext.GetContext();
            var _hostService = new HostService(_context);

            foreach (var host in hosts)
            {
                _hostService.CreateHost(host);
            }

            var allHosts = _hostService.GetAllHosts();
            var firstHost = allHosts.Data[0];

            var response = _hostService.DeleteHost(firstHost.Id);
            Assert.IsType<ServiceResponse<Host>>(response);
            // ensure there's only 1 item now
            Assert.Single(_hostService.GetAllHosts().Data);
            Assert.NotNull(response.Data);
            Assert.Equal("Roger", response.Data.FirstName);
        }
    }
}
