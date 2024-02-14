using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Projeto : AuditableEntity<int>, IEmpresaObrigatorio
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Situacao { get; set; }
    }

    

}
