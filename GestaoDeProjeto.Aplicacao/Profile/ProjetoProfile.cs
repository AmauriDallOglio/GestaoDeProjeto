using AutoMapper;
using GestaoDeProjeto.Aplicacao.Negocio;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<Projeto, ProjetoIncluirRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoIncluirResponse>().ReverseMap();

            CreateMap<Projeto, ProjetoAlterarRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoAlterarResponse>().ReverseMap();

            CreateMap<Projeto, ProjetoExcluirRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoExcluirResponse>().ReverseMap();

            CreateMap<Projeto, ProjetoObterTodosRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoObterTodosResponse>().ReverseMap();


        }
    }
}
