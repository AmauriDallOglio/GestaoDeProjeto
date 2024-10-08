using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class SquadUsuario : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id_Empresa { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; } = new Empresa();

        public int Id_Squad { get; set; }
        public Squad Squad { get; set; } = new Squad();

        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
 
        public bool Inativo { get; set; }

        public void Incluir()
        {
            this.Inativo = false;
       
        }
    }
}
