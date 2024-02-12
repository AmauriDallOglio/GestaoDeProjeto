using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.Command
{
    public class EmpresaIncluirRequest : IRequest<ResultadoOperacao<EmpresaIncluirResponse>>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        public string RazaoSocial { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve ter 14 dígitos numéricos.")]
        public string Cnpj { get; set; }

        public string PessoaContato { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "O formato do telefone é inválido.")]
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

    }

    public class EmpresaIncluirResponse
    {
        public int Id { get; set; }
    }


    public class EmpresaIncluirHandler : IRequestHandler<EmpresaIncluirRequest, ResultadoOperacao<EmpresaIncluirResponse>>
    {
        private readonly IEmpresaRepositorio _iEmpresaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmpresaIncluirHandler(IMediator mediator, IMapper mapper, IEmpresaRepositorio repository)
        {
            _iEmpresaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<EmpresaIncluirResponse>> Handle(EmpresaIncluirRequest request, CancellationToken cancellationToken)
        {

            Empresa entidade = _mapper.Map<Empresa>(request);

            entidade.DadosDoIncluir();

            entidade = _iEmpresaRepositorio.Inserir(entidade, true);

            EmpresaIncluirResponse response = _mapper.Map<EmpresaIncluirResponse>(entidade);

            Task<ResultadoOperacao<EmpresaIncluirResponse>> sucesso = ResultadoOperacao<EmpresaIncluirResponse>.RetornaSuccessoAsync(response, "Empresa", "Sucesso");

            return await sucesso;
        }
    }
}
