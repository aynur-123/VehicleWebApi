using Microsoft.AspNetCore.Mvc;
using VehicleApi.Services;

namespace VehicleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetCarsByColor")]
        public async Task<IActionResult> GetCarsByColor(string color)
        {
            var result = await _vehicleService.GetCarsByColor(color);
            return Ok(result);
        }

        [HttpGet("GetBusesByColor")]
        public async Task<IActionResult> GetBusesByColor(string color)
        {
            var result = await _vehicleService.GetBusesByColor(color);
            return Ok(result);
        }

        [HttpGet("GetBoatsByColor")]
        public async Task<IActionResult> GetBoatsByColor(string color)
        {
            var result = await _vehicleService.GetBoatsByColor(color);
            return Ok(result);
        }

        [HttpPost("TurnOnOrOffHeadLightsOfCarById")]
        public async Task<IActionResult> TurnOnOrOffHeadLightsOfCarById(int id)
        {
            await _vehicleService.TurnOnOrOffHeadLightsOfCarById(id);
            return Ok();
        }

        [HttpDelete("DeleteCarById")]
        public async Task<IActionResult> DeleteCarById(int id)
        {
            await _vehicleService.DeleteCarById(id);
            return Ok();
        }

    }
}
