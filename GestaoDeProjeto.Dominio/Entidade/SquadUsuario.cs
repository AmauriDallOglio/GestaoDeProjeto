using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class SquadUsuario : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; }

        public int Id_Squad { get; set; }
        public Squad Squad { get; set; }

        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; }
 
        public bool Inativo { get; set; }

        public void Incluir()
        {
            this.Inativo = false;
       
        }
    }
}
