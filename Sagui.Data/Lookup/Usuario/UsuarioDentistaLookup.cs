using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.GTO
{
    public class UsuarioDentistaLookup
    {
        public List<Model.Dentinsta> ListUsuarioDentista()
        {
            List<Model.Dentinsta> ListUsuario = new List<Model.Dentinsta>();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Dentista);

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListUsuario, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Dentinsta _Usuario = new Model.Dentinsta();
                        _Usuario.Id = Convert.ToInt32(reader["Id"]);
                        _Usuario.Nome = Convert.ToString(reader["Nome"]);
                        _Usuario.Funcao = Convert.ToString(reader["Funcao"]);
                        _Usuario.Anotacoes = Convert.ToString(reader["Anotacoes"]);

                        ListUsuario.Add(_Usuario);
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
            return ListUsuario;
        }
    }
}
