// PruebaTecnica.Abstractions/Services/ITiempoService.cs
using System.Collections.Generic;
using PruebaTecnica.Models;

namespace PruebaTecnica.Abstractions.Services
{
    public interface ITiempoService
    {
        IEnumerable<Tiempo> ObtenerTodosTiempos();
        Tiempo ObtenerTiempoPorId(int id);
        void AgregarTiempo(Tiempo tiempo);
        void ActualizarTiempo(Tiempo tiempo);
        void EliminarTiempo(int id);
    }
}
