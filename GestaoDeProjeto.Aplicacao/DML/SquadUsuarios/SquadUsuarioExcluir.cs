using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.SquadUsuarios
{
    public class SquadUsuarioExcluirRequest : IRequest<ResultadoOperacao<SquadUsuarioExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class SquadUsuarioExcluirResponse
    {
        public int Id { get; set; }
    }


    public class SquadUsuarioExcluirHandler : IRequestHandler<SquadUsuarioExcluirRequest, ResultadoOperacao<SquadUsuarioExcluirResponse>>
    {
        private readonly IProjetoSquadRepositorio _iProjetoSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadUsuarioExcluirHandler(IMediator mediator, IMapper mapper, IProjetoSquadRepositorio repository)
        {
            _iProjetoSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<SquadUsuarioExcluirResponse>> Handle(SquadUsuarioExcluirRequest request, CancellationToken cancellationToken)
        {


            ProjetoSquad entidade = _mapper.Map<ProjetoSquad>(request);

            await _iProjetoSquadRepositorio.DeletarAsync(entidade, true, cancellationToken);

            SquadUsuarioExcluirResponse response = _mapper.Map<SquadUsuarioExcluirResponse>(entidade);

            Task<ResultadoOperacao<SquadUsuarioExcluirResponse>> sucesso = ResultadoOperacao<SquadUsuarioExcluirResponse>.RetornaSuccessoAsync(response, "SquadUsuario", "Sucesso");
            return await sucesso;
        }
    }
}
