using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Base.Utils;
using Sagui.Business.Base;
using Sagui.Business.Validador;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Model;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.ValueObject;

namespace Sagui.Business.Procedimento
{

    public class CadastrarProcedimento : BusinessBase
    {
        public ResponseProcedimento ListProcedimentos(RequestProcedimento procedimento)
        {
            return null;
        }

        public ResponseProcedimento Cadastrar(RequestProcedimento procedimento)
        {
            var errors = Validador.Procedimentos.ValidatorProcedimento.Validate(procedimento);

            if (errors.Count() == 0)
            {
                ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
                procedimentoPersister.SaveProcedimento(procedimento, out Data.DataInfrastructure dataInfrastructure);

                ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Success;

                dataInfrastructure.Dispose();

                return responseProcedimento;
            }
            else
            {
                ResponseProcedimento responseProcedimento = new ResponseProcedimento();
                responseProcedimento.ExecutionDate = DateTime.Now;
                responseProcedimento.ResponseType = ResponseType.Error;
                responseProcedimento.Message = errors;
                return responseProcedimento;
            }
        }
    }
}