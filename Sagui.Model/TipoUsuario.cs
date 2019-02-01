using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public static class TipoUsuario
    {
        public enum Tipo
        {
            [Description("Funcionario")]
            Funcionario = 1,
            [Description("Dentista")]
            Dentista = 2,
            [Description("Paciente")]
            Paciente = 3
        }
    }
}
