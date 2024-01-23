namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Projeto
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public short Status { get; set; }
    }

    public enum StatusProjeto
    {
        EmAndamento = 1,
        Concluido = 2,
        PendenteAprovacao = 3,
        EmRevisao = 4,
        AguardandoRecursos = 5,
        Atrasado = 6
    }

}
