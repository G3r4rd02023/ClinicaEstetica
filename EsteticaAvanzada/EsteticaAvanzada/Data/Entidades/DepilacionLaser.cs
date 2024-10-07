namespace EsteticaAvanzada.Data.Entidades
{
    public class DepilacionLaser
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        public string? MotivoConsulta { get; set; }

        public string? AntecedentesPatologicos { get; set; }

        public DateTime? FechaUltimaMenstruacion { get; set; }

        public DateTime? FechaUltimaExposicionSolar { get; set; }

        public string? Medicamentos { get; set; }

        public bool Manchas { get; set; }

        public bool Verrugas { get; set; }

        public bool Vitiligio { get; set; }

        public bool Cicatrices { get; set; }

        public bool Quistes { get; set; }

        public bool Psoriasis { get; set; }

        public bool Eccemas { get; set; }

        public bool Forunculos { get; set; }

        public bool Acne { get; set; }

        public string? Observaciones { get; set; }

        public bool Tabaquismo { get; set; }

        public bool Alcoholismo { get; set; }

        public bool Drogas { get; set; }

        public bool ActividadFisica { get; set; }

        public bool SeAutomedica { get; set; }

        public bool Pasatiempos { get; set; }

        public bool Embarazada { get; set; }

        public string? MesesEmbarazo { get; set; }

        public string? CantidadHijos { get; set; }

        public bool MediaCara { get; set; }

        public bool CaraCompleta { get; set; }

        public bool Bigote { get; set; }

        public bool Axila { get; set; }

        public bool MedioBrazo { get; set; }

        public bool BrazoCompleto { get; set; }

        public bool MediaPierna { get; set; }

        public bool PiernaCompleta { get; set; }

        public bool Bikini { get; set; }

        public bool Gluteos { get; set; }

        public bool Espalda { get; set; }

        public bool OtraZona { get; set; }

        public string? EspecifiqueZona { get; set; }

        public SesionesProgramadas? SesionesProgramadas { get; set; }
    }
}