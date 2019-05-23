using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model.ValueObject
{
   
    public static class StatusUsuario
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
