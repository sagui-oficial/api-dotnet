using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseProcedimento : ResponseBase
    {
        public Model.Procedimentos Procedimento { get; set; }
        public List<Model.Procedimentos> Procedimentos { get; set; }
    }
}
