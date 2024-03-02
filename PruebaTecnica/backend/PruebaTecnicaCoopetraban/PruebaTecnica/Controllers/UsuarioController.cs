using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Abstractions.Services;
using PruebaTecnica.Models;
using System;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        [HttpGet]
        public IActionResult ObtenerTodosUsuarios()
        {
            var usuarios = _usuarioService.ObtenerTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            var usuario = _usuarioService.ObtenerUsuarioPorId(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            _usuarioService.AgregarUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.Id)
                return BadRequest();

            var usuarioExistente = _usuarioService.ObtenerUsuarioPorId(id);

            if (usuarioExistente == null)
                return NotFound();

            _usuarioService.ActualizarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _usuarioService.ObtenerUsuarioPorId(id);

            if (usuario == null)
                return NotFound();

            _usuarioService.EliminarUsuario(id);
            return NoContent();
        }
    }
}
