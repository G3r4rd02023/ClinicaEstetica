using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class Habitos
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool Alcohol { get; set; }

        public bool Tabaco { get; set; }

        public DateTime? UltimaIngesta { get; set; }

        public int Frecuencia { get; set; } = 0;

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? Drogas { get; set; }

        public bool PracticaDeporte { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? EspecifiqueDeporte { get; set; }

        public int HorasSueño { get; set; } = 0;


    }
}
