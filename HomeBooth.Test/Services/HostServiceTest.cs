using System.Collections.Generic;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.DTO;
using Xunit;

namespace HomeBooth.Test.Services
{
    public class HostServiceTest
    {
        [Fact]
        public void ShouldGetAllHosts()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _hostService = new HostService(_mapper, _context);

            var response = _hostService.GetAllHosts();

            Assert.IsType<ServiceResponse<List<ApplicationUserDto>>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal(2, response.Data.Count);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldGetHostById()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _hostService = new HostService(_mapper, _context);

            var response = _hostService.GetHostById("1");
            Assert.IsType<ServiceResponse<ApplicationUserDto>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Roger", response.Data.FirstName);
        }

        [Fact]
        public void ShouldCreateHost()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _hostService = new HostService(_mapper, _context);

            var newHost = new Host { Id = "3", FirstName = "Richard" };

            var response = _hostService.CreateHost(newHost);

            Assert.IsType<ServiceResponse<ApplicationUserDto>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Richard", response.Data.FirstName);
        }

        [Fact]
        public void ShouldUpdateHost()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _hostService = new HostService(_mapper, _context);

            var host = _context.Hosts.Find("1");

            // Update
            host.FirstName = "Richard";
            host.LastName = "Wright";

            var response = _hostService.UpdateHost(host);

            Assert.IsType<ServiceResponse<ApplicationUserDto>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Richard", response.Data.FirstName);
            Assert.Equal("Wright", response.Data.LastName);
        }

        [Fact]
        public void ShouldDeleteHost()
        {
            using var _context = TestContext.GetContext();
            var _mapper = TestMapper.GetTestMapper();
            var _hostService = new HostService(_mapper, _context);

            var response = _hostService.DeleteHost("1");
            Assert.IsType<ServiceResponse<ApplicationUserDto>>(response);
            Assert.NotNull(response.Data);
            Assert.Equal("Roger", response.Data.FirstName);
        }
    }
}
