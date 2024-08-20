using System.ComponentModel.DataAnnotations;

namespace EsteticaAvanzada.Data.Entidades
{
    public class DatosEsteticos
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool Menton { get; set; }
        public bool Mejillas { get; set; }
        public bool Nariz { get; set; }
        public bool NingunImplante { get; set; }
        public bool Blefaroplastia { get; set; }
        public bool Rinoplastia { get; set; }
        public bool Otoplastia { get; set; }
        public bool Lifting { get; set; }
        public bool Bichectomia { get; set; }
        public bool Septoplastia { get; set; }
        public bool NingunaCirugia { get; set; }
        public bool Botox { get; set; }
        public bool Plasma { get; set; }
        public bool VitaminaC { get; set; }
        public bool AcidoHialuronico { get; set; }
        public bool NingunProcedimiento { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? OtroTratamiento { get; set; }

        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string? HaceCuantoTiempo { get; set; }

    }
}
