using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command.Squads
{
    public class SquadIncluirRequest : IRequest<ResultadoOperacao<SquadIncluirResponse>>
    {
        public int Id_Empresa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        //public byte[]? ArrayImagem { get; set; }
        //public string? UrlImagem { get; set; } = string.Empty;
        public bool Inativo { get; set; }

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

        public SquadIncluirHandler(IMediator mediator, IMapper mapper, ISquadRepositorio iSquadRepositorio)
        {
            _iSquadRepositorio = iSquadRepositorio;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<SquadIncluirResponse>> Handle(SquadIncluirRequest request, CancellationToken cancellationToken)
        {

            Squad entidade = _mapper.Map<Squad>(request);

            entidade = _iSquadRepositorio.Inserir(entidade, true, cancellationToken);

            SquadIncluirResponse response = _mapper.Map<SquadIncluirResponse>(entidade);

            Task<ResultadoOperacao<SquadIncluirResponse>> sucesso = ResultadoOperacao<SquadIncluirResponse>.RetornaSuccessoAsync(response, "Squad", "Sucesso");
            
            return sucesso;
        }
    }
}
