using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Dominio.Util
{
    public interface ITenantObrigatorio
    {
        Guid Id_Tenant { get; set; }
    }
}
