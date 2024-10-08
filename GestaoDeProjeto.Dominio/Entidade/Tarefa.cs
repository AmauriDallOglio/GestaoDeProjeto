using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static GestaoDeProjeto.Dominio.Util.Enums;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Tarefa : AuditableEntity<int>, IEmpresaObrigatorio
    {
        [Required]
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; } = new Empresa();

        [Required]
        public int Id_Projeto { get; set; }
        public Projeto Projeto { get; set; } = new Projeto();



        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O objetivo da tarefa é obrigatório.")]
        [StringLength(5000)]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "O resultado da tarefa é obrigatório.")]
        [StringLength(5000)]
        public string Resultado { get; set; }

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
        public string Sprint { get; set; }

        [Required(ErrorMessage = "A situação da tarefa é obrigatória.")]
        public SituacaoProjeto Situacao { get; set; }


 


        public void Incluir(int horasEstimada)
        {
            DateTime dataInicio = DateTime.Now;

          

            // Horas de trabalho por dia
            int horasDiarias = 7;

            // Calcular o número de dias de trabalho necessário
            int diasDeTrabalhoNecessarios = (int)Math.Ceiling((double)horasEstimada / horasDiarias);

            // Calcular a data final estimada
            DateTime dataFinalEstimada = CalcularDataFinalEstimada(dataInicio, diasDeTrabalhoNecessarios);

            //// Exibir o resultado
            //Console.WriteLine("Data de início: " + dataInicio.ToString("dd/MM/yyyy"));
            //Console.WriteLine("Horas estimadas: " + horasEstimadas);
            //Console.WriteLine("Horas de trabalho por dia: " + horasDiarias);
            //Console.WriteLine("Número de dias de trabalho necessários: " + diasDeTrabalhoNecessarios);
            //Console.WriteLine("Data final estimada: " + dataFinalEstimada.ToString("dd/MM/yyyy"));


            if (HorasEstimada > 0)
            {
                Resultado = ($"Horas estimadas: {horasEstimada}, " +
                            $"Horas de trabalho por dia: {horasDiarias}, " +
                            $"Número de dias de trabalho necessários: {diasDeTrabalhoNecessarios}, " +
                            $"Data de início estimado: {dataInicio.ToString("dd/MM/yyyy")}, " +
                            $"Data final estimado: {dataFinalEstimada.ToString("dd/MM/yyyy")}");
                DataInicialEstimado = dataInicio;
                DataFinalEstimado = dataFinalEstimada;
            }
            Situacao = SituacaoProjeto.Planejado;
            return;
        }


        public void Alterar(int horasEstimada, short situacao)
        {
            DateTime dataInicio = DateTime.Now;
            // Horas de trabalho por dia
            int horasDiarias = 7;

            // Calcular o número de dias de trabalho necessário
            int diasDeTrabalhoNecessarios = (int)Math.Ceiling((double)horasEstimada / horasDiarias);

            // Calcular a data final estimada
            DateTime dataFinalEstimada = CalcularDataFinalEstimada(dataInicio, diasDeTrabalhoNecessarios);

            if (HorasEstimada > 0)
            {
                Resultado = ($"Horas estimadas: {horasEstimada}, " +
                            $"Horas de trabalho por dia: {horasDiarias}, " +
                            $"Número de dias de trabalho necessários: {diasDeTrabalhoNecessarios}, " +
                            $"Data de início estimado: {dataInicio.ToString("dd/MM/yyyy")}, " +
                            $"Data final estimado: {dataFinalEstimada.ToString("dd/MM/yyyy")}");
                DataInicialEstimado = dataInicio;
                DataFinalEstimado = dataFinalEstimada;
            }
            Situacao = (SituacaoProjeto)situacao;
            if (DataFinalEstimado < DateTime.Now)
            {
                Situacao = SituacaoProjeto.Atrasado;
            }
            return;
        }

        public static int CalcularDiasUteis(DateTime dataInicio, DateTime dataFim)
        {
            int diasUteis = 0;
            for (DateTime data = dataInicio; data <= dataFim; data = data.AddDays(1))
            {
                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasUteis++;
                }
            }
            return diasUteis;
        }

        public static DateTime CalcularDataFinalEstimada(DateTime dataInicio, int diasDeTrabalhoNecessarios)
        {
            DateTime dataFinalEstimada = dataInicio;
            for (int i = 0; i < diasDeTrabalhoNecessarios; i++)
            {
                do
                {
                    dataFinalEstimada = dataFinalEstimada.AddDays(1);
                }
                while (dataFinalEstimada.DayOfWeek == DayOfWeek.Saturday || dataFinalEstimada.DayOfWeek == DayOfWeek.Sunday);
            }
            return dataFinalEstimada;
        }

    }
}
