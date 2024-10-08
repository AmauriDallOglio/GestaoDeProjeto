using AutoMapper;
using GestaoDeProjeto.Aplicacao.DML.Tarefas;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaIncluirRequest>().ReverseMap();
            CreateMap<Tarefa, TarefaIncluirResponse>().ReverseMap();

            CreateMap<Tarefa, TarefaAlterarRequest>().ReverseMap();
            CreateMap<Tarefa, TarefaAlterarResponse>().ReverseMap();


            CreateMap<Tarefa, TarefaObterTodosRequest>().ReverseMap();
            CreateMap<Tarefa, TarefaObterTodosResponse>().ReverseMap();

        }
    }
}
