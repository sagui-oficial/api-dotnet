using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseLote : ResponseBase
    {
        public Model.Lote Lote { get; set; }
        public List<Model.Lote> Lotes { get; set; }
    }
}
