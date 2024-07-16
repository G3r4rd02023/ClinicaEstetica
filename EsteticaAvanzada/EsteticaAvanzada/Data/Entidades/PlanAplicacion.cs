namespace EsteticaAvanzada.Data.Entidades
{
    public class PlanAplicacion
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public DateTime FechaAplicacionBotox { get; set; }

        public DateTime FechaAplicacionJuvederm { get; set; }

        public DateTime RetornoEvaluacionFecha { get; set; }

        public DateTime RetornoEvaluacionHora { get; set; }

        public DateTime NuevaAplicacionFecha { get; set; }

    }
}
