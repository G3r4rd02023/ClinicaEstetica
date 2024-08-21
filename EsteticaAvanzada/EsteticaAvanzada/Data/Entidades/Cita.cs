using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaAvanzada.Data.Entidades
{
    public class Cita
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Pacientes { get; set; }
    }
}