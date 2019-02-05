using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.GTO
{
    public class ProcedimentoPersister
    {
        public Model.Procedimentos AtualizarProcedimento(Model.Procedimentos Procedimentos, out DataInfrastructure _dataInfrastructure)
        {
            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.IdProcedimento), Procedimentos.IdProcedimento);
            DbParams.Add(nameof(Procedimentos.Anotacoes), Procedimentos.Anotacoes);
            DbParams.Add(nameof(Procedimentos.Codigo), Procedimentos.Codigo);
            DbParams.Add(nameof(Procedimentos.Exigencias), Procedimentos.Exigencias);
            DbParams.Add(nameof(Procedimentos.NomeProcedimento), Procedimentos.NomeProcedimento);
            DbParams.Add(nameof(Procedimentos.ValorProcedimento), Procedimentos.ValorProcedimento);

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.UpdateProcedimento, DbParams))
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

            return Procedimentos;
        }


        public Model.Procedimentos DeletarProcedimento(Model.Procedimentos Procedimentos, out DataInfrastructure _dataInfrastructure)
        {
            if (Procedimentos == null)
                throw new ArgumentNullException(nameof(Procedimentos));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.IdProcedimento), Procedimentos.IdProcedimento);

           
            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.DeleteProcedimento, DbParams))
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

            return Procedimentos;
        }

        public Model.Procedimentos SaveProcedimento(Model.Procedimentos Procedimentos, out DataInfrastructure _dataInfrastructure)
        {
            if (Procedimentos == null)
                throw new ArgumentNullException(nameof(Procedimentos));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.Anotacoes), Procedimentos.Anotacoes);
            DbParams.Add(nameof(Procedimentos.Codigo), Procedimentos.Codigo);
            DbParams.Add(nameof(Procedimentos.Exigencias), Procedimentos.Exigencias);
            DbParams.Add(nameof(Procedimentos.NomeProcedimento), Procedimentos.NomeProcedimento);
            DbParams.Add(nameof(Procedimentos.ValorProcedimento), Procedimentos.ValorProcedimento);

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateProcedimento, DbParams))
            {
                try
                {
                    var newId = dataInfrastructure.command.ExecuteScalar();

                    if (Convert.ToInt32(newId) > 0)
                    {
                        Procedimentos.IdProcedimento = Convert.ToInt32(newId);
                        dataInfrastructure.transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    dataInfrastructure.transaction.Rollback();
                }


                _dataInfrastructure = dataInfrastructure;
            }

            return Procedimentos;
        }
    }
}
