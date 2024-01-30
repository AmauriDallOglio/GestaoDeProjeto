using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Projeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeProjeto { get; set; } = string.Empty;

        [Required]
        [MaxLength]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [Required]
        public short Status { get; set; }
    }

    public enum StatusProjeto
    {
        EmAndamento = 1,
        Concluido = 2,
        PendenteAprovacao = 3,
        EmRevisao = 4,
        AguardandoRecursos = 5,
        Atrasado = 6
    }

}
