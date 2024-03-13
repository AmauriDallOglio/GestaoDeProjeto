using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.ProjetoSquads
{
    public class ProjetoSquadExcluirRequest  : IRequest<ResultadoOperacao<ProjetoSquadExcluirResponse>>
    {
        public int Id { get; set; }

 
    }


    public class ProjetoSquadExcluirResponse
    {
        public int Id { get; set; }
    }




    public class ProjetoSquadExcluirHandler : IRequestHandler<ProjetoSquadExcluirRequest, ResultadoOperacao<ProjetoSquadExcluirResponse>>
    {
        private readonly IProjetoSquadRepositorio _iProjetoSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoSquadExcluirHandler(IMediator mediator, IMapper mapper, IProjetoSquadRepositorio repository)
        {
            _iProjetoSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<ProjetoSquadExcluirResponse>> Handle(ProjetoSquadExcluirRequest request, CancellationToken cancellationToken)
        {


            ProjetoSquad entidade = _mapper.Map<ProjetoSquad>(request);

            _iProjetoSquadRepositorio.Deletar(entidade, cancellationToken);

            ProjetoSquadExcluirResponse response = _mapper.Map<ProjetoSquadExcluirResponse>(entidade);

            Task<ResultadoOperacao<ProjetoSquadExcluirResponse>> sucesso = ResultadoOperacao<ProjetoSquadExcluirResponse>.RetornaSuccessoAsync(response, "ProjetoSquad", "Sucesso");
            return sucesso;
        }
    }

}
