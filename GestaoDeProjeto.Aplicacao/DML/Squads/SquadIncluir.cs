using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
{
    public class SquadIncluirRequest : IRequest<ResultadoOperacao<SquadIncluirResponse>>
    {
        [Required(ErrorMessage = "Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;
        //public byte[]? ArrayImagem { get; set; }
        //public string? UrlImagem { get; set; } = string.Empty;
 

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

        public async Task<ResultadoOperacao<SquadIncluirResponse>> Handle(SquadIncluirRequest request, CancellationToken cancellationToken)
        {

            Squad entidade = _mapper.Map<Squad>(request);

            entidade.Incluir();

            entidade = await _iSquadRepositorio.InserirAsync(entidade, true, cancellationToken);

            SquadIncluirResponse response = _mapper.Map<SquadIncluirResponse>(entidade);

            Task<ResultadoOperacao<SquadIncluirResponse>> sucesso = ResultadoOperacao<SquadIncluirResponse>.RetornaSuccessoAsync(response, "Squad", "Sucesso");
            
            return sucesso.Result;
        }
    }
}
