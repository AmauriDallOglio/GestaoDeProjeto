using AutoMapper;
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

            CreateMap<Usuario, UsuarioObterTodosRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioObterTodosResponse>().ReverseMap();
 
        }
    }
}
