using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;



namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Usuario : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; } = new Empresa();
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public byte Situacao { get; set; }

        public void Incluir()
        {
            Situacao = 0;
        }
    }

}
