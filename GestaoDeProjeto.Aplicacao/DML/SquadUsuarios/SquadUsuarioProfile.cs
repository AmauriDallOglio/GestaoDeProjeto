using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.SquadUsuarios
{
    public class SquadUsuarioProfile : Profile
    {
        public SquadUsuarioProfile()
        {
            CreateMap<SquadUsuario, SquadUsuarioIncluirRequest>().ReverseMap();
            CreateMap<SquadUsuario, SquadUsuarioIncluirResponse>().ReverseMap();


            CreateMap<SquadUsuario, SquadUsuarioAlterarRequest>().ReverseMap();
            CreateMap<SquadUsuario, SquadUsuarioAlterarResponse>().ReverseMap();

            CreateMap<SquadUsuario, SquadUsuarioExcluirRequest>().ReverseMap();
            CreateMap<SquadUsuario, SquadUsuarioExcluirResponse>().ReverseMap();

        }
    }
}
