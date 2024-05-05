using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;


namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Squad : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        //public byte[]? ArrayImagem { get; set; }
        //public string? UrlImagem { get; set; } = string.Empty;
        public bool Inativo { get; set; }

        public Squad Incluir()
        {
            this.Inativo = false;
            return this;
        }
    }
}
