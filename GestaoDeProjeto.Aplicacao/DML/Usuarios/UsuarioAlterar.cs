using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioAlterarRequest : IRequest<ResultadoOperacao<UsuarioAlterarResponse>>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public byte Situacao { get; set; }
    }

    public class UsuarioAlterarResponse
    {
        public int Id { get; set; }
    }

    public class UsuarioAlterarHandler : IRequestHandler<UsuarioAlterarRequest, ResultadoOperacao<UsuarioAlterarResponse>>
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuarioAlterarHandler(IMediator mediator, IMapper mapper, IUsuarioRepositorio repository)
        {
            _iUsuarioRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<UsuarioAlterarResponse>> Handle(UsuarioAlterarRequest request, CancellationToken cancellationToken)
        {

            Usuario entidade = _mapper.Map<Usuario>(request);

            Usuario entidadeBD = await _iUsuarioRepositorio.AlterarAsync(entidade, true, cancellationToken);

            UsuarioAlterarResponse response = _mapper.Map<UsuarioAlterarResponse>(entidadeBD);

            Task<ResultadoOperacao<UsuarioAlterarResponse>> sucesso = ResultadoOperacao<UsuarioAlterarResponse>.RetornaSuccessoAsync(response, "Usuario", "Sucesso");
            return await sucesso;
        }
    }
}
