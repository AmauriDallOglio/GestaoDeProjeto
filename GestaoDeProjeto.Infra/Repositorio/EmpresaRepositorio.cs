﻿using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class EmpresaRepositorio : RepositorioGenerico<Empresa>, IEmpresaRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public EmpresaRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }


    }
}