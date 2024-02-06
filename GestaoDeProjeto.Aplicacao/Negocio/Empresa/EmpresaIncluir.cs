using AutoMapper;
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
    public class EmpresaIncluirRequest : IRequest<ResultadoOperacao<EmpresaIncluirResponse>>
    {
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }

    }

    public class EmpresaIncluirResponse
    {
        public int Id { get; set; }
    }


    public class EmpresaIncluirHandler : IRequestHandler<EmpresaIncluirRequest, ResultadoOperacao<EmpresaIncluirResponse>>
    {
        private readonly IProjetoRepositorio _iProjetoRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmpresaIncluirHandler(IMediator mediator, IMapper mapper, IProjetoRepositorio repository)
        {
            _iProjetoRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<EmpresaIncluirResponse>> Handle(EmpresaIncluirRequest request, CancellationToken cancellationToken)
        {

            var entidade = _mapper.Map<Dominio.Entidade.Empresa>(request);

            var entidadeBD = _iProjetoRepositorio.Inserir(entidade, true);
            var dto = _mapper.Map<EmpresaIncluirResponse>(entidadeBD);

            var respostas = new EmpresaIncluirResponse
            {
                Id = dto.Id
            };
            Task<ResultadoOperacao<EmpresaIncluirResponse>> sucesso = ResultadoOperacao<EmpresaIncluirResponse>.RetornaSuccessoAsync(respostas, "Sucesso");
            return sucesso;
        }
    }
}
