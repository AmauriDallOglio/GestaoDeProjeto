using AutoMapper;
using GestaoDeProjeto.Aplicacao.Command.Projetos;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Aplicacao.Command.Empresas
{
    public class EmpresaExcluirRequest : IRequest<ResultadoOperacao<EmpresaExcluirResponse>>
    {
        public int Id { get; set; }
    }

    public class EmpresaExcluirResponse
    {
        public int Id { get; set; }
    }


    public class EmpresaExcluirHandler : IRequestHandler<EmpresaExcluirRequest, ResultadoOperacao<EmpresaExcluirResponse>>
    {
        private readonly IEmpresaRepositorio _iEmpresaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmpresaExcluirHandler(IMediator mediator, IMapper mapper, IEmpresaRepositorio repository)
        {
            _iEmpresaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<ResultadoOperacao<EmpresaExcluirResponse>> Handle(EmpresaExcluirRequest request, CancellationToken cancellationToken)
        {

            Empresa entidade = _mapper.Map<Empresa>(request);

            _iEmpresaRepositorio.Deletar(entidade);

            EmpresaExcluirResponse response = _mapper.Map<EmpresaExcluirResponse>(entidade);

            Task<ResultadoOperacao<EmpresaExcluirResponse>> sucesso = ResultadoOperacao<EmpresaExcluirResponse>.RetornaSuccessoAsync(response, "Empresa", "Sucesso");
            return sucesso;
        }
    }

}
