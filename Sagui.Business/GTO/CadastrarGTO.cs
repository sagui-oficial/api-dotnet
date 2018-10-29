using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Business.Base;
using Sagui.Business.Validador.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Model;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.ValueObject;

namespace Sagui.Business.GTO
{
    public class CadastrarGTOBusiness : BusinessBase
    {
        public ResponseGTO Cadastrar(RequestGTO gto)
        {
            var errors = ValidadorGTO.Validate(gto);

            if (errors.Count() == 0)
            {
                GTOPersister gtoPersister = new GTOPersister();
                gtoPersister.SaveGTO(gto);

                ResponseGTO responseGTO = new ResponseGTO();
                return responseGTO;
            }
            else
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.ErrorsMessage = errors;
                return responseGTO;
            }
        }
    }
}