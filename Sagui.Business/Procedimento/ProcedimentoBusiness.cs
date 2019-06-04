using System;
using System.Collections.Generic;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Procedimento;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Procedimento;

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
            Model.Procedimentos responseProcedimento = procedimentoPersister.SaveProcedimento(procedimento);

            if(responseProcedimento == null)
            {
                procedimentoPersister.CommitCommand(false);
            }
            else
            {
                procedimentoPersister.CommitCommand(true);
            }

            return responseProcedimento;
        }

        public Model.Procedimentos Deletar(Model.Procedimentos procedimento)
        {
            ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
            Model.Procedimentos responseProcedimento = procedimentoPersister.DeletarProcedimento(procedimento);

            if (responseProcedimento == null)
            {
                procedimentoPersister.CommitCommand(false);
            }
            else
            {
                procedimentoPersister.CommitCommand(true);
            }

            return responseProcedimento;
        }

        public Model.Procedimentos Atualizar(Model.Procedimentos procedimento)
        {
            ProcedimentoPersister procedimentoPersister = new ProcedimentoPersister();
            Model.Procedimentos responseProcedimento = procedimentoPersister.AtualizarProcedimento(procedimento);

            if(responseProcedimento == null)
            {
                procedimentoPersister.CommitCommand(false);
            }
            else{
                procedimentoPersister.CommitCommand(true);
            }

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


        public List<Model.Procedimentos> ListarProcedimento_PlanoOperadora(int idPlanoOperadora)
        {
            ProcedimentoLookup procedimentoLookup = new ProcedimentoLookup();
            var listProcedimento = procedimentoLookup.ListarProcedimento_PlanoOperadora(idPlanoOperadora);

            return listProcedimento;
        }
    }
}