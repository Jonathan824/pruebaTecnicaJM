// PruebaTecnica.Services/Services/TiempoService.cs
using System.Collections.Generic;
using System.Linq;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace Services.Services
{
    public class TiempoService
    {
        private readonly ApplicationDbContext _context;

        public TiempoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tiempo> ObtenerTodosTiempos()
        {
            return _context.Tiempos.ToList();
        }

        public Tiempo ObtenerTiempoPorId(int tiempoId)
        {
            return _context.Tiempos.FirstOrDefault(t => t.TiempoId == tiempoId);
        }

        public void AgregarTiempo(Tiempo tiempo)
        {
            _context.Tiempos.Add(tiempo);
            _context.SaveChanges();
        }

        public void ActualizarTiempo(Tiempo tiempo)
        {
            _context.Entry(tiempo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarTiempo(int tiempoId)
        {
            var tiempo = _context.Tiempos.Find(tiempoId);
            if (tiempo != null)
            {
                _context.Tiempos.Remove(tiempo);
                _context.SaveChanges();
            }
        }
    }
}
