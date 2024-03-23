using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
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
