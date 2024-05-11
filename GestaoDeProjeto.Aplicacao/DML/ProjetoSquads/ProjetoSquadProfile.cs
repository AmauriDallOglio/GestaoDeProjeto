using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    public class ProjetoSquadProfile : Profile
    {
        public ProjetoSquadProfile()
        {
            CreateMap<ProjetoSquad, ProjetoSquadIncluirRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadIncluirResponse>().ReverseMap();

            CreateMap<ProjetoSquad, ProjetoSquadAlterarRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadAlterarResponse>().ReverseMap();

            CreateMap<ProjetoSquad, ProjetoSquadExcluirRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadExcluirResponse>().ReverseMap();

            CreateMap<ProjetoSquad, ProjetoSquadObterTodosRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadObterTodosResponse>().ReverseMap();

        }
    }
}