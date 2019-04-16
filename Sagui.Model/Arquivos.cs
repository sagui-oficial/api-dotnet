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
    public class Arquivos: BaseModel
    {
      //  [Key, Column(Order = 1)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Stream { get; set; }
        public DateTime DataCriacao { get; set; }
        public string PathArquivo { get; set; }
        public string Extensao { get; set; }
    }
}
