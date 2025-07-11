using System.ComponentModel.DataAnnotations.Schema;

namespace CorridaClub.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("telefone")]
        public string? Telefone { get; set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("genero")]
        public string? Genero { get; set; }

        [Column("tipo_membro")]
        public string? TipoMembro { get; set; }

        public List<Inscricao>? Inscricoes { get; set; }
        public List<Pedido>? Pedidos { get; set; }
    }
}