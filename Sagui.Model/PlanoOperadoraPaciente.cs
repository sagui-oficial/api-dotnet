using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class PlanoOperadoraPaciente
    {[Key]
        public int id { get; set; }
        public PlanoOperadora PlanoOperadora { get; set; }
        public string NumeroPlano { get; set; }
    }
}
