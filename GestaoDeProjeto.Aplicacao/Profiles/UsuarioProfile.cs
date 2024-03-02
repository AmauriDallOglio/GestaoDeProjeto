using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command.Usuarios;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioIncluirRequest>().ReverseMap();
            CreateMap<Usuario, UsuarioIncluirResponse>().ReverseMap();

 


        }
    }
}
