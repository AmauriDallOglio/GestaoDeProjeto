using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace GestaoDeProjeto.Dominio.Entidade
{
    public class ProjetoSquad : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; } = new Empresa();
        public int Id_Projeto { get; set; }
        public Projeto Projeto { get; set; } = new Projeto();
        public int Id_Squad { get; set; }
        public Squad Squad { get; set; } = new Squad();
        public bool Inativo { get; set; }

        [NotMapped]
        public string NomeProjeto
        {
            get
            {
                return Projeto != null ? Projeto.NomeProjeto : string.Empty;
            }
            init { }
        }

        [NotMapped]
        public string NomeSquad
        {
            get
            {
                return Squad != null ? Squad.Descricao : string.Empty;
            }
            init { }
        }

    }
}
