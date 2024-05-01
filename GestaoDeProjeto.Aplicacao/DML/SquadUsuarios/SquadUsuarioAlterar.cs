using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.SquadUsuarios
{
    public class SquadUsuarioAlterarRequest : IRequest<ResultadoOperacao<SquadUsuarioAlterarResponse>>
    {
        public int Id { get; set; }

        public bool Inativo { get; set; }
    }

    public class SquadUsuarioAlterarResponse
    {
        public int Id { get; set; }
    }

    public class SquadUsuarioAlterarHandler : IRequestHandler<SquadUsuarioAlterarRequest, ResultadoOperacao<SquadUsuarioAlterarResponse>>
    {
        private readonly ISquadUsuarioRepositorio _iSquadUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadUsuarioAlterarHandler(IMediator mediator, IMapper mapper, ISquadUsuarioRepositorio repository)
        {
            _iSquadUsuarioRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<SquadUsuarioAlterarResponse>> Handle(SquadUsuarioAlterarRequest request, CancellationToken cancellationToken)
        {

            SquadUsuario entidade = _mapper.Map<SquadUsuario>(request);

            SquadUsuario entidadeBD = await _iSquadUsuarioRepositorio.AlterarAsync(entidade, true, cancellationToken);

            SquadUsuarioAlterarResponse response = _mapper.Map<SquadUsuarioAlterarResponse>(entidadeBD);

            Task<ResultadoOperacao<SquadUsuarioAlterarResponse>> sucesso = ResultadoOperacao<SquadUsuarioAlterarResponse>.RetornaSuccessoAsync(response, "SquadUsuario", "Sucesso");
            return sucesso.Result;
        }
    }
}
