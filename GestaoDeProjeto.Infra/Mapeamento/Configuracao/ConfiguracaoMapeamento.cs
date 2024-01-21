using Microsoft.EntityFrameworkCore;

namespace GestaoDeProjeto.Infra.Mapeamento.Configuracao
{
    public class ConfiguracaoMapeamento
    {
        public static void Injetar(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjetoMapeamento());
  
        }
    }
}
