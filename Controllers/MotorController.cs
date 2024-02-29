using GasApii.Models;
using GasApii.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasApii.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorController : ControllerBase
    {
        private readonly ILogger<MotorController> _logger;
        private readonly MotorServices _motorServices;

        public MotorController(ILogger<MotorController> logger, MotorServices motorServices)
        {
            _logger = logger;
            _motorServices = motorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetMotors()
        {
            var motors = await _motorServices.GetAsync();
            return Ok(motors);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMotorById(string Id)
        {
            return Ok(await _motorServices.GetMotorById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMotor([FromBody] Motor motor)
        {
            if (motor == null)
                return BadRequest();

            await _motorServices.InsertMotor(motor);

            return Created("Created", true);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateMotor([FromBody] Motor motor, string Id)
        {
            if (motor == null)
                return BadRequest();

            motor.Id = Id;
            await _motorServices.UpdateMotor(motor);

            return Created("Created", true);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMotor(string Id)
        {
            await _motorServices.DeleteMotor(Id);
            return NoContent();
        }
    }
}
