using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseArquivoPlanoOperadora : ResponseBase
    {
        public List<Model.Arquivo_PlanoOperadora> Arquivos { get; set; }

        public Model.Arquivo_PlanoOperadora Arquivo { get; set; }
    }
}
