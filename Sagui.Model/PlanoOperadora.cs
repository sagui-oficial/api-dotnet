using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model
{
    public class PlanoOperadora : Base.BaseModel
    {
     
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataEnvioLote { get; set; }
        public DateTime DataRecebimentoLote { get; set; }
        public List<Procedimentos> Procedimentos { get; set; }
        public List<Arquivos> Arquivos { get; set; }
    }
}
