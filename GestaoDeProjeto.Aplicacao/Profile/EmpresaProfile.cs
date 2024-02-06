using AutoMapper;
using GestaoDeProjeto.Aplicacao.Negocio;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile() {
            CreateMap<Empresa, EmpresaIncluirRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaIncluirResponse>().ReverseMap();
        }
    }
}
