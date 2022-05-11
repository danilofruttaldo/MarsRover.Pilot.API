using AutoMapper;
using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Core.Entities;

namespace MarsRover.Pilot.API.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<RoverDtoMapper>();
            });
            IMapper mapper = config.CreateMapper();

            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class RoverDtoMapper : Profile
    {
        public RoverDtoMapper()
        {
            CreateMap<PositionDto, Position>().ReverseMap();
        }
    }
}
