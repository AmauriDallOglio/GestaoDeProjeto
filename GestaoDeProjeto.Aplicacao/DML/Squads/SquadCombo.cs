using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Projetos;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Aplicacao.DML.Squads
{
    public class SquadComboRequest : IRequest<List<SquadComboResponse>>
    {

    }

    public class SquadComboResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = String.Empty;
    }

    public class ProjetoComboHandler : IRequestHandler<SquadComboRequest, List<SquadComboResponse>>
    {
        private readonly ISquadRepositorio _iSquadRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoComboHandler(IMediator mediator, IMapper mapper, ISquadRepositorio repository)
        {
            _iSquadRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<SquadComboResponse>> Handle(SquadComboRequest request, CancellationToken cancellationToken)
        {
            List<SquadComboResponse> lista = new List<SquadComboResponse>();
            IQueryable<Squad> projetos = _iSquadRepositorio.ObterTodos();
            List<SquadComboResponse> response = _mapper.Map<List<SquadComboResponse>>(projetos);
            return response;
        }
    }
}
