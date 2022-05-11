using AutoMapper;
using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Models;

namespace MarsRover.Pilot.API.Mapper
{
    public class RoverProfile : Profile
    {
        public RoverProfile()
        {
            CreateMap<CommandDto, CommandModel>().ReverseMap();
            CreateMap<PositionDto, PositionModel>().ReverseMap();
        }
    }
}