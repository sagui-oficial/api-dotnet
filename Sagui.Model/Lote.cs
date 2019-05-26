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
    public class Lote : BaseModel
    {
       
        public PlanoOperadora PlanoOperadora { get; set; }
        public List<GTO> ListaGTO { get; set; }
        public int TotalGTOLote { get; set; }
        public decimal ValorTotalLote { get; set; }
        public DateTime DataEnvioCorreio { get; set; }
        public DateTime DataPrevistaRecebimento { get; set; }
        public int StatusLote { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
