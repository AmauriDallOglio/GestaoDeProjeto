using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command
{
    public class ProjetoIncluirRequest : IRequest<ResultadoOperacao<ProjetoIncluirResponse>>
    {

        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }

    }

    public class ProjetoIncluirResponse
    {
        public int Id { get; set; }
    }


    public class ProjetoIncluirHandler : IRequestHandler<ProjetoIncluirRequest, ResultadoOperacao<ProjetoIncluirResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoIncluirHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<ProjetoIncluirResponse>> Handle(ProjetoIncluirRequest request, CancellationToken cancellationToken)
        {

            Projeto entidade = _mapper.Map<Projeto>(request);

            entidade = _iProjetoRepositorio.Inserir(entidade, true);

            ProjetoIncluirResponse response = _mapper.Map<ProjetoIncluirResponse>(entidade);


            Task<ResultadoOperacao<ProjetoIncluirResponse>> sucesso = ResultadoOperacao<ProjetoIncluirResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso;
        }
    }
}
