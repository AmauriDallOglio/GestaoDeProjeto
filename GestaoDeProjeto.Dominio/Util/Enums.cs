using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
