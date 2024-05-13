using GestaoDeProjeto.Dominio.Util;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Tarefa : AuditableEntity<int>, IEmpresaObrigatorio
    {
        [Required]
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }

        [Required]
        public int Id_Projeto { get; set; }
        public Projeto Projeto { get; set; }



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
        public byte Situacao { get; set; }


    }
}
