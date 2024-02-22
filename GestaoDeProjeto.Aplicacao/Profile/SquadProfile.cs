using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Aplicacao.Command.Squads;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeSquad.Aplicacao.Command.Squads;

namespace GestaoDeProjeto.Aplicacao
{
    public class SquadProfile : Profile
    {
        public SquadProfile()
        {
            CreateMap<Squad, SquadIncluirRequest>().ReverseMap();
            CreateMap<Squad, SquadIncluirResponse>().ReverseMap();

            CreateMap<Squad, SquadObterTodosRequest>().ReverseMap();
            CreateMap<Squad, SquadObterTodosResponse>().ReverseMap();
        }
    }
}
