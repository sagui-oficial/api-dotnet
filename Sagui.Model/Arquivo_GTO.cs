using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Arquivo_GTO
    {
        [Key]
        public int idGTO { get; set; }
        public int idArquivo { get; set; }

        public ICollection<GTO> GTO { get; set; }
        public ICollection<Arquivo> Arquivo { get; set; }
    }
}
