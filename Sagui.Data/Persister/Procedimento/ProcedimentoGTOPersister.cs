using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Procedimento
{
    public class ProcedimentoGTOPersister: DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public bool SaveProcedimentoGTO(int IdGTO, Model.Procedimentos procedimento)
        {
            DbParams.Clear();
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add("IdProcedimento", procedimento.Id);
            DbParams.Add(nameof(procedimento.ValorProcedimento), procedimento.ValorProcedimento);
            DbParams.Add(nameof(procedimento.Pago), procedimento.Pago);


            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateProcedimentoGTO, DbParams);

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

        public bool DeletarProcedimentoGTO(int IdGTO)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            

            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DeleteProcedimentoGTO, DbParams);

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

        public bool PagarProcedimentoGTO(int IdGTO, bool Pago)
        {
            DbParams.Add(nameof(IdGTO), IdGTO);
            DbParams.Add(nameof(Pago), Pago);


            DataInfrastructure _dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.PagarProcedimentoGTO, DbParams);

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
