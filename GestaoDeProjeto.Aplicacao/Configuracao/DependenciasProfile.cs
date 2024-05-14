using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Empresas;
using GestaoDeProjeto.Aplicacao.DML.Projetos;
using GestaoDeProjeto.Aplicacao.DML.ProjetoSquads;
using GestaoDeProjeto.Aplicacao.DML.Squads;
using GestaoDeProjeto.Aplicacao.DML.SquadUsuarios;
using GestaoDeProjeto.Aplicacao.DML.Tarefas;
using GestaoDeProjeto.Aplicacao.DML.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeProjeto.Aplicacao.Configuracao
{
    public static class DependenciasProfile
    {
        public static void ConfigureAutoMapperProfile(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                Injetar(cfg);
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void Injetar(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<EmpresaProfile>();
            cfg.AddProfile<ProjetoProfile>();
            cfg.AddProfile<ProjetoSquadProfile>();
            cfg.AddProfile<SquadProfile>();
            cfg.AddProfile<SquadUsuarioProfile>();
            cfg.AddProfile<UsuarioProfile>();
            cfg.AddProfile<TarefaProfile>();
        }
    }
}

