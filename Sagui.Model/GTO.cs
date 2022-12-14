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
    public class GTO : BaseModel
    {
     
        public string Numero { get; set; }
        public PlanoOperadora PlanoOperadora { get; set; }
        public Paciente Paciente { get; set; }
        public List<Arquivos> Arquivos { get; set; }
        public DateTime Solicitacao { get; set; }
        public DateTime Vencimento { get; set; }
        public List<Procedimentos> Procedimentos { get; set; }
        public double TotalProcedimentos { get; set; }
        public double ValorTotalProcedimentos { get; set; }

        public GTO()
        {
            Arquivos = new List<Arquivos>();
            Procedimentos = new List<Procedimentos>();
        }
    }
}
