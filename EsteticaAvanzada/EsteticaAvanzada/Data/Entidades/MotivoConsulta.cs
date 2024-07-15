using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class MotivoConsulta
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool Envejecimiento { get; set; }

        public bool Acne { get; set; }

        public bool AdiposidadLocalizada { get; set; }

        public bool CuidadoPiel { get; set; }

        public bool Arrugas { get; set; }

        public bool Rosacea { get; set; }

        public bool Flacidez { get; set; }

        public bool Manchas { get; set; }

        public bool Celulitis { get; set; }

        public bool Estrias { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]        
        public string? Otros { get; set; } 

    }

}
