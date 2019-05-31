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

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListPlanoOperadora))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.PlanoOperadora _PlanoOperadora = new Model.PlanoOperadora();
                        _PlanoOperadora.Id = Convert.ToInt32(reader["Id"]);
                        _PlanoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        _PlanoOperadora.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
                        _PlanoOperadora.CNPJ = Convert.ToString(reader["CNPJ"]);
                        _PlanoOperadora.DataEnvioLote = Convert.ToDateTime(reader["DataEnvioLote"]);
                        _PlanoOperadora.DataRecebimentoLote = Convert.ToDateTime(reader["DataRecebimentoLote"]);
                        _PlanoOperadora.PublicID = (Guid)reader["PublicID"];


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
