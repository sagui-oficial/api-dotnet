using System;
using System.Collections.Generic;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Procedimento;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Procedimento
{

    public class ProcedimentoBusiness : BusinessBase
    {
        public List<Model.Procedimentos> ListProcedimentos()
        {
            ProcedimentoLookup procedimentoLookup = new ProcedimentoLookup();
            var listProcedimento = procedimentoLookup.ListProcedimento();

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

        public Model.Procedimentos Deletar(Model.Procedimentos procedimento)
        {
            ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
            procedimentoPersister.DeletarProcedimento(procedimento, out Data.DataInfrastructure dataInfrastructure);

            Model.Procedimentos responseProcedimento = new Model.Procedimentos();
            responseProcedimento = procedimento;

            dataInfrastructure.Dispose();

            return responseProcedimento;
        }

        public Model.Procedimentos Atualizar(Model.Procedimentos procedimento)
        {
            ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
            procedimentoPersister.AtualizarProcedimento(procedimento, out Data.DataInfrastructure dataInfrastructure);

            Model.Procedimentos responseProcedimento = new Model.Procedimentos();
            responseProcedimento = procedimento;

            dataInfrastructure.Dispose();

            return responseProcedimento;
        }

        public Model.Procedimentos Obter(Model.Procedimentos procedimento)
        {
            ProcedimentoLookup procedimentoLookup = new ProcedimentoLookup();
            var listProcedimento = procedimentoLookup.ObterProcedimento(procedimento);

            return listProcedimento;
        }

        public List<Model.Procedimentos> ListarProcedimentoGTO(int idGTO)
        {
            ProcedimentoLookup procedimentoLookup = new ProcedimentoLookup();
            var listProcedimento = procedimentoLookup.ListarProcedimentoGTO(idGTO);

            return listProcedimento;
        }
    }
}