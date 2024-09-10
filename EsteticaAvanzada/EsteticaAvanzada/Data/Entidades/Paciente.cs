using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }

        [RegularExpression(@"[0-9]{4}[-]{1}[0-9]{4}[-]{1}[0-9]{5}", ErrorMessage = "Formato de DNI incorrecto.")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string DNI { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombrePaciente { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Profesion { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Telefono { get; set; } = null!;

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Correo { get; set; } = null!;

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contacto { get; set; } = null!;

        [MaxLength(1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Sexo { get; set; } = null!;

        public int Edad
        { get { var today = DateTime.Today; var age = today.Year - FechaNacimiento.Year; if (FechaNacimiento.Date > today.AddYears(-age)) age--; return age; } }
    }
}