using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Usuario
{
    public class PlanoOperadoraLookup
    {
        public List<Model.PlanoOperadora> ListPlanoOperadora()
        {
            List<Model.PlanoOperadora> ListPlanoOperadora = new List<Model.PlanoOperadora>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.PlanoOperadora _PlanoOperadora = new Model.PlanoOperadora();

                        ListPlanoOperadora.Add(_PlanoOperadora);
                    }
                }
                catch (Exception e)
                {
                    ListPlanoOperadora = null;
                }
            }

            return ListPlanoOperadora;
        }
    }
}
