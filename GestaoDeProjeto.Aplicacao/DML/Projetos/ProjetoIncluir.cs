using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoIncluirRequest : IRequest<ResultadoOperacao<ProjetoIncluirResponse>>
    {
        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        public string NomeProjeto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }

        [Required(ErrorMessage = "Situacao é obrigatório.")]
        public short Situacao { get; set; }

    }

    public class ProjetoIncluirResponse
    {
        public int Id { get; set; }
    }


    public class ProjetoIncluirHandler : IRequestHandler<ProjetoIncluirRequest, ResultadoOperacao<ProjetoIncluirResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoIncluirHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<ProjetoIncluirResponse>> Handle(ProjetoIncluirRequest request, CancellationToken cancellationToken)
        {

            Projeto entidade = _mapper.Map<Projeto>(request);
            entidade.Inserir();
            entidade = await _iProjetoRepositorio.InserirAsync(entidade, true, cancellationToken);

            ProjetoIncluirResponse response = _mapper.Map<ProjetoIncluirResponse>(entidade);

            Task<ResultadoOperacao<ProjetoIncluirResponse>> sucesso = ResultadoOperacao<ProjetoIncluirResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso.Result;
        }
    }
}
