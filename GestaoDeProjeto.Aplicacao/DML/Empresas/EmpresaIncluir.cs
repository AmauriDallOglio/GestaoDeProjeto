using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.DML.Empresas
{
    public class EmpresaIncluirRequest : IRequest<ResultadoOperacao<EmpresaIncluirResponse>>
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "A razão social da empresa é obrigatória.")]
        [MaxLength(300, ErrorMessage = "A razão social da empresa não pode ter mais de 300 caracteres.")]
        public string RazaoSocial { get; set; } = string.Empty;


        [Required(ErrorMessage = "O nome fantasia da empresa é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O nome fantasia da empresa não pode ter mais de 300 caracteres.")]
        public string NomeFantasia { get; set; } = string.Empty;


        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve ter 14 dígitos numéricos.")]
        public string Cnpj { get; set; } = string.Empty;


        [Required(ErrorMessage = "O PessoaContato é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O nome da pessoa de contato não pode ter mais de 300 caracteres.")]
        public string PessoaContato { get; set; } = string.Empty;
       

        [EmailAddress(ErrorMessage = "O email da empresa deve ser um endereço de email válido.")]
        [MaxLength(300, ErrorMessage = "O email da empresa não pode ter mais de 300 caracteres.")]
        public string Email { get; set; } = string.Empty;


        //[Phone(ErrorMessage = "O formato do telefone é inválido.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "O telefone da empresa deve conter entre 10 e 15 dígitos numéricos.")]
        [MaxLength(15, ErrorMessage = "O telefone da empresa não pode ter mais de 15 caracteres.")]
        public string Telefone { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Endereco é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O endereço da empresa não pode ter mais de 300 caracteres.")]
        public string Endereco { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Numero é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O número do endereço da empresa não pode ter mais de 20 caracteres.")]
        public string Numero { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Complemento é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O complemento do endereço da empresa não pode ter mais de 100 caracteres.")]
        public string Complemento { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Cep é obrigatório.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP da empresa deve conter exatamente 8 dígitos numéricos.")]
        public string Cep { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Cidade é obrigatório.")]
        [MaxLength(100, ErrorMessage = "A cidade da empresa não pode ter mais de 100 caracteres.")]
        public string Cidade { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [MaxLength(2, ErrorMessage = "O estado da empresa deve ter exatamente 2 caracteres.")]
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

            entidade = await _iEmpresaRepositorio.InserirAsync(entidade, true, cancellationToken);

            EmpresaIncluirResponse response = _mapper.Map<EmpresaIncluirResponse>(entidade);

            Task<ResultadoOperacao<EmpresaIncluirResponse>> sucesso = ResultadoOperacao<EmpresaIncluirResponse>.RetornaSuccessoAsync(response, "Empresa", "Sucesso");

            return await sucesso;
        }
    }
}
