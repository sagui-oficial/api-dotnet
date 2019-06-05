using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Procedimento
{
    public class Procedimento_PlanoOperadoraPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SaveProcedimento_PlanoOperadora(int IdPlanoOperadora, Model.Procedimentos procedimento)
        {
            DbParams.Clear();
            DbParams.Add(nameof(IdPlanoOperadora), IdPlanoOperadora);
            DbParams.Add("IdProcedimento", procedimento.Id);
            DbParams.Add(nameof(procedimento.ValorProcedimento), procedimento.ValorProcedimento);
            
            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateProcedimento_PlanoOperadora, DbParams);

            dynamic newId = 0;
            try
            {
                newId = _dataInfrastructure.command.ExecuteScalar();
            }
            catch (Exception e)
            {
                _dataInfrastructure.transaction.Rollback();
            }

            if (Convert.ToInt32(newId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeletarProcedimentoGTO(int IdPlanoOperadora)
        {
            DbParams.Add(nameof(IdPlanoOperadora), IdPlanoOperadora);
            

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DeleteProcedimento_PlanoOperadora, DbParams);

            try
            {
                _dataInfrastructure.command.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {
                
                return false;
            }
                        

        }
    }
}
