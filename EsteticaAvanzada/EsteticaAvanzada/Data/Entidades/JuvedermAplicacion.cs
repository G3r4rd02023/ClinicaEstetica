using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaAvanzada.Data.Entidades
{
    public class JuvedermAplicacion
    {
        public int Id { get; set; }

        public PlanAplicacion? PlanAplicacion { get; set; }

        public int PlanAplicacionId { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Lado { get; set; } = null!;

        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Codigo { get; set; } = null!;

        [Column(TypeName = "decimal(5,2)")]
        public decimal VolumenML { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Producto { get; set; } = null!;
    }
}
