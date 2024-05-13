using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Mapeamento.Configuracao
{
    public class ConfiguracaoMapeamento
    {
        public static void Injetar(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmpresaMapeamento());
            builder.ApplyConfiguration(new ProjetoMapeamento());
            builder.ApplyConfiguration(new ProjetoSquadMapeamento());
            builder.ApplyConfiguration(new SquadMapeamento());
            builder.ApplyConfiguration(new SquadUsuarioMapeamento());
            builder.ApplyConfiguration(new UsuarioMapeamento());
            builder.ApplyConfiguration(new TarefaMapeamento());
        }
    }
}
