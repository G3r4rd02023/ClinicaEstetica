using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class EstadoSalud
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool AlergiaMedicamentos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? AlergiaAnestesicos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? AlergiaCosmeticos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? AlergiaPerfumes { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? AlergiaOtros { get; set; }

        public bool Diabetes { get; set; }

        public bool Respiratorios { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? RespiratoriosEspecificar { get; set; }

        public bool Cardiacos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? CardiacosEspecificar { get; set; }

        public bool Digestivos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? DigestivosEspecificar { get; set; }

        public bool Estreñimiento { get; set; }

        public bool Edemas { get; set; }

        public bool CaidaCabello { get; set; }

        public bool PortaMarcapasos { get; set; }

        public bool ProtesisMetalicas { get; set; }

        public bool LentesContacto { get; set; }

        public bool AntOncologicos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? AntOncologicosEspecificar { get; set; }
        public bool Tiroides { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? TiroidesEspecificar { get; set; }

        public bool Convulsiones { get; set; }

        public bool Hipertension { get; set; }

        public bool Hipoglucemia { get; set; }

        public bool Sincope { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? OtrosPadecimientos { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? MedicamentosActuales { get; set; }

        public int Embarazos { get; set; } = 0;

        public int Partos { get; set; } = 0;

        public int Abortos { get; set; } = 0;

        public bool LactanciaMaterna { get; set; }

        public DateTime? FechaUltimaMenstruacion { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? MetodoAnticonceptivo {get;set;}

        public bool AltGlandular { get; set; }

        public bool AltHormonales { get; set; }

        public bool Cancer { get; set; }

    }
}
