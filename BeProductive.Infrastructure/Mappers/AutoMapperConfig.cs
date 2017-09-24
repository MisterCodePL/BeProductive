using AutoMapper;
using BeProductive.Core.Domain;
using BeProductive.Infrastructure.DTO;

namespace BeProductive.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Event, EventDto>();
            })
            .CreateMapper();
    }
}
