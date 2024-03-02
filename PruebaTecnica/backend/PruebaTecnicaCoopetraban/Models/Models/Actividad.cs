// PruebaTecnica.Api/Models/Actividad.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Actividad
    {
        public int ActividadId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<Tiempo> Tiempos { get; set; }
    }
}
