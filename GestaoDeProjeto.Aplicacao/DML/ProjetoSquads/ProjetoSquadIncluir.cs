using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    public class ProjetoSquadIncluirRequest : IRequest<ResultadoOperacao<ProjetoSquadIncluirResponse>>
    {
        public int Id_Projeto { get; set; }
        public int Id_Squad { get; set; }
        public bool Inativo { get; set; }

    }

    public class ProjetoSquadIncluirResponse
    {
        public int Id { get; set; }
    }

    public class ProjetoSquadIncluirHandler : IRequestHandler<ProjetoSquadIncluirRequest, ResultadoOperacao<ProjetoSquadIncluirResponse>>
    {
        private readonly IProjetoSquadRepositorio _iProjetoSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoSquadIncluirHandler(IMediator mediator, IMapper mapper, IProjetoSquadRepositorio repository)
        {
            _iProjetoSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<ProjetoSquadIncluirResponse>> Handle(ProjetoSquadIncluirRequest request, CancellationToken cancellationToken)
        {

            ProjetoSquad entidade = _mapper.Map<ProjetoSquad>(request);

            entidade = _iProjetoSquadRepositorio.Inserir(entidade, true);

            ProjetoSquadIncluirResponse response = _mapper.Map<ProjetoSquadIncluirResponse>(entidade);

            Task<ResultadoOperacao<ProjetoSquadIncluirResponse>> sucesso = ResultadoOperacao<ProjetoSquadIncluirResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso;
        }
    }
}
