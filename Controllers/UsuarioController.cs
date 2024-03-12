using GasApii.Models;
using GasApii.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasApii.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;

    private readonly UsuarioServices _usuarioServices;

    public UsuarioController(ILogger<UsuarioController> logger, UsuarioServices usuarioServices)
    {
        _logger = logger;
        _usuarioServices = usuarioServices;
    }

    ///Obtener todos los Usuarios
    [HttpGet]
    public async Task<IActionResult> GetUsuario()
    {
        var usuarios = await _usuarioServices.GetAsync();
        return Ok(usuarios);
    }

    ///Obtener Usuario por Id
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUsuarioById(string Id)
    {
        return Ok(await _usuarioServices.GetUsuarioById(Id));
    }

    ///Crear Usuario
    [HttpPost]
    public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
    {
        if (usuario == null)
            return BadRequest();
        //if (motor.Nombre == string.Empty)
        //    ModelState.AddModelError("Name", "El usuario no debe estar vacio");

        await _usuarioServices.InsertUsuario(usuario);

        return Created("Created", true);
    }

    ///Actualizar Usuario
    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario, string Id)
    {
        if (usuario == null)
            return BadRequest();

        // Actualizar el ID del usuario con el valor proporcionado en la URL
        usuario.Id = Id;

        await _usuarioServices.UpdateUsuario(usuario);

        return Ok(new { message = "Usuario actualizado correctamente" });
    }


    ///Eliminar Usuario
    [HttpDelete]
    public async Task<IActionResult> DeleteUsuario(string Id)
    {
        await _usuarioServices.DeleteUsuario(Id);
        return NoContent();
    }

}

