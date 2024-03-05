using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command.Empresas
{
    public class EmpresaObterTodosRequest : IRequest<RetornoPaginadoGenerico<EmpresaObterTodosResponse>>
    {
        
    }

    public class EmpresaObterTodosResponse : Empresa
    {

    }


    public class EmpresaObterTodosHandler : IRequestHandler<EmpresaObterTodosRequest, RetornoPaginadoGenerico<EmpresaObterTodosResponse>>
    {
        private readonly IEmpresaRepositorio _IEmpresaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmpresaObterTodosHandler(IMediator mediator, IMapper mapper, IEmpresaRepositorio repository)
        {
            _IEmpresaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<RetornoPaginadoGenerico<EmpresaObterTodosResponse>> Handle(EmpresaObterTodosRequest request, CancellationToken cancellationToken)
        {

            //var filtro = new ProjetoListarTodosFiltro(request);
            //var criterioWhere = filtro.CriterioWhere;
            //var criterioOrderBy = filtro.CriterioOrderBy;
            //var criterioInclude = filtro.Includes;


            //List<Projeto> lista = _iProjetoRepositorio.ObterTodos().ToList();

            List<Empresa> lista = _IEmpresaRepositorio.BuscarTodos();

            List<EmpresaObterTodosResponse> listaResponse = _mapper.Map<List<EmpresaObterTodosResponse>>(lista);

            RetornoPaginadoGenerico<EmpresaObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<EmpresaObterTodosResponse>
            {
                Modelos = listaResponse,
                ItemPorPagina = 1,
                Pagina = 10,
                TotalRegistros = listaResponse.Count()
            };
            return await Task.FromResult(retornoPaginado);
        }
    }

}
