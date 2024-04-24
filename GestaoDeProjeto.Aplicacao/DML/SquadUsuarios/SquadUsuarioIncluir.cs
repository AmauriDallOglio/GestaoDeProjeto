using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.DML.SquadUsuarios
{
    public class SquadUsuarioIncluirRequest : IRequest<ResultadoOperacao<SquadUsuarioIncluirResponse>>
    {
        [Required(ErrorMessage = "Squad é obrigatório.")]
        public int Id_Squad { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório.")]
        public int Id_Usuario { get; set; }

    }

    public class SquadUsuarioIncluirResponse
    {
        public int Id { get; set; }
    }


    public class SquadIncluirHandler : IRequestHandler<SquadUsuarioIncluirRequest, ResultadoOperacao<SquadUsuarioIncluirResponse>>
    {
        private readonly ISquadUsuarioRepositorio _iSquadUsuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadIncluirHandler(IMediator mediator, IMapper mapper, ISquadUsuarioRepositorio iSquadUsuarioRepositorio)
        {
            _iSquadUsuarioRepositorio = iSquadUsuarioRepositorio;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<SquadUsuarioIncluirResponse>> Handle(SquadUsuarioIncluirRequest request, CancellationToken cancellationToken)
        {

            SquadUsuario entidade = _mapper.Map<SquadUsuario>(request);

            entidade.Incluir();

            entidade = await _iSquadUsuarioRepositorio.InserirAsync(entidade, true, cancellationToken);

            SquadUsuarioIncluirResponse response = _mapper.Map<SquadUsuarioIncluirResponse>(entidade);

            Task<ResultadoOperacao<SquadUsuarioIncluirResponse>> sucesso = ResultadoOperacao<SquadUsuarioIncluirResponse>.RetornaSuccessoAsync(response, "SquadUsuario", "Sucesso");

            return sucesso.Result;
        }
    }


}
