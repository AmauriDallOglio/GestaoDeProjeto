using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Squads;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.Profiles
{
    public class SquadProfile : Profile
    {
        public SquadProfile()
        {
            CreateMap<Squad, SquadIncluirRequest>().ReverseMap();
            CreateMap<Squad, SquadIncluirResponse>().ReverseMap();

            CreateMap<Squad, SquadAlterarRequest>().ReverseMap();
            CreateMap<Squad, SquadAlterarResponse>().ReverseMap();

            CreateMap<Squad, SquadExcluirRequest>().ReverseMap();
            CreateMap<Squad, SquadExcluirResponse>().ReverseMap();

            CreateMap<Squad, SquadObterTodosRequest>().ReverseMap();
            CreateMap<Squad, SquadObterTodosResponse>().ReverseMap();

            CreateMap<Squad, SquadComboRequest>().ReverseMap();
            CreateMap<Squad, SquadComboResponse>().ReverseMap();
        }
    }
}
