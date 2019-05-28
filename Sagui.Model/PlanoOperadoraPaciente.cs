using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class PlanoOperadoraPaciente
    {
        public int Id { get; set; }
        public int PlanoOperadoraId { get; set; }
        public string NumeroPlano { get; set; }

        

    }
}
