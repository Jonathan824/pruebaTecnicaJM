// PruebaTecnica.Api/Controllers/ActividadController.cs
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using Services.Services;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ActividadService _actividadService;

        public ActividadController(ActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        [HttpGet]
        public IActionResult ObtenerTodasActividades()
        {
            var actividades = _actividadService.ObtenerTodasActividades();
            return Ok(actividades);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerActividadPorId(int id)
        {
            var actividad = _actividadService.ObtenerActividadPorId(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);
        }

        [HttpPost]
        public IActionResult AgregarActividad([FromBody] Actividad actividad)
        {
            _actividadService.AgregarActividad(actividad);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarActividad(int id, [FromBody] Actividad actividad)
        {
            var actividadExistente = _actividadService.ObtenerActividadPorId(id);

            if (actividadExistente == null)
            {
                return NotFound();
            }

            _actividadService.ActualizarActividad(actividad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarActividad(int id)
        {
            var actividadExistente = _actividadService.ObtenerActividadPorId(id);

            if (actividadExistente == null)
            {
                return NotFound();
            }

            _actividadService.EliminarActividad(id);
            return Ok();
        }
    }
}
