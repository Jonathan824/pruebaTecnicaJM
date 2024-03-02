// PruebaTecnica.Api/Models/Usuario.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [EmailAddress]
        public string CorreoElectronico { get; set; }

        public List<Actividad> Actividades { get; set; }
    }
}
