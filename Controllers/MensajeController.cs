using GasApii.Models;
using GasApii.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasApii.Controllers;

    [ApiController]
    [Route("api/[controller]")]

    public class MensajeController : ControllerBase
{
    private readonly ILogger<MensajeController> _logger;

    private readonly MensajeServices _mensajeServices;

    public MensajeController(ILogger<MensajeController> logger, MensajeServices mensajeServices)
    {
        _logger = logger;
        _mensajeServices = mensajeServices;
    }

    ///Obtener todos los Usuarios
    [HttpGet]
    public async Task<IActionResult> GetMensaje()
    {
        var mensajes = await _mensajeServices.GetAsync();
        return Ok(mensajes);
    }

    ///Obtener Usuario por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetMensajeById(string Id)
    {
        return Ok(await _mensajeServices.GetMensajeById(Id));
    }

    ///Crear Usuario
    [HttpPost]
    public async Task<IActionResult> CreateMensaje([FromBody] Mensaje mensaje)
    {
        if (mensaje == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");

        await _mensajeServices.InsertMensaje(mensaje);

        return Created("Created", true);
    }

    ///Actualizar Usuario
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateMensaje([FromBody] Mensaje mensaje, string Id)
    {
        if (mensaje == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");
        //motor.Id = Id;

        await _mensajeServices.InsertMensaje(mensaje);
        return Created("Created", true);
    }

    ///Eliminar Usuario
    [HttpDelete]
    public async Task<IActionResult> DeleteMotor(string Id)
    {
        await _mensajeServices.DeleteMensaje(Id);
        return NoContent();
    }
}

