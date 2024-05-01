using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    public class ProjetoSquadAlterarRequest : IRequest<ResultadoOperacao<ProjetoSquadAlterarResponse>>
    {
        public int Id { get; set; }
 
        public bool Inativo { get; set; }
    }
    
    public class ProjetoSquadAlterarResponse
    {
        public int Id { get; set; }
    }

    public class ProjetoSquadAlterarHandler : IRequestHandler<ProjetoSquadAlterarRequest, ResultadoOperacao<ProjetoSquadAlterarResponse>>
    {
        private readonly IProjetoSquadRepositorio _iProjetoSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoSquadAlterarHandler(IMediator mediator, IMapper mapper, IProjetoSquadRepositorio repository)
        {
            _iProjetoSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<ProjetoSquadAlterarResponse>> Handle(ProjetoSquadAlterarRequest request, CancellationToken cancellationToken)
        {

            ProjetoSquad entidade = _mapper.Map<ProjetoSquad>(request);

            ProjetoSquad entidadeBD = await _iProjetoSquadRepositorio.AlterarAsync(entidade, true, cancellationToken);

            ProjetoSquadAlterarResponse response = _mapper.Map<ProjetoSquadAlterarResponse>(entidadeBD);

            Task<ResultadoOperacao<ProjetoSquadAlterarResponse>> sucesso = ResultadoOperacao<ProjetoSquadAlterarResponse>.RetornaSuccessoAsync(response, "ProjetoSquad", "Sucesso");
            return sucesso.Result;
        }
    }
}
