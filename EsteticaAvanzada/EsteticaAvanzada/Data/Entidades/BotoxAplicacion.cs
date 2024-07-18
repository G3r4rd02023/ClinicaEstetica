using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class BotoxAplicacion
    {
        public int Id { get; set; }

        public PlanAplicacion? PlanAplicacion { get; set; }

        public int PlanAplicacionId { get; set; }
        public bool Frontal { get; set; }
        public bool Corrugador { get; set; }
        public bool Procerus { get; set; }
        public bool OrbicularOjos { get; set; }
        public bool Nasal { get; set; }
        public bool OrbicularLabios { get; set; }
        public bool Mentoniano { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]        
        public string? Otras { get; set; }
        public int TotalUnidadesInyectadas { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCaducidad { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NumeroLote { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string VolumenDiluicion { get; set; } = null!;
    }
}

