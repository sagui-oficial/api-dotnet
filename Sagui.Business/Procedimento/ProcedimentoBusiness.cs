using System.Collections.Generic;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Procedimento;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Procedimento
{

    public class ProcedimentoBusiness : BusinessBase
    {
        public List<Model.Procedimentos> ListProcedimentos(Model.Procedimentos procedimento)
        {
            ProcedimentoLookup procedimentoLookup = new ProcedimentoLookup();
            var listProcedimento = procedimentoLookup.ListProcedimento(procedimento);

            return listProcedimento;
        }

        public Model.Procedimentos Cadastrar(Model.Procedimentos procedimento)
        {
            ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
            procedimentoPersister.SaveProcedimento(procedimento, out Data.DataInfrastructure dataInfrastructure);

            Model.Procedimentos responseProcedimento = new Model.Procedimentos();
            responseProcedimento = procedimento;

            dataInfrastructure.Dispose();

            return responseProcedimento;
        }
    }
}