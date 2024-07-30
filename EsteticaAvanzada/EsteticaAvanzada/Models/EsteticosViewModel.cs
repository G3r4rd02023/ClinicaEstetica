using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Models
{
    public class EsteticosViewModel
    {
        public Paciente? Paciente { get; set; }

        public DatosEsteticos? DatosEsteticos { get; set; }

        public AnalisisEstetico? AnalisisEsteticos { get; set; }
    }
}
