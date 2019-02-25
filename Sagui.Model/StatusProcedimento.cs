using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   
    public static class StatusProcedimento
    {
        public enum Status
        {
            [Description("Ativo")]
            Criada = 1,
            [Description("Inativo")]
            Concluida = 2,
            [Description("Deletado")]
            Deletada = 99
        }
    }
}
