using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.Lote
{
    public class LotePersister : DBParams, IDataInfrastructure
    {
        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }

        public Model.Lote SaveLote(Model.Lote Lote)
        {
            if (Lote == null)
                throw new ArgumentNullException(nameof(Lote));

            //DbParams.Add(nameof(Lote.IdLote), Lote.IdLote);
            DbParams.Add(nameof(Lote.DataEnvioCorreio), Lote.DataEnvioCorreio);
            DbParams.Add(nameof(Lote.DataPrevistaRecebimento), Lote.DataPrevistaRecebimento);
            DbParams.Add(nameof(Lote.PlanoOperadora), Lote.PlanoOperadora.Id);
            DbParams.Add(nameof(Lote.Funcionario), Lote.Funcionario.Id);
            DbParams.Add(nameof(Lote.StatusLote), Lote.StatusLote);
            DbParams.Add(nameof(Lote.TotalGTOLote), Lote.TotalGTOLote);
            DbParams.Add(nameof(Lote.ValorTotalLote), Lote.ValorTotalLote);
            //DbParams.Add(nameof(Lote.ListaGTO), Lote.ListaGTO);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateLote, DbParams);


                try
                {
                    var newId = dataInfrastructure.command.ExecuteScalar();

                    if (Convert.ToInt32(newId) > 0)
                    {
                        Lote.Id = Convert.ToInt32(newId);
                    }
                }
                catch (Exception e)
                {
                Lote = null;
                }

            


            return Lote;
        }
    }
}
