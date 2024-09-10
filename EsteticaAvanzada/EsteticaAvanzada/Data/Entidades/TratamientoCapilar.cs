namespace EsteticaAvanzada.Data.Entidades
{
    public class TratamientoCapilar
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public string? AntecedentesPatologicos { get; set; }

        public string? AntecedentesInmunoAlergicos { get; set; }

        public string? AntecedentesQuirurgicos { get; set; }

        public string? MotivoConsulta { get; set; }

        public string Diagnostico { get; set; } = null!;

        public string PlanTratamiento { get; set; } = null!;

        public SesionesProgramadas? SesionesProgramadas { get; set; }
    }
}