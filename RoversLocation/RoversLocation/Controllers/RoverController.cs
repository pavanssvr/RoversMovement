using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace RoversLocation.Controllers
{
    [Route("api/[controller]")]
    public class RoverController : Controller
    {
        private readonly IRoverMovementService _roverMovementService;

        public RoverController(IRoverMovementService roverMovementService)
        {
            _roverMovementService = roverMovementService;
        }

        [Route("GetRoversCurrentPosition")]
        [HttpPost]
        public string GetRoversCurrentPosition([FromBody]RoverPosition roverPosition)
        {
            if(ModelState.IsValid)
            return _roverMovementService.RoverMovement(roverPosition);

            return "Please provide valid inputs";
        }
    }
}
