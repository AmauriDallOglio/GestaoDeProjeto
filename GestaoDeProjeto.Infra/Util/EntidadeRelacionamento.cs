namespace GestaoDeProjeto.Infra.Modelo
{
    internal static class EntidadeRelacionamento
    {

        //Projetos:
        //A tabela Projetos tem uma chave primária ProjetoID.
        //Relacionamento: Um projeto pode ter várias tarefas (Tarefas).
        //CREATE TABLE Projeto(
            //Id INT PRIMARY KEY NOT NULL,
            //NomeProjeto VARCHAR(100) NOT NULL,
            //Descricao VARCHAR(max) NOT NULL,
            //DataInicio DATE NOT NULL,
            //DataFim DATE NULL,
            //Status smallint NOT NULL
        //)
        //CREATE UNIQUE INDEX IDX_Projeto_UQ  ON Projeto(Id)




        //Tarefas:
        //A tabela Tarefas tem uma chave primária TarefaID.
        //Relacionamentos:
        //Uma tarefa pertence a um projeto (ProjetoID).
        //Uma tarefa pode ter várias atribuições (Atribuicoes).
        //Uma tarefa pode estar associada a várias sprints (TarefasNaSprint).
        //Uma tarefa pode ter vários resultados de conclusão (ResultadosConclusao).
        //Membros da Equipe:

        //A tabela MembrosEquipe tem uma chave primária MembroID.
        //Relacionamento: Uma atribuição (Atribuicoes) pertence a um membro da equipe (MembroID).
        //Atribuições:

        //A tabela Atribuicoes tem uma chave primária AtribuicaoID.
        //Relacionamentos:
        //Uma atribuição pertence a uma tarefa (TarefaID).
        //Uma atribuição pertence a um membro da equipe (MembroID).
        //Sprints:

        //A tabela Sprints tem uma chave primária SprintID.
        //Relacionamento: Uma sprint pertence a um projeto (ProjetoID).
        //Tarefas na Sprint:

        //A tabela TarefasNaSprint tem uma chave primária TarefaSprintID.
        //Relacionamentos:
        //Uma tarefa na sprint pertence a uma tarefa (TarefaID).
        //Uma tarefa na sprint pertence a uma sprint (SprintID).
        //Resultados de Conclusão:

        //A tabela ResultadosConclusao tem uma chave primária ResultadoID.
        //Relacionamento: Um resultado de conclusão pertence a uma tarefa (TarefaID).
        //Este é um esboço básico do diagrama.Ao criar o diagrama usando ferramentas apropriadas, você pode adicionar detalhes visuais, como cardinalidades e tipos de relacionamento. Certifique-se de ajustar conforme necessário com base nos requisitos específicos do seu sistema de gestão de projetos.


    }
}
