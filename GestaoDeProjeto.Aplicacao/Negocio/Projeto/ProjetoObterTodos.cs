using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Negocio
{
    public class ProjetoObterTodosRequest : IRequest<RetornoPaginadoGenerico<ProjetoObterTodosResponse>>
    {
 
    }

    public class ProjetoObterTodosResponse : Projeto
    {

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

            var lista = _iProjetoRepositorio.ObterTodos();
            var listaDto = _mapper.Map<List<ProjetoObterTodosResponse>>(lista);
            RetornoPaginadoGenerico<ProjetoObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<ProjetoObterTodosResponse>
            {
                Modelos = listaDto,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = listaDto.Count()
            };
            return await Task.FromResult(retornoPaginado);
        }
    }
}
