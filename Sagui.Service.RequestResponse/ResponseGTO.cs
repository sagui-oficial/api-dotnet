using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseGTO : ResponseBase
    {
        public Model.GTO GTO { get; set; }
        public List<Model.GTO> GTOs { get; set; }
    }
}
