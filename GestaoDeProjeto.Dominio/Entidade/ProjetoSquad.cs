using GestaoDeProjeto.Dominio.Util;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class ProjetoSquad : AuditableEntity<int>, IEmpresaObrigatorio
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public int Id_Projeto { get; set; }
        public Projeto Projeto { get; set; }
        public int Id_Squad { get; set; }
        public Squad Squad { get; set; }
        public bool Inativo { get; set; }

    }
}
