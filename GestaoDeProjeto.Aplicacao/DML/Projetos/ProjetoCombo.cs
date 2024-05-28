using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using MediatR;

namespace GestaoDeProjeto.Aplicacao.DML.Projetos
{
    public class ProjetoComboRequest : IRequest<List<ProjetoComboResponse>>
    {

    }

    public class ProjetoComboResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = String.Empty;
    }

    public class ProjetoComboHandler : IRequestHandler<ProjetoComboRequest, List<ProjetoComboResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoComboHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<ProjetoComboResponse>> Handle(ProjetoComboRequest request, CancellationToken cancellationToken)
        {
            List<ProjetoComboResponse> lista = new List<ProjetoComboResponse>();
            IQueryable<Projeto> projetos = _iProjetoRepositorio.ObterTodos();
            //foreach (Projeto projeto in projetos)
            //{
            //    var item = _mapper.Map<ProjetoComboResponse>(projeto);
            //    lista.Add(item);
            //}

            List<ProjetoComboResponse> response = _mapper.Map<List<ProjetoComboResponse>>(projetos);

            return response;
        }
    }
}
 