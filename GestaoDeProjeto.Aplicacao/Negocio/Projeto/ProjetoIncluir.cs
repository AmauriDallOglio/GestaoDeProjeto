using AutoMapper;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Negocio
{
    public class ProjetoIncluirRequest : IRequest<ResultadoOperacao<ProjetoIncluirResponse>>
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }

    }

    public class ProjetoIncluirResponse : Dominio.Entidade.Projeto
    {
        public Guid Id { get; set; }
        public Guid? Id_Imagem { get; set; }
        public Guid Id_Tenant { get; set; }
        public string Referencia { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Inativo { get; set; }
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

        public Task<ResultadoOperacao<ProjetoIncluirResponse>> Handle(ProjetoIncluirRequest request, CancellationToken cancellationToken)
        {

            var entidade = _mapper.Map<Dominio.Entidade.Projeto>(request);

            var entidadeBD = _iProjetoRepositorio.Inserir(entidade, true);
            var dto = _mapper.Map<ProjetoIncluirResponse>(entidadeBD);

            var respostas = new ProjetoIncluirResponse
            {
                Id = Guid.NewGuid(),
            };
            Task<ResultadoOperacao<ProjetoIncluirResponse>> sucesso = ResultadoOperacao<ProjetoIncluirResponse>.RetornaSuccessoAsync(respostas, "Sucesso");
            return sucesso;
        }
    }
}
