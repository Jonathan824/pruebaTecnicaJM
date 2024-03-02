// PruebaTecnica.Api/Models/Tiempo.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Tiempo
    {
        public int TiempoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "El tiempo debe estar entre 1 y 8 horas.")]
        public int Horas { get; set; }

        public int ActividadId { get; set; }

        public Actividad Actividad { get; set; }
    }
}
