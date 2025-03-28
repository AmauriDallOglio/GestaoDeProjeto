﻿using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Infra.Contexto;

namespace GestaoDeProjeto.Infra.Repositorio
{
    public class SquadRepositorio : RepositorioGenerico<Squad>, ISquadRepositorio
    {
        private readonly GestaoDeProjetoContexto _contexto;
        public SquadRepositorio(GestaoDeProjetoContexto dbContext) : base(dbContext)
        {
            _contexto = dbContext;
        }



    }
}
