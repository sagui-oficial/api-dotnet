using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class Arquivos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Stream { get; set; }
        public DateTime DataCriacao { get; set; }
        public string PathArquivo { get; set; }
    }
}
