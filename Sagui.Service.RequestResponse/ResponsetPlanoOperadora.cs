using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponsePlanoOperadora : ResponseBase
    {
        public Model.PlanoOperadora PlanoOperadora { get; set; }

        public List<Model.PlanoOperadora> PlanosOperadoras { get; set; }
    }
}
