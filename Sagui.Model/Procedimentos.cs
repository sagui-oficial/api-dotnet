using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Procedimentos : BaseModel
    {
        
        public string Codigo { get; set; }
        public string NomeProcedimento { get; set; }

        [NotMapped]
        public double ValorProcedimento { get; set; }

        [NotMapped]
        public bool Pago { get; set; }
        public string Exigencias { get; set; }
        public string Anotacoes { get; set; }
        


    }
}
