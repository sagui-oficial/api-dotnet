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
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.Cadastrar(requestGTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public ResponseGTO ListGTOs(RequestGTO requestGTO = null)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.ListGTOs(requestGTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }
    }
}