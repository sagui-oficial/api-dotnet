using Sagui.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Operadora : BaseModel
    {[Key]
        public int IdOperadora { get; set; }
        public string NomeOperadora { get; set; }
    }
}
