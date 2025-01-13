using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class AnalisisEstetico
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool PielNormal { get; set; }

        public bool PielMixta { get; set; }

        public bool PielHidratada { get; set; }

        public bool PielDesvitalizada { get; set; }

        public bool PielSeca { get; set; }

        public bool PielGrasa { get; set; }

        public bool DeshidratacionLeve { get; set; }

        public bool DeshidratacionMedio { get; set; }

        public bool DeshidratacionAlta { get; set; }

        public bool Nevus { get; set; }

        public bool Macula { get; set; }

        public bool Acne { get; set; }

        public bool Cicatrices { get; set; }

        public bool Telangiectasias { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? EspecifiqueOtros { get; set; }

        public bool PorosAbiertos { get; set; }

        public bool PorosContraidos { get; set; }

        public bool PorosSemivisibles { get; set; }

        public bool TexturaFina { get; set; }

        public bool TexturaMediana { get; set; }

        public bool TexturaGruesa { get; set; }

        public bool ComedonesBlancos { get; set; }

        public bool ComedonesNegros { get; set; }

        public bool ComedonesNinguno { get; set; }

        public bool OrbicularesOjos { get; set; }

        public bool Nasogenianos { get; set; }

        public bool Frontales { get; set; }

        public bool Labios { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? ProductosUsados { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? DiagnosticoEstetico { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? ObjetivosTratamiento { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? TratamientoProposito { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? Observaciones { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? ConsentimientoInformado { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? EscalaGoglau { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? EscalaFizpatrick { get; set; }

        public DateTime? ProximaCita { get; set; }

        public SesionesProgramadas? SesionesProgramadas { get; set; }
    }
}