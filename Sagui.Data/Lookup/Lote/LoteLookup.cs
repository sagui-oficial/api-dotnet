using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Lote
{
    public class LoteLookup
    {
        public List<Model.Lote> ListLote()
        {
            List<Model.Lote> ListLote = new List<Model.Lote>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListGTO))
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
    }
}
