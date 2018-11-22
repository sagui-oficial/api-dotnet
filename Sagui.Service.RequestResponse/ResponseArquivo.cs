using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseArquivo : ResponseBase
    {
        public List<Model.Arquivos> Arquivos { get; set; }
    }
}
