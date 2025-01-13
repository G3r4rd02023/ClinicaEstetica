using EsteticaAvanzada.Data.Entidades;

namespace EsteticaAvanzada.Models
{
    public class EsteticosViewModel
    {
        public Paciente? Paciente { get; set; }

        public DatosEsteticos? DatosEsteticos { get; set; }

        public AnalisisEstetico? AnalisisEsteticos { get; set; }

        public Imagenes? Imagenes { get; set; }

        public List<Imagenes> Fotos { get; set; } = new List<Imagenes>();

        public SesionesProgramadas? SesionesProgramadas { get; set; }
    }
}