// PruebaTecnica.Api/Controllers/TiempoController.cs
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using Services.Services;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoController : ControllerBase
    {
        private readonly TiempoService _tiempoService;

        public TiempoController(TiempoService tiempoService)
        {
            _tiempoService = tiempoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosTiempos()
        {
            var tiempos = _tiempoService.ObtenerTodosTiempos();
            return Ok(tiempos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerTiempoPorId(int id)
        {
            var tiempo = _tiempoService.ObtenerTiempoPorId(id);

            if (tiempo == null)
            {
                return NotFound();
            }

            return Ok(tiempo);
        }

        [HttpPost]
        public IActionResult AgregarTiempo([FromBody] Tiempo tiempo)
        {
            _tiempoService.AgregarTiempo(tiempo);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarTiempo(int id, [FromBody] Tiempo tiempo)
        {
            var tiempoExistente = _tiempoService.ObtenerTiempoPorId(id);

            if (tiempoExistente == null)
            {
                return NotFound();
            }

            _tiempoService.ActualizarTiempo(tiempo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarTiempo(int id)
        {
            var tiempoExistente = _tiempoService.ObtenerTiempoPorId(id);

            if (tiempoExistente == null)
            {
                return NotFound();
            }

            _tiempoService.EliminarTiempo(id);
            return Ok();
        }
    }
}
