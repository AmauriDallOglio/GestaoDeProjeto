using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Aplicacao.Negocio
{
    public class ProjetoAlterarRequest : IRequest<ResultadoOperacao<ProjetoAlterarResponse>>
    {
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }

    }

    public class ProjetoAlterarResponse : Projeto
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

            var entidade = _mapper.Map<Dominio.Entidade.Projeto>(request);

            var entidadeBD = _iProjetoRepositorio.Alterar(entidade, true);
            var dto = _mapper.Map<ProjetoAlterarResponse>(entidadeBD);

            var respostas = new ProjetoAlterarResponse
            {
                Id = dto.Id
            };
            Task<ResultadoOperacao<ProjetoAlterarResponse>> sucesso = ResultadoOperacao<ProjetoAlterarResponse>.RetornaSuccessoAsync(respostas, "Sucesso");
            return sucesso;
        }
    }

}