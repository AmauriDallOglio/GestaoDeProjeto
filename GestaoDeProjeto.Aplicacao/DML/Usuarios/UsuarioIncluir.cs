using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioIncluirRequest : IRequest<ResultadoOperacao<UsuarioIncluirResponse>>
    {
 
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public byte Situacao { get; set; }
    }

    public class UsuarioIncluirResponse
    {
        public int Id { get; set; }
    }

    public class UsuarioIncluirHandler : IRequestHandler<UsuarioIncluirRequest, ResultadoOperacao<UsuarioIncluirResponse>>
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuarioIncluirHandler(IMediator mediator, IMapper mapper, IUsuarioRepositorio iusuarioRepositorio)
        {
            _iUsuarioRepositorio = iusuarioRepositorio;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<UsuarioIncluirResponse>> Handle(UsuarioIncluirRequest request, CancellationToken cancellationToken)
        {

            Usuario entidade = _mapper.Map<Usuario>(request);
            entidade.Incluir();

            entidade = await _iUsuarioRepositorio.InserirAsync(entidade, true, cancellationToken);

            UsuarioIncluirResponse response = _mapper.Map<UsuarioIncluirResponse>(entidade);

            Task<ResultadoOperacao<UsuarioIncluirResponse>> sucesso = ResultadoOperacao<UsuarioIncluirResponse>.RetornaSuccessoAsync(response, "Usuario", "Sucesso");

            return await sucesso;
        }
    }

}
