using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public short Status { get; set; }
    }
}