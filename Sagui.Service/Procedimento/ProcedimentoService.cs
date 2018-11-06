using Sagui.Service.Contracts;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.Procedimento
{
    public class ProcedimentoService : IProcedimentoService
    {
        public ResponseProcedimento Cadastrar(RequestProcedimento requestProcedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.CadastrarProcedimento())
            {
                var _return = ProcedimentoBusiness.Cadastrar(requestProcedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public ResponseProcedimento ListProcedimentos(RequestProcedimento requestProcedimento = null)
        {
            throw new NotImplementedException();
        }
    }
}
