using System.Security.Principal;

namespace GestaoDeProjeto.Infra.Contexto
{
    internal static class script
    {
        /*
         

         -- Tabela Empresa
        CREATE TABLE Empresa (
            Id INT PRIMARY KEY IDENTITY(1,1),
	        RazaoSocial varchar(300) NOT NULL,
	        NomeFantasia varchar(300) NOT NULL,
	        DataCadastro datetime NOT NULL,
	        Cnpj varchar(14) NOT NULL,
	        PessoaContato varchar(300), 
	        Email varchar(300),
	        Telefone varchar(50),
	        Endereco varchar(300),
	        Numero varchar(20),
	        Complemento varchar(100),
	        Cep varchar(8),
	        Cidade varchar(100),
	        Estado char(2),
	        Inativo bit default 0 NOT NULL
        );
        GO
        CREATE UNIQUE INDEX IDX_Empresa_UQ  ON Empresa (Cnpj)


 
 
        -- Tabela Projeto
        CREATE TABLE Projeto (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Id_Empresa INT NOT NULL, 
            NomeProjeto VARCHAR(100) NOT NULL,
            Descricao VARCHAR(MAX) NOT NULL,
            DataInicio DATE NOT NULL,
            DataFim DATE NULL,
            Situacao tinyint NOT NULL
        );

        ALTER TABLE Projeto ADD CONSTRAINT FK_Projeto_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa(Id);
        GO
        CREATE UNIQUE INDEX IDX_Projeto_UQ ON Projeto(Id_Empresa, Id);
        GO





        -- Tabela de Associação ProjetoSquad
	    CREATE TABLE ProjetoSquad
	    (
		    Id INT PRIMARY KEY IDENTITY(1,1),
		    Id_Empresa INT NOT NULL, 
		    Id_Projeto INT NOT NULL, 
            Id_Squad INT NOT NULL, 
	        Inativo bit default 0 NOT NULL
	    )
	    GO
	    ALTER TABLE ProjetoSquad ADD CONSTRAINT FK_ProjetoSquad_Tenant FOREIGN KEY (Id_Empresa) REFERENCES Empresa(Id)
	    GO
	    ALTER TABLE ProjetoSquad ADD CONSTRAINT FK_ProjetoSquad_Projeto FOREIGN KEY (Id_Projeto) REFERENCES Projeto(Id)
	    GO
	    ALTER TABLE ProjetoSquad ADD CONSTRAINT FK_ProjetoSquad_Squad FOREIGN KEY (Id_Squad) REFERENCES Squad(Id)
	    GO
	    CREATE UNIQUE INDEX IDX_ProjetoSquad_UQ  ON ProjetoSquad (Id_Empresa, Id_Projeto, Id_Squad)




        
 
         -- Tabela Squad
        CREATE TABLE Squad (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Id_Empresa INT NOT NULL, 
            Descricao VARCHAR(300) NOT NULL,
            ArrayImagem VARBINARY(MAX) null,
            UrlImagem VARCHAR(MAX) null,
            Inativo BIT DEFAULT 0 NOT NULL
        );

        ALTER TABLE Squad ADD CONSTRAINT FK_Squad_Empresa FOREIGN KEY (Id_Empresa) REFERENCES Empresa(Id);
        CREATE UNIQUE INDEX IDX_Squad_UQ ON Squad (Id_Empresa, Id);



 




        Tarefas:
        A tabela Tarefas tem uma chave primária TarefaID.
        Relacionamentos:
        Uma tarefa pertence a um projeto (ProjetoID).
        Uma tarefa pode ter várias atribuições (Atribuicoes).
        Uma tarefa pode estar associada a várias sprints (TarefasNaSprint).
        Uma tarefa pode ter vários resultados de conclusão (ResultadosConclusao).
        Membros da Equipe:

        A tabela MembrosEquipe tem uma chave primária MembroID.
        Relacionamento: Uma atribuição (Atribuicoes) pertence a um membro da equipe (MembroID).
        Atribuições:

        A tabela Atribuicoes tem uma chave primária AtribuicaoID.
        Relacionamentos:
        Uma atribuição pertence a uma tarefa (TarefaID).
        Uma atribuição pertence a um membro da equipe (MembroID).
        Sprints:

        A tabela Sprints tem uma chave primária SprintID.
        Relacionamento: Uma sprint pertence a um projeto (ProjetoID).
        Tarefas na Sprint:

        A tabela TarefasNaSprint tem uma chave primária TarefaSprintID.
        Relacionamentos:
        Uma tarefa na sprint pertence a uma tarefa (TarefaID).
        Uma tarefa na sprint pertence a uma sprint (SprintID).
        Resultados de Conclusão:

        A tabela ResultadosConclusao tem uma chave primária ResultadoID.
        Relacionamento: Um resultado de conclusão pertence a uma tarefa (TarefaID).
        Este é um esboço básico do diagrama.Ao criar o diagrama usando ferramentas apropriadas, você pode adicionar detalhes visuais, como cardinalidades e tipos de relacionamento. Certifique-se de ajustar conforme necessário com base nos requisitos específicos do seu sistema de gestão de projetos.


        */

    }
}
