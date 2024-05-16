using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Tarefas
{
    public class TarefaObterTodosRequest : IRequest<RetornoPaginadoGenerico<TarefaObterTodosResponse>>
    {
        public int Id_Projeto { get; set; }
        public string? Descricao { get; set; }
        public string? Objetivo { get; set; }
        public string? Resultado { get; set; }
        public short Situacao { get; set; }
    }

    public class TarefaObterTodosResponse : Tarefa
    {

    }

    public class SquadObterTodosHandler : IRequestHandler<TarefaObterTodosRequest, RetornoPaginadoGenerico<TarefaObterTodosResponse>>
    {
        private readonly ITarefaRepositorio _iTarefaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadObterTodosHandler(IMediator mediator, IMapper mapper, ITarefaRepositorio repository)
        {
            _iTarefaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<TarefaObterTodosResponse>> Handle(TarefaObterTodosRequest request, CancellationToken cancellationToken)
        {
            var filtro = new TarefaObterTodosFiltro(request);
            var where = filtro.CriterioWhere;
            var orderby = filtro.CriterioOrderBy;
            var includeProperties = filtro.Includes;

     
            var lista = await _iTarefaRepositorio.ObterTodosAsync(where, orderby, "", false, null, null, cancellationToken);

 
 
            List<TarefaObterTodosResponse> response = _mapper.Map<List<TarefaObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<TarefaObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<TarefaObterTodosResponse>
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
