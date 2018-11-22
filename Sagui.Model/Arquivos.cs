using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Arquivos
    {[Key]
        public int id { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataArquivo { get; set; }
    }
}
