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
            Atrasado = 3,
            EmRevisao = 4,
            EmEspera = 5,
            EmAndamentoBaixaPrioridade = 6,
            EmAndamentoMediaPrioridade = 7,
            EmAndamentoAltaPrioridade = 8,
            EmTeste = 9,
            PendenteAprovacao = 10,
            PendenteRecursos = 11,
            AguardandoFeedbackCliente = 12,
            AguardandoAprovacaoInterna = 13,
            Cancelado = 14,
            Concluido = 15
        }

    }
}
