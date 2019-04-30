﻿using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.PlanoOperadora
{
    public class PlanoOperadoraPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public Model.PlanoOperadora SavePlanoOperadora(Model.PlanoOperadora PlanoOperadora)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.NomeFantasia), PlanoOperadora.NomeFantasia);
            DbParams.Add(nameof(PlanoOperadora.RazaoSocial), PlanoOperadora.RazaoSocial);
            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            DbParams.Add(nameof(PlanoOperadora.DataEnvioLote), PlanoOperadora.DataEnvioLote);
            DbParams.Add(nameof(PlanoOperadora.DataRecebimentoLote), PlanoOperadora.DataRecebimentoLote);
            
            //DbParams.Add(nameof(PlanoOperadora.Id), PlanoOperadora.Id);
            //DbParams.Add(nameof(PlanoOperadora.ListaArquivos), PlanoOperadora.ListaArquivos);
            //DbParams.Add(nameof(PlanoOperadora.ListaProcedimentos), PlanoOperadora.ListaProcedimentos);
            //DbParams.Add(nameof(PlanoOperadora.PublicID), PlanoOperadora.PublicID);
            
            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateUsuarioDentista, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    PlanoOperadora.Id = Convert.ToInt32(newId);
                }

                dataInfrastructure.transaction.Commit();
            }
            catch (Exception e)
            {
                PlanoOperadora = null;
            }

            return PlanoOperadora;
        }

        public Model.PlanoOperadora AtualizarPlanoOperadora(Model.PlanoOperadora PlanoOperadora, out DataInfrastructure _dataInfrastructure)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            DbParams.Add(nameof(PlanoOperadora.NomeFantasia), PlanoOperadora.NomeFantasia);
            DbParams.Add(nameof(PlanoOperadora.RazaoSocial), PlanoOperadora.RazaoSocial);
            DbParams.Add(nameof(PlanoOperadora.CNPJ), PlanoOperadora.CNPJ);
            DbParams.Add(nameof(PlanoOperadora.DataEnvioLote), PlanoOperadora.DataEnvioLote);
            DbParams.Add(nameof(PlanoOperadora.DataRecebimentoLote), PlanoOperadora.DataRecebimentoLote);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.UpdatePlanoOperadora, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    PlanoOperadora.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return PlanoOperadora;
        }

        public Model.PlanoOperadora DeletarPlanoOperadora(Model.PlanoOperadora PlanoOperadora, out DataInfrastructure _dataInfrastructure)
        {
            if (PlanoOperadora == null)
                throw new ArgumentNullException(nameof(PlanoOperadora));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(PlanoOperadora.PublicID), PlanoOperadora.PublicID);

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.DeletePlanoOperadora, DbParams))
            {
                try
                {
                    dataInfrastructure.command.ExecuteNonQuery();
                    dataInfrastructure.transaction.Commit();

                }
                catch (Exception e)
                {
                    dataInfrastructure.transaction.Rollback();
                }


                _dataInfrastructure = dataInfrastructure;
            }

            return PlanoOperadora;
        }

    }
}
