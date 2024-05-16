using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.InterfaceRepositorio;
using GestaoDeProjeto.Dominio.Util;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Aplicacao.DML.Tarefas
{
    public class TarefaAlterarRequest : IRequest<ResultadoOperacao<TarefaAlterarResponse>>
    {
        [Required(ErrorMessage = "Id projeto da tarefa é obrigatória.")]
        public int Id_Projeto { get; set; }

        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        [StringLength(255)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O objetivo da tarefa é obrigatório.")]
        [StringLength(5000)]
        public string Objetivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O resultado da tarefa é obrigatório.")]
        [StringLength(5000)]
        public string Resultado { get; set; } = string.Empty;

        [Required(ErrorMessage = "A fase da tarefa é obrigatória.")]
        public byte Fase { get; set; }

        [Required(ErrorMessage = "A ordem da tarefa é obrigatória.")]
        public byte Ordem { get; set; }

        [Required(ErrorMessage = "As horas estimadas da tarefa são obrigatórias.")]
        public int HorasEstimada { get; set; }

        [Required(ErrorMessage = "A data inicial estimada da tarefa é obrigatória.")]
        public DateTime DataInicialEstimado { get; set; }

        public DateTime? DataFinalEstimado { get; set; }

        [Required(ErrorMessage = "A data inicial realizada da tarefa é obrigatória.")]
        public DateTime DataInicialRealizado { get; set; }

        public DateTime? DataFinalRealizado { get; set; }

        [StringLength(50)]
        public string Sprint { get; set; } = string.Empty;

        [Required(ErrorMessage = "Situação da tarefa é obrigatória.")]
        public short Situacao { get; set; }

}

    public class TarefaAlterarResponse : Tarefa
    {


    }

    public class TarefaAlterarHandler : IRequestHandler<TarefaAlterarRequest, ResultadoOperacao<TarefaAlterarResponse>>
    {
        private readonly ITarefaRepositorio _iTarefaRepositorio;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TarefaAlterarHandler(IMediator mediator, IMapper mapper, ITarefaRepositorio repository)
        {
            _iTarefaRepositorio = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultadoOperacao<TarefaAlterarResponse>> Handle(TarefaAlterarRequest request, CancellationToken cancellationToken)
        {
            Tarefa entidade = _mapper.Map<Tarefa>(request);
            entidade.Alterar(request.HorasEstimada, request.Situacao);

            entidade = await _iTarefaRepositorio.InserirAsync(entidade, true, cancellationToken);

            TarefaAlterarResponse response = _mapper.Map<TarefaAlterarResponse>(entidade);

            Task<ResultadoOperacao<TarefaAlterarResponse>> sucesso = ResultadoOperacao<TarefaAlterarResponse>.RetornaSuccessoAsync(response, "Tarefa", "Sucesso");
            return sucesso.Result;
        }
    }

}
