using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
{
    public class SquadExcluirRequest : IRequest<ResultadoOperacao<SquadExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class SquadExcluirResponse
    {
        public int Id { get; set; }
    }


    public class SquadExcluirHandler : IRequestHandler<SquadExcluirRequest, ResultadoOperacao<SquadExcluirResponse>>
    {
        private readonly ISquadRepositorio _iSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadExcluirHandler(IMediator mediator, IMapper mapper, ISquadRepositorio repository)
        {
            _iSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<SquadExcluirResponse>> Handle(SquadExcluirRequest request, CancellationToken cancellationToken)
        {

            Squad entidade = _mapper.Map<Squad>(request);

           await _iSquadRepositorio.DeletarAsync(entidade, true, cancellationToken);

            SquadExcluirResponse response = _mapper.Map<SquadExcluirResponse>(entidade);

            Task<ResultadoOperacao<SquadExcluirResponse>> sucesso = ResultadoOperacao<SquadExcluirResponse>.RetornaSuccessoAsync(response, "Squad", "Sucesso");
            return await sucesso;
        }
    }
}
