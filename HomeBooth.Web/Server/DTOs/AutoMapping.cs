using System;
using AutoMapper;
using HomeBooth.Data.Models;

namespace HomeBooth.Web.Server.DTOs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Studio, StudioListingDto>();
            CreateMap<StudioAddress, StudioAddressDto>();
            CreateMap<StudioItem, StudioItemDto>();
            CreateMap<StudioService, StudioServiceDto>();
            CreateMap<StudioSchedule, StudioScheduleDto>();
        }
    }
}
