using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Sagui.Service.Procedimento
{
    public class ProcedimentoService : IProcedimentoService
    {
        public Model.Procedimentos Cadastrar(Model.Procedimentos Procedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.Cadastrar(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Procedimentos> ListProcedimentos(Model.Procedimentos Procedimento = null)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.ListProcedimentos(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }
    }
}
