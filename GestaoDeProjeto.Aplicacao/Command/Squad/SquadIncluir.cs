using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command
{
    public class SquadIncluirRequest : IRequest<ResultadoOperacao<SquadIncluirResponse>>
    {

        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }

    }

    public class SquadIncluirResponse
    {
        public int Id { get; set; }
    }


    public class SquadIncluirHandler : IRequestHandler<SquadIncluirRequest, ResultadoOperacao<SquadIncluirResponse>>
    {
        private readonly ISquadRepositorio _iSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadIncluirHandler(IMediator mediator, IMapper mapper, ISquadRepositorio repository)
        {
            _iSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<SquadIncluirResponse>> Handle(SquadIncluirRequest request, CancellationToken cancellationToken)
        {

            Squad entidade = _mapper.Map<Squad>(request);

            entidade = _iSquadRepositorio.Inserir(entidade, true);

            SquadIncluirResponse response = _mapper.Map<SquadIncluirResponse>(entidade);

            Task<ResultadoOperacao<SquadIncluirResponse>> sucesso = ResultadoOperacao<SquadIncluirResponse>.RetornaSuccessoAsync(response, "Squad", "Sucesso");
            
            return sucesso;
        }
    }
}
