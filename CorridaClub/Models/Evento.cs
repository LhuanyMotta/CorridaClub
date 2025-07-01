using System.ComponentModel.DataAnnotations.Schema;

namespace CorridaClub.Models
{
    [Table("evento")]
    public class Evento
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("data")]
        public DateTime? Data { get; set; }

        [Column("local")]
        public string? Local { get; set; }

        [Column("distancia")]
        public decimal? Distancia { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        public List<Inscricao>? Inscricoes { get; set; }
    }
}