using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Empresas;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioIncluirRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioIncluirResponse>().ReverseMap();

            CreateMap<Usuario, UsuarioAlterarRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioAlterarResponse>().ReverseMap();

            CreateMap<Usuario, UsuarioExcluirRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioExcluirResponse>().ReverseMap();

            CreateMap<Empresa, UsuarioObterTodosRequest>().ReverseMap();
            CreateMap<Empresa, UsuarioObterTodosResponse>().ReverseMap();
        }
    }
}
