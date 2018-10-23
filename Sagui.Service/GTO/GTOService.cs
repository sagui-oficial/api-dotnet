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
            using (Business.GTO.CadastrarGTOBusiness cadastrarGTOBusiness = new Business.GTO.CadastrarGTOBusiness())
            {
                return cadastrarGTOBusiness.Cadastrar(requestGTO);
            }
        }
    }
}