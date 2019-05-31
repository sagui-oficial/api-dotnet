using Sagui.Data.Base;
using Sagui.Model;
using Sagui.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Persister.Procedimento
{
    public class ProcedimentoPersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public Model.Procedimentos AtualizarProcedimento(Model.Procedimentos Procedimentos)
        {
            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.Id), Procedimentos.Id);
            DbParams.Add(nameof(Procedimentos.Anotacoes), Procedimentos.Anotacoes);
            DbParams.Add(nameof(Procedimentos.Codigo), Procedimentos.Codigo);
            DbParams.Add(nameof(Procedimentos.Exigencias), Procedimentos.Exigencias);
            DbParams.Add(nameof(Procedimentos.NomeProcedimento), Procedimentos.NomeProcedimento);
            DbParams.Add(nameof(Procedimentos.ValorProcedimento), Procedimentos.ValorProcedimento);
            DbParams.Add(nameof(Procedimentos.PublicID), Procedimentos.PublicID.ToString());
            DbParams.Add(nameof(Procedimentos.Status), Procedimentos.Status);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdateProcedimento, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Procedimentos = null;
            }

            return Procedimentos;
        }



        public Model.Procedimentos DeletarProcedimento(Model.Procedimentos Procedimentos)
        {
            if (Procedimentos == null)
                throw new ArgumentNullException(nameof(Procedimentos));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.PublicID), Procedimentos.PublicID.ToString());
            DbParams.Add(nameof(Procedimentos.Status), StatusProcedimento.Status.Deletada.GetHashCode());

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DeleteProcedimento, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Procedimentos = null;
            }

            return Procedimentos;
        }

        public Model.Procedimentos SaveProcedimento(Model.Procedimentos Procedimentos)
        {
            if (Procedimentos == null)
                throw new ArgumentNullException(nameof(Procedimentos));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Procedimentos.Anotacoes), Procedimentos.Anotacoes);
            DbParams.Add(nameof(Procedimentos.Codigo), Procedimentos.Codigo);
            DbParams.Add(nameof(Procedimentos.Exigencias), Procedimentos.Exigencias);
            DbParams.Add(nameof(Procedimentos.NomeProcedimento), Procedimentos.NomeProcedimento);
            DbParams.Add(nameof(Procedimentos.ValorProcedimento), Procedimentos.ValorProcedimento);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateProcedimento, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    Procedimentos.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                Procedimentos = null;
            }

            return Procedimentos;
        }
    }
}
