using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Arquivo_GTO //: Arquivos
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public int idGTO { get; set; }
        public int idArquivo { get; set; }
    }
}
