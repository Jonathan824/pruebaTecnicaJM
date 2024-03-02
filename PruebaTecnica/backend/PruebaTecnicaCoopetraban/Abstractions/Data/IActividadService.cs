// PruebaTecnica.Abstractions/Services/IActividadService.cs
using System.Collections.Generic;
using PruebaTecnica.Models;

namespace PruebaTecnica.Abstractions.Services
{
    public interface IActividadService
    {
        IEnumerable<Actividad> ObtenerTodasActividades();
        Actividad ObtenerActividadPorId(int id);
        void AgregarActividad(Actividad actividad);
        void ActualizarActividad(Actividad actividad);
        void EliminarActividad(int id);
    }
}
