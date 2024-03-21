using GestaoDeProjeto.Dominio.Util;
using System.Text.Json.Serialization;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Projeto : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public short Situacao { get; set; }

        public void Inserir()
        {
            DataHoraInicio = DateTime.Now;
            Situacao = 0;
        }
    }
}
