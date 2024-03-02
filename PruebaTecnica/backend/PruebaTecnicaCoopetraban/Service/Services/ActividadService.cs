// PruebaTecnica.Services/Services/ActividadService.cs
using System.Collections.Generic;
using System.Linq;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace Services.Services
{
    public class ActividadService
    {
        private readonly ApplicationDbContext _context;

        public ActividadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Actividad> ObtenerTodasActividades()
        {
            return _context.Actividades.Include(a => a.Tiempos).ToList();
        }

        public Actividad ObtenerActividadPorId(int actividadId)
        {
            return _context.Actividades.Include(a => a.Tiempos).FirstOrDefault(a => a.ActividadId == actividadId);
        }

        public void AgregarActividad(Actividad actividad)
        {
            _context.Actividades.Add(actividad);
            _context.SaveChanges();
        }

        public void ActualizarActividad(Actividad actividad)
        {
            _context.Entry(actividad).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarActividad(int actividadId)
        {
            var actividad = _context.Actividades.Find(actividadId);
            if (actividad != null)
            {
                _context.Actividades.Remove(actividad);
                _context.SaveChanges();
            }
        }
    }
}
