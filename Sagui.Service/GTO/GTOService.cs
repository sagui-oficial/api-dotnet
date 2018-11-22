using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.GTO
{
    public class GTOService : IGTOService
    {
        public Model.GTO Cadastrar(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.Cadastrar(GTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.GTO> ListGTOs(Model.GTO requestGTO = null)
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