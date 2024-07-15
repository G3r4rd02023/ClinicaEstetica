namespace EsteticaAvanzada.Data.Entidades
{
    public class SesionesProgramadas
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime Sesion1Fecha { get; set; }
        public DateTime Sesion2Fecha { get; set; }
        public DateTime Sesion3Fecha { get; set; }
        public DateTime Sesion4Fecha { get; set; }
        public DateTime Sesion5Fecha { get; set; }
        public DateTime Sesion6Fecha { get; set; }
        public DateTime Sesion7Fecha { get; set; }
        public DateTime Sesion8Fecha { get; set; }
        public DateTime Sesion9Fecha { get; set; }
        public DateTime Sesion10Fecha { get; set; }

    }
}
