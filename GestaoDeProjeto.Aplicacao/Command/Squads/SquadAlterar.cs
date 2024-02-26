using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command.Squads
{
    public class SquadAlterarRequest : IRequest<ResultadoOperacao<SquadAlterarResponse>>
    {
 
        public string Descricao { get; set; } = string.Empty;
 
        public bool Inativo { get; set; }

    }

    public class SquadAlterarResponse
    {
        public int Id { get; set; }
    }


    public class SquadAlterarHandler : IRequestHandler<SquadAlterarRequest, ResultadoOperacao<SquadAlterarResponse>>
    {
        private readonly ISquadRepositorio _iSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadAlterarHandler(IMediator mediator, IMapper mapper, ISquadRepositorio repository)
        {
            _iSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<SquadAlterarResponse>> Handle(SquadAlterarRequest request, CancellationToken cancellationToken)
        {

            Squad entidade = _mapper.Map<Squad>(request);

            Squad entidadeBD = _iSquadRepositorio.Alterar(entidade, true);

            SquadAlterarResponse response = _mapper.Map<SquadAlterarResponse>(entidadeBD);

            Task<ResultadoOperacao<SquadAlterarResponse>> sucesso = ResultadoOperacao<SquadAlterarResponse>.RetornaSuccessoAsync(response, "Squad", "Sucesso");
            return sucesso;
        }
    }

}
