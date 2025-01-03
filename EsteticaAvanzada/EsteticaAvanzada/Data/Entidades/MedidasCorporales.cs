using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaAvanzada.Data.Entidades
{
    public class MedidasCorporales
    {
        public int Id { get; set; }

        public Paciente? Paciente { get; set; }

        public int PacienteId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CinturaInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CinturaMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CinturaFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BustoInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? ButoMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BustoFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CaderaInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CaderaMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CaderaFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? AbdomenInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? AbdomenMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? AbdomenFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoDerInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoDerMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoDerFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoIzqInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoIzqMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BrazoIzqFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloDerInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloDerMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloDerFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloIzqInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloIzqMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MusloIzqFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorrillaDerInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorrillaDerMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorillaDerFinal { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorrillaIzqInicio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorrillaIzqMedio { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? PantorillaIzqFinal { get; set; }
    }
}