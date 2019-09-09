using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model.ValueObject
{
   
    public static class Status
    {
        public enum GTO
        {
            [Description("Criada")]
            Criada = 1,

            [Description("Concluida")]
            Concluida = 2,

            [Description("Paga")]
            Paga = 3,

            [Description("Glosada")]
            Glosada = 4,

            [Description("Viculada")]
            Viculada = 5,

            [Description("Deletada")]
            Deletada = 99
        }

        public enum Procedimento
        {
            [Description("Criada")]
            Criada = 1,
            [Description("Concluida")]
            Concluida = 2,
            [Description("Deletada")]
            Deletada = 99
        }
        public enum PlanoOperadora
        {
            [Description("Criada")]
            Criada = 1,
            [Description("Concluida")]
            Concluida = 2,
            [Description("Deletada")]
            Deletada = 99
        }

        public enum Lote
        {
            [Description("Criada")]
            Criada = 1,
            [Description("Concluida")]
            Concluida = 2,
            [Description("Deletada")]
            Deletada = 99
        }

        public enum Usuario
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
