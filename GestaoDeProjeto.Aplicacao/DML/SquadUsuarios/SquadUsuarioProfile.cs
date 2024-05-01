using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Squads;
using GestaoDeProjeto.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Aplicacao.DML.SquadUsuarios
{
    public class SquadUsuarioProfile : Profile
    {
        public SquadUsuarioProfile()
        {
            CreateMap<SquadUsuario, SquadUsuarioIncluirRequest>().ReverseMap();
            CreateMap<SquadUsuario, SquadUsuarioIncluirResponse>().ReverseMap();

            CreateMap<SquadUsuario, SquadUsuarioExcluirRequest>().ReverseMap();
            CreateMap<SquadUsuario, SquadUsuarioExcluirResponse>().ReverseMap();

        }
    }
}
