using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command.Projetos
{
    public class ProjetoExcluirRequest : IRequest<ResultadoOperacao<ProjetoExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class ProjetoExcluirResponse
    {
        public int Id { get; set; }
    }


    public class ProjetoExcluirHandler : IRequestHandler<ProjetoExcluirRequest, ResultadoOperacao<ProjetoExcluirResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoExcluirHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<ProjetoExcluirResponse>> Handle(ProjetoExcluirRequest request, CancellationToken cancellationToken)
        {

            Projeto entidade = _mapper.Map<Projeto>(request);

            _iProjetoRepositorio.ExcluirEmpresaEProjetos(entidade.Id);

            ProjetoExcluirResponse response = _mapper.Map<ProjetoExcluirResponse>(entidade);
 
            Task<ResultadoOperacao<ProjetoExcluirResponse>> sucesso = ResultadoOperacao<ProjetoExcluirResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso;
        }
    }

}