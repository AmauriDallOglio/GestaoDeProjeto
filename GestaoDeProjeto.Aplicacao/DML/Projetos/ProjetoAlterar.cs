using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoAlterarRequest : IRequest<ResultadoOperacao<ProjetoAlterarResponse>>
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public short Status { get; set; }

    }

    public class ProjetoAlterarResponse
    {
        public int Id { get; set; }
    }



    public class ProjetoAlterarHandler : IRequestHandler<ProjetoAlterarRequest, ResultadoOperacao<ProjetoAlterarResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoAlterarHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<ProjetoAlterarResponse>> Handle(ProjetoAlterarRequest request, CancellationToken cancellationToken)
        {

            Projeto entidade = _mapper.Map<Projeto>(request);

            Projeto entidadeBD = await _iProjetoRepositorio.AlterarAsync(entidade, true, cancellationToken);

            ProjetoAlterarResponse response = _mapper.Map<ProjetoAlterarResponse>(entidadeBD);
 
            Task<ResultadoOperacao<ProjetoAlterarResponse>> sucesso = ResultadoOperacao<ProjetoAlterarResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso.Result;
        }
    }

}