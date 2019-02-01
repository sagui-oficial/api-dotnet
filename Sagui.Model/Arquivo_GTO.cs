using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Arquivo_GTO
    {
        [Key, Column(Order = 1)]
        public int idArquivo_GTO { get; set; }
        public int idGTO { get; set; }
        public int idArquivo { get; set; }

        //public ICollection<GTO> GTO { get; set; }
        //public ICollection<Arquivos> Arquivo { get; set; }
    }
}
