using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Empresas
{
    public class EmpresaObterTodosRequest : IRequest<RetornoPaginadoGenerico<EmpresaObterTodosResponse>>
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public bool Situacao { get; set; }

    }

    public class EmpresaObterTodosResponse : Empresa
    {
        public int QuantidadeSquad { get; set; }
        public int QuantidadeUsuario { get; set; }
        public int QuantidadeProjeto { get; set; }
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

            var filtro = new EmpresaObterTodosFiltro(request);
            var criterioWhere = filtro.CriterioWhere;
            var criterioOrderBy = filtro.CriterioOrderBy;
            var criterioInclude = filtro.Includes;


 
            List<Empresa> lista = await _IEmpresaRepositorio.BuscarTodosAsync();

            List<EmpresaObterTodosResponse> listaResponse = _mapper.Map<List<EmpresaObterTodosResponse>>(lista);

            List<EmpresaObterTodosResponse> response = new List<EmpresaObterTodosResponse>();
            foreach (var item in listaResponse)
            {
                item.QuantidadeProjeto = item.ListaProjetos != null ? item.ListaProjetos.Count : 0;
                item.QuantidadeSquad = item.ListaSquads != null ? item.ListaSquads.Count : 0;
                item.QuantidadeUsuario = item.ListaUsuarios != null ? item.ListaUsuarios.Count : 0;

                response.Add(item);
            
            }

            RetornoPaginadoGenerico<EmpresaObterTodosResponse> retornoPaginado = new RetornoPaginadoGenerico<EmpresaObterTodosResponse>
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
