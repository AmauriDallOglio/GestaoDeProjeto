using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.ProjetoSquads;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.Profiles
{
    public class ProjetoSquadProfile : Profile
    {
        public ProjetoSquadProfile()
        {
            CreateMap<ProjetoSquad, ProjetoSquadIncluirRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadIncluirResponse>().ReverseMap();

            CreateMap<ProjetoSquad, ProjetoSquadAlterarRequest>().ReverseMap();
            CreateMap<ProjetoSquad, ProjetoSquadAlterarResponse>().ReverseMap();
        }
    }
}