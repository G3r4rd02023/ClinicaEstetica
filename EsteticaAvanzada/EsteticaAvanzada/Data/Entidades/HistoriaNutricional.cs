using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaAvanzada.Data.Entidades
{
    public class HistoriaNutricional
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public string? AntecedentesPatologicos { get; set; }

        public string? Medicamentos { get; set; }

        public string? AntecedentesInmunoAlergicos { get; set; }

        public string? Procedimientos { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Peso { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Talla { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal IMC { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Diagnostico { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PlanTratamiento { get; set; } = null!;

        public MedidasCorporales? MedidasCorporales { get; set; }

        public SesionesProgramadas? SesionesProgramadas { get; set; }
    }
}