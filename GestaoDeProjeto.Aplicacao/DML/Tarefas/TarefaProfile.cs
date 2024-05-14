using AutoMapper;
using GestaoDeProjeto.Dominio.Entidade;

namespace GestaoDeProjeto.Aplicacao.DML.Tarefas
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaIncluirRequest>().ReverseMap();
            CreateMap<Tarefa, TarefaIncluirResponse>().ReverseMap();
 

        }
    }
}
