﻿using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Empresas;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaIncluirRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaIncluirResponse>().ReverseMap();

            CreateMap<Empresa, EmpresaAlterarRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaAlterarResponse>().ReverseMap();

            CreateMap<Empresa, EmpresaExcluirRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaExcluirResponse>().ReverseMap();

            CreateMap<Empresa, EmpresaObterTodosRequest>().ReverseMap();
            CreateMap<Empresa, EmpresaObterTodosResponse>().ReverseMap();
        }
    }
}
