using Sagui.Data.Base;
using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Lote
{
    public class LoteLookup : DBParams
    {
        public List<Model.Lote> ListLote()
        {
            List<Model.Lote> ListLote = new List<Model.Lote>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListLote))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Lote _Lote = new Model.Lote();


                        ListLote.Add(_Lote);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }
            return ListLote;
        }

        public Model.Lote ObterLote(Model.Lote lote)
        {
            if (lote == null)
                throw new ArgumentNullException(nameof(lote));

            DbParams.Add(nameof(lote.PublicID), lote.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterLotebyPublicID, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Lote _Lote = new Model.Lote();
                        _Lote.Id = Convert.ToInt32(reader["Id"]);
                        _Lote.Status = Convert.ToInt32(reader["Status"]);
                        _Lote.PlanoOperadora = new Model.PlanoOperadora();
                        _Lote.PlanoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
                        _Lote.PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        _Lote.PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
                        _Lote.PublicID = (Guid)reader["PublicID"];
                        _Lote.TotalGTOLote = Convert.ToInt32(reader["TotalProcedimentos"]);
                        _Lote.ValorTotalLote = Convert.ToDouble(reader["ValorTotalProcedimentos"]);
                        lote = _Lote;
                    }
                }
                catch (Exception e)
                {
                    lote = null;
                }

            }

            return lote;
        }
    }
}
