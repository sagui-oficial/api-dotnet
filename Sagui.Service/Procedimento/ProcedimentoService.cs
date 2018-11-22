using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Sagui.Service.Procedimento
{
    public class ProcedimentoService : IProcedimentoService
    {
        public Model.Procedimentos Cadastrar(Model.Procedimentos Procedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.CadastrarProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.Cadastrar(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Procedimentos> ListProcedimentos(Model.Procedimentos Procedimento = null)
        {
            throw new NotImplementedException();
        }
    }
}
