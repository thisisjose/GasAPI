using GasApii.Models;
using GasApii.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasApii.Controllers;

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

    ///Obtener todos los Motoress
    [HttpGet]
    public async Task<IActionResult> GetMotor()
    {
        var usuarios = await _motorServices.GetAsync();
        return Ok(usuarios);
    }

    ///Obtener Motor por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetMotorById(string Id)
    {
        return Ok(await _motorServices.GetMotorById(Id));
    }

    ///Crear Motor
    [HttpPost]
    public async Task<IActionResult> CreateMotr([FromBody] Motor motor)
    {
        if (motor == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");

        await _motorServices.InsertMotor(motor);

        return Created("Created", true);
    }

    ///Actualizar Motor
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateMotor([FromBody] Motor motor, string Id)
    {
        if (motor == null)
            return BadRequest();

        // Actualizar el ID del motor con el valor proporcionado en la URL
        motor.Id = Id;

        await _motorServices.UpdateMotor(motor);

        return Ok(new { message = "Motor actualizado correctamente" });
    }

    ///Eliminar Motor
    [HttpDelete]
    public async Task<IActionResult> DeleteMotor(string Id)
    {
        await _motorServices.DeleteMotor(Id);
        return NoContent();
    }
}

