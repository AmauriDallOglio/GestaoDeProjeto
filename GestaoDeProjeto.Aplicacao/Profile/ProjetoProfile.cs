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

            CreateMap<Projeto, ProjetoObterTodosRequest>().ReverseMap();
            CreateMap<Projeto, ProjetoObterTodosResponse>().ReverseMap();


        }
    }
}
