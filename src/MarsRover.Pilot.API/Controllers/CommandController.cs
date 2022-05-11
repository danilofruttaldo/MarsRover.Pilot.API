using AutoMapper;
using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Application.Exceptions;
using MarsRover.Pilot.API.Application.Interfaces.Manager;
using MarsRover.Pilot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Pilot.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;

        public CommandController(ILogger<CommandController> logger,
                                 IMapper mapper,
                                 IServiceManager serviceManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
        }

        [HttpPost(Name = "PostRoverCommands")]
        public async Task<IActionResult> Post(CommandModel model)
        {
            try
            {
                CommandDto dto = _mapper.Map<CommandDto>(model);
                await _serviceManager.DriverService.MoveToAsync(dto);

                return Ok();
            }
            catch (CollisionException ex)
            {
                await _serviceManager.PositionService.SaveCurrentPositionAsync(ex.Position);

                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
