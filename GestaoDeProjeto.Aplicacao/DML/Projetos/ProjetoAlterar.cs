using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoAlterarRequest : IRequest<ResultadoOperacao<ProjetoAlterarResponse>>
    {
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
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

        public Task<ResultadoOperacao<ProjetoAlterarResponse>> Handle(ProjetoAlterarRequest request, CancellationToken cancellationToken)
        {

            Projeto entidade = _mapper.Map<Projeto>(request);

            Projeto entidadeBD = _iProjetoRepositorio.Alterar(entidade, true);

            ProjetoAlterarResponse response = _mapper.Map<ProjetoAlterarResponse>(entidadeBD);
 
            Task<ResultadoOperacao<ProjetoAlterarResponse>> sucesso = ResultadoOperacao<ProjetoAlterarResponse>.RetornaSuccessoAsync(response, "Projeto", "Sucesso");
            return sucesso;
        }
    }

}