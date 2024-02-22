using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command.Empresas;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile() 
        {
            CreateMap<Empresa, EmpresaIncluirRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaIncluirResponse>().ReverseMap();

            CreateMap<Empresa, EmpresaObterTodosRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaObterTodosResponse>().ReverseMap();
        }
    }
}
