using AutoMapper;
using MarsRover.Pilot.API.Application.DTOs;
using MarsRover.Pilot.API.Application.Interfaces.Manager;
using MarsRover.Pilot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Pilot.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly ILogger<PositionController> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;

        public PositionController(ILogger<PositionController> logger,
                                  IMapper mapper,
                                  IServiceManager serviceManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
        }

        [HttpGet(Name = "GetCurrentPosition")]
        public IActionResult Get()
        {
            try
            {
                PositionDto dto = _serviceManager.PositionService.GetCurrentPosition();
                PositionModel model = _mapper.Map<PositionModel>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}