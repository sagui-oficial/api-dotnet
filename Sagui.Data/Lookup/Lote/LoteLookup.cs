using Sagui.Data.Base;
using Sagui.Data.Helper;
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
                        Model.Lote _Lote = Parser.ParseLote(reader, null);
                        ListLote.Add(_Lote);
                    }
                }
                catch (Exception e)
                {

                }
            }

            return ListLote;
        }

        public Model.Lote ObterLote(Model.Lote Lote)
        {
            if (Lote == null)
                throw new ArgumentNullException(nameof(Lote));
            DbParams.Add(nameof(Lote.PublicID), Lote.PublicID);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterLotebyPublicID, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Lote = Parser.ParseLote(reader, Lote);
                    }
                }
                catch (Exception e)
                {
                    Lote = null;
                }
            }

            return Lote;
        }
    }
}
