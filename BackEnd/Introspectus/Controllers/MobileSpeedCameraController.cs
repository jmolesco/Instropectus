using AutoMapper;
using Introspectus.Api.DTO;
using Introspectus.Api.Extentions;
using Introspectus.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Introspectus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSpeedCameraController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<MobileSpeedCameraController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMobileSpeedCameraService _mobileSpeedCameraService;
        public MobileSpeedCameraController(ILogger<MobileSpeedCameraController> logger, IConfiguration configuration, IMapper mapper
            , IMobileSpeedCameraService mobileSpeedCameraService)
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _mobileSpeedCameraService = mobileSpeedCameraService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchCameraSpeedResponse([FromBody] SearchMobileSpeedCameraRequest dtoModel)
        {
            var result = await _mobileSpeedCameraService.SearchMobileSpeedCameraList(dtoModel);
            return result.Pipe(res => Ok(res));
        }

        [HttpGet("grouppostedspeed")]
        public async Task<IActionResult> GetGroupPostedBy()
        {
            var result = await _mobileSpeedCameraService.GetGroupPostedSpeed();
            return result.Pipe(res => Ok(res));
        }
    }
}
