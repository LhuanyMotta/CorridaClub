using System.ComponentModel.DataAnnotations.Schema;

namespace CorridaClub.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("evento_id")]
        public int EventoId { get; set; }

        [Column("data_inscricao")]
        public DateTime? DataInscricao { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("numero_peito")]
        public string? NumeroPeito { get; set; }

        [Column("tamanho_camiseta")]
        public string? TamanhoCamiseta { get; set; }

        public Usuario? Usuario { get; set; }
        public Evento? Evento { get; set; }
    }
}