namespace EsteticaAvanzada.Data.Entidades
{
    public class SesionesProgramadas
    {
        public int Id { get; set; }
        public Paciente? Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime Sesion1Fecha { get; set; }
        public string? Sesion1Comentario { get; set; }
        public DateTime Sesion2Fecha { get; set; }

        public string? Sesion2Comentario { get; set; }
        public DateTime Sesion3Fecha { get; set; }

        public string? Sesion3Comentario { get; set; }
        public DateTime Sesion4Fecha { get; set; }

        public string? Sesion4Comentario { get; set; }
        public DateTime Sesion5Fecha { get; set; }

        public string? Sesion5Comentario { get; set; }
        public DateTime Sesion6Fecha { get; set; }

        public string? Sesion6Comentario { get; set; }
        public DateTime Sesion7Fecha { get; set; }

        public string? Sesion7Comentario { get; set; }
        public DateTime Sesion8Fecha { get; set; }

        public string? Sesion8Comentario { get; set; }
        public DateTime Sesion9Fecha { get; set; }

        public string? Sesion9Comentario { get; set; }
        public DateTime Sesion10Fecha { get; set; }

        public string? Sesion10Comentario { get; set; }

        public DateTime Sesion11Fecha { get; set; }

        public string? Sesion11Comentario { get; set; }

        public DateTime Sesion12Fecha { get; set; }

        public string? Sesion12Comentario { get; set; }
    }
}