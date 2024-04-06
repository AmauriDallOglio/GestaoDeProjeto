using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Usuarios
{
    public class UsuarioExcluirRequest : IRequest<ResultadoOperacao<UsuarioExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class UsuarioExcluirResponse
    {
        public int Id { get; set; }
    }

    public class UsuarioExcluirHandler : IRequestHandler<UsuarioExcluirRequest, ResultadoOperacao<UsuarioExcluirResponse>>
    {
        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuarioExcluirHandler(IMediator mediator, IMapper mapper, IUsuarioRepositorio repository)
        {
            _iUsuarioRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<UsuarioExcluirResponse>> Handle(UsuarioExcluirRequest request, CancellationToken cancellationToken)
        {

            Usuario entidade = _mapper.Map<Usuario>(request);

            _iUsuarioRepositorio.DeletarAsync(entidade, true, cancellationToken);

            UsuarioExcluirResponse response = _mapper.Map<UsuarioExcluirResponse>(entidade);

            Task<ResultadoOperacao<UsuarioExcluirResponse>> sucesso = ResultadoOperacao<UsuarioExcluirResponse>.RetornaSuccessoAsync(response, "Usuario", "Sucesso");
            return await sucesso;
        }
    }

}
