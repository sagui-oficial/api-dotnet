using Sagui.Service.Contracts;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.GTO
{
    public class GTOService : IGTOService
    {
        public ResponseGTO Cadastrar(RequestGTO requestGTO)
        {
            using (var cadastrarGTOBusiness = new Business.GTO.CadastrarGTOBusiness())
            {
                var _return = cadastrarGTOBusiness.Cadastrar(requestGTO);
                cadastrarGTOBusiness.Dispose();
                return _return;
            }
        }
    }
}