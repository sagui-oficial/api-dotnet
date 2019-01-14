using Sagui.Model;
using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.GTO
{
    public class GTOService : IGTOService<Model.GTO, Model.GTO>
    {
        public Model.GTO Atualizar(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.Atualizar(GTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public Model.GTO Cadastrar(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.Cadastrar(GTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public Model.GTO Deletar(Model.GTO model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.GTO> Listar()
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.ListGTOs();
                GTOBusiness.Dispose();
                return _return;
            }
        }
    }
}