using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model.ValueObject
{
   
    public static class StatusGTO
    {
        public enum Status
        {
            [Description("Criada")]
            Criada = 1,
            [Description("Concluida")]
            Concluida = 2,
            [Description("Deletada")]
            Deletada = 99
        }
    }
}
