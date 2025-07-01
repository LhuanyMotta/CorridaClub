using System.ComponentModel.DataAnnotations.Schema;

namespace CorridaClub.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("item")]
        public string? Item { get; set; }

        [Column("tamanho")]
        public string? Tamanho { get; set; }

        [Column("cor")]
        public string? Cor { get; set; }

        [Column("quantidade")]
        public int? Quantidade { get; set; }

        [Column("valor_unitario")]
        public decimal? ValorUnitario { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("data_pedido")]
        public DateTime? DataPedido { get; set; }

        [Column("data_entrega")]
        public DateTime? DataEntrega { get; set; }

        public Usuario? Usuario { get; set; }
    }
}