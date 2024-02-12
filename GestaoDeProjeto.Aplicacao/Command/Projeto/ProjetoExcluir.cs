using AutoMapper;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.Command
{
    public class ProjetoExcluirRequest : IRequest<ResultadoOperacao<ProjetoExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class ProjetoExcluirResponse
    {
        public int Id { get; set; }
    }


    public class ProjetoExcluirHandler : IRequestHandler<ProjetoExcluirRequest, ResultadoOperacao<ProjetoExcluirResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoExcluirHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<ProjetoExcluirResponse>> Handle(ProjetoExcluirRequest request, CancellationToken cancellationToken)
        {

            var entidade = _mapper.Map<Dominio.Entidade.Projeto>(request);

            var entidadeBD = _iProjetoRepositorio.Alterar(entidade, true);
            var dto = _mapper.Map<ProjetoExcluirResponse>(entidadeBD);

            var respostas = new ProjetoExcluirResponse
            {
                Id = dto.Id
            };
            Task<ResultadoOperacao<ProjetoExcluirResponse>> sucesso = ResultadoOperacao<ProjetoExcluirResponse>.RetornaSuccessoAsync(respostas, "Projeto", "Sucesso");
            return sucesso;
        }
    }

}