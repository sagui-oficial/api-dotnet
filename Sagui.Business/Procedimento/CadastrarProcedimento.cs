using System.Collections.Generic;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Procedimento
{

    public class CadastrarProcedimento : BusinessBase
    {
        public List<Model.Procedimentos> ListProcedimentos(Model.Procedimentos procedimento)
        {
            return null;
        }

        public Model.Procedimentos Cadastrar(Model.Procedimentos procedimento)
        {
            var errors = Validador.Procedimentos.ValidatorProcedimento.Validate(procedimento);

            if (errors.Count() == 0)
            {
                ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
                procedimentoPersister.SaveProcedimento(procedimento, out Data.DataInfrastructure dataInfrastructure);

                Model.Procedimentos responseProcedimento = new Model.Procedimentos();
                //responseProcedimento.ExecutionDate = DateTime.Now;
                //responseProcedimento.ResponseType = ResponseType.Success;

                dataInfrastructure.Dispose();

                return responseProcedimento;
            }
            else
            {
                Model.Procedimentos responseProcedimento = new Model.Procedimentos();
                //responseProcedimento.ExecutionDate = DateTime.Now;
                //responseProcedimento.ResponseType = ResponseType.Error;
                //responseProcedimento.Message = errors;
                return responseProcedimento;
            }
        }
    }
}