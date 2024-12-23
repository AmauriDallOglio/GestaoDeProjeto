﻿using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoObterTodosRequest : IRequest<RetornoPaginadoGenerico<ProjetoObterTodosResponse>>
    {
        public string NomeProjeto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Situacao { get; set; }
    }

    public class ProjetoObterTodosResponse  
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public short Situacao { get; set; }
 
    }

    public class ProjetoObterTodosHandler : IRequestHandler<ProjetoObterTodosRequest, RetornoPaginadoGenerico<ProjetoObterTodosResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoObterTodosHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<ProjetoObterTodosResponse>> Handle(ProjetoObterTodosRequest request, CancellationToken cancellationToken)
        {

            //var filtro = new ProjetoListarTodosFiltro(request);
            //var where = filtro.CriterioWhere;
            //var orderby = filtro.CriterioOrderBy;
            //var include = filtro.Includes;
 

            //List<Projeto> lista = await _iProjetoRepositorio.ObterTodos(filtro, orderby, false, null, null);

            List<Projeto> lista = await _iProjetoRepositorio.BuscarTodosPorDescricaoAsync(request.Descricao, cancellationToken);
            List<ProjetoObterTodosResponse> response = _mapper.Map<List<ProjetoObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<ProjetoObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<ProjetoObterTodosResponse>
            {
                Modelos = response,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = response.Count()
            };
            return await Task.FromResult(retornoPaginado);
        }
    }
}
