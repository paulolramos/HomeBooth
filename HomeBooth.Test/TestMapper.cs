using System;
using AutoMapper;
using HomeBooth.Data.Models;
using HomeBooth.Services;
using HomeBooth.Services.DTO;

namespace HomeBooth.Test
{
    public class TestMapper
    {
        public static IMapper GetTestMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapping>());
            return new Mapper(config);
        }
    }
}
