using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
   public class Arquivo_PlanoOperadora : Arquivos
    {
        [Key, Column(Order = 1)]
        public int idArquivo_PlanoOperadora { get; set; }
        public int idPlanoOperadora { get; set; }
        public int idArquivo { get; set; }
    }
}
