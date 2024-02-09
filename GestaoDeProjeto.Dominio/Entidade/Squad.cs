using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Squad
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Descricao { get; set; }
        public byte[] ArrayImagem { get; set; }
        public string UrlImagem { get; set; }
        public bool Inativo { get; set; }

    }
}
