using GasApii.Models;
using GasApii.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasApii.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
{
    private readonly ILogger<SensorController> _logger;

    private readonly SensorServices _sensorServices;

    public SensorController(ILogger<SensorController> logger, SensorServices sensorServices)
    {
        _logger = logger;
        _sensorServices = sensorServices;
    }

    ///Obtener todos los Sensores
    [HttpGet]
    public async Task<IActionResult> GetSensor()
    {
        var sensor = await _sensorServices.GetAsync();
        return Ok(sensor);
    }

    ///Obtener Sensor por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetSensorById(string Id)
    {
        return Ok(await _sensorServices.GetSensorById(Id));
    }

    ///Crear Sensor
    [HttpPost]
    public async Task<IActionResult> CreateSensor([FromBody] Sensor sensor)
    {
        if (sensor == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");

        await _sensorServices.InsertSensor(sensor);

        return Created("Created", true);
    }

    ///Actualizar Sensor
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateSensor([FromBody] Sensor sensor, string Id)
    {
        if (sensor == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");
        //motor.Id = Id;

        await _sensorServices.InsertSensor(sensor);
        return Created("Created", true);
    }

    ///Eliminar Sensor
    [HttpDelete]
    public async Task<IActionResult> DeleteSensor(string Id)
    {
        await _sensorServices.DeleteSensor(Id);
        return NoContent();
    }
}



