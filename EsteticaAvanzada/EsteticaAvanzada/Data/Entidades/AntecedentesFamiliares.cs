namespace EsteticaAvanzada.Data.Entidades
{
    public class AntecedentesFamiliares
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public bool Diabetes { get; set; }

        public bool Cancer { get; set; }

        public bool Asma { get; set; }

        public bool Otro { get; set; }

        public bool HTA { get; set; }

    }
}
