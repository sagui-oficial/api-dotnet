using Sagui.Model;
using Sagui.Service.Contracts;
using System;
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

        public Model.GTO Deletar(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.Deletar(GTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.GTO> Listar(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.ListGTOs();
                GTOBusiness.Dispose();
                return _return;
            }
        }


        public Model.GTO Obter(Model.GTO GTO)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.ObterGTO(GTO);
                GTOBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.GTO> ListarGTOPorLote(Model.Lote lote)
        {
            using (var GTOBusiness = new Business.GTO.GTOBusiness())
            {
                var _return = GTOBusiness.ListarGTOLote(lote.Id);
                GTOBusiness.Dispose();
                return _return;
            }
        }
    }
}