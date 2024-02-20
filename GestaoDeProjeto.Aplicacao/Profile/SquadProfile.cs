using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao
{
    public class SquadProfile : Profile
    {
        public SquadProfile()
        {
            CreateMap<Squad, SquadIncluirRequest>().ReverseMap();
            CreateMap<Squad, SquadIncluirResponse>().ReverseMap();
 
        }
    }
}
