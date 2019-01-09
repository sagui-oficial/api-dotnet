using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Paciente : UsuarioBase
    {
        public Plano Plano { get; set; }
        public string NumeroPlano { get; set; }
    }
}
