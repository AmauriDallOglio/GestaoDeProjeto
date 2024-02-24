using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command.Projetos;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Aplicacao.Command.Empresas
{
    public class EmpresaAlterarRequest : IRequest<ResultadoOperacao<EmpresaAlterarResponse>>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        public string RazaoSocial { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; } = string.Empty;


        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve ter 14 dígitos numéricos.")]
        public string Cnpj { get; set; }


        [Required(ErrorMessage = "O PessoaContato é obrigatório.")]
        public string PessoaContato { get; set; } = string.Empty;


        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
        public string Email { get; set; } = string.Empty;


        [Phone(ErrorMessage = "O formato do telefone é inválido.")]
        public string Telefone { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Endereco é obrigatório.")]
        public string Endereco { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Numero é obrigatório.")]
        public string Numero { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Complemento é obrigatório.")]
        public string Complemento { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Cep é obrigatório.")]
        public string Cep { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Cidade é obrigatório.")]
        public string Cidade { get; set; } = string.Empty;


        [Required(ErrorMessage = "O Estado é obrigatório.")]
        public string Estado { get; set; } = string.Empty;
    }

    public class EmpresaAlterarResponse
    {
        public int Id { get; set; }
    }

    public class EmpresaAlterarHandler : IRequestHandler<EmpresaAlterarRequest, ResultadoOperacao<EmpresaAlterarResponse>>
    {
        private readonly IEmpresaRepositorio _iEmpresaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmpresaAlterarHandler(IMediator mediator, IMapper mapper, IEmpresaRepositorio repository)
        {
            _iEmpresaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<EmpresaAlterarResponse>> Handle(EmpresaAlterarRequest request, CancellationToken cancellationToken)
        {

            Empresa entidade = _mapper.Map<Empresa>(request);

            Empresa entidadeBD = _iEmpresaRepositorio.Alterar(entidade, true);

            EmpresaAlterarResponse response = _mapper.Map<EmpresaAlterarResponse>(entidadeBD);

            Task<ResultadoOperacao<EmpresaAlterarResponse>> sucesso = ResultadoOperacao<EmpresaAlterarResponse>.RetornaSuccessoAsync(response, "Empresa", "Sucesso");
            return sucesso;
        }
    }
}
