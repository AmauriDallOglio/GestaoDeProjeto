using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
{
    public class SquadObterTodosRequest : IRequest<RetornoPaginadoGenerico<SquadObterTodosResponse>>
    {
 
        public string? Descricao { get; set; } 
 
        public short? Inativo { get; set; }
    }

    public class SquadObterTodosResponse : Squad
    {

    }
    public class SquadObterTodosHandler : IRequestHandler<SquadObterTodosRequest, RetornoPaginadoGenerico<SquadObterTodosResponse>>
    {
        private readonly ISquadRepositorio _iSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadObterTodosHandler(IMediator mediator, IMapper mapper, ISquadRepositorio repository)
        {
            _iSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<SquadObterTodosResponse>> Handle(SquadObterTodosRequest request, CancellationToken cancellationToken)
        {
            var filtro = new SquadObterTodosFiltro(request);
            var where = filtro.CriterioWhere;
            var orderby = filtro.CriterioOrderBy;
            var includeProperties = filtro.Includes;

            // Aqui, você precisa aplicar o filtro na consulta
            var lista = await _iSquadRepositorio.ObterTodosAsync(where, orderby, "", false, null, null, cancellationToken);


            //if (!string.IsNullOrEmpty(request.Descricao))
            //{
            //    CriterioWhere = p => p.Descricao.Contains(filtro.Descricao);
            //}


            //var lista = await _iSquadRepositorio.ObterTodosAsync(
            //    //filter: x => x.Id == request.Id,
            //    includeProperties: "",
            //    noTracking: true,
            //    cancellationToken: cancellationToken
            //    ).ConfigureAwait(false);



            //List<Squad> lista = _iSquadRepositorio.ObterTodos();
            List<SquadObterTodosResponse> response = _mapper.Map<List<SquadObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<SquadObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<SquadObterTodosResponse>
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