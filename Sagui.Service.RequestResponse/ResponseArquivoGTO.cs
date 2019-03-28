using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseArquivoGTO : ResponseBase
    {
        public List<Model.Arquivo_GTO> Arquivos { get; set; }

        public Model.Arquivo_GTO Arquivo { get; set; }
    }
}
