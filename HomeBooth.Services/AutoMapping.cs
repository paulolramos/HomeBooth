using AutoMapper;
using HomeBooth.Data.Models;
using HomeBooth.Services.DTO;

namespace HomeBooth.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();

            CreateMap<Studio, StudioListingDto>();
            CreateMap<StudioListingDto, Studio>();
            CreateMap<CreateUpdateStudioDto, Studio>();

            CreateMap<StudioAddress, StudioAddressDto>();
            CreateMap<StudioItem, StudioItemDto>();
            CreateMap<StudioService, StudioServiceDto>();
            CreateMap<StudioSchedule, StudioScheduleDto>();
        }
    }
}
