using GestaoDeProjeto.Dominio.Util;
using System.Text.Json.Serialization;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Usuario : AuditableEntity<int>, IEmpresaObrigatorio
    {
       //public int Id { get; set; }
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public byte Situacao { get; set; }

 

    }

}
