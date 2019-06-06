using Sagui.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Usuario
{
    public class PlanoOperadoraLookup: DBParams
    {
        public List<Model.PlanoOperadora> ListPlanoOperadora()
        {
            List<Model.PlanoOperadora> ListPlanoOperadora = new List<Model.PlanoOperadora>();

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListPlanoOperadora))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.PlanoOperadora _PlanoOperadora = Helper.Parser.ParsePlanoOperadora(reader);
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

        public Model.PlanoOperadora ObterPlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            if (planoOperadora == null)
                throw new ArgumentNullException(nameof(planoOperadora));

            DbParams.Add(nameof(planoOperadora.PublicID), planoOperadora.PublicID.ToString());
            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterPlanoOperadora, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        planoOperadora = Helper.Parser.ParsePlanoOperadora(reader);
                    }
                }
                catch (Exception e)
                {
                    planoOperadora = null;
                }
            }

            return planoOperadora;
        }
    }
}
