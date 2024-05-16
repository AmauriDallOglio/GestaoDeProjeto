namespace GestaoDeProjeto.Dominio.Util
{
    public class Enums
    {
        public enum StatusProjeto : int
        {
            EmAndamento = 1,
            Concluido = 2,
            PendenteAprovacao = 3,
            EmRevisao = 4,
            AguardandoRecursos = 5,
            Atrasado = 6
        }

        public enum Situacao
        {
            Ativo = 0,
            Inativo = 1
        }

        public enum SituacaoProjeto : byte
        {
            Planejado = 1,
            EmAndamento = 2,
            Concluido = 3,
            Atrasado = 4,
            EmRevisao = 5,
            EmEspera = 6,
            EmAndamentoBaixaPrioridade = 7,
            EmAndamentoMediaPrioridade = 8,
            EmAndamentoAltaPrioridade = 9,
            EmTeste = 10,
            PendenteAprovacao = 11,
            PendenteRecursos = 12,
            AguardandoFeedbackCliente = 13,
            AguardandoAprovacaoInterna = 14
        }

    }
}
