using Sagui.Model;
using Sagui.Model.ValueObject;
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
            DbParams.Add(nameof(Dentinsta.TipoUsuario), TipoUsuario.Tipo.Dentista);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListUsuario, DbParams))
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
                        _Usuario.CPF = Convert.ToString(reader["CPF"]);
                        _Usuario.Email = Convert.ToString(reader["Email"]);
                        _Usuario.Telefone = Convert.ToString(reader["Telefone"]);
                        _Usuario.PublicID = (Guid)(reader["PublicID"]);

                        ListUsuario.Add(_Usuario);
                    }
                }
                catch (Exception e)
                {
                    ListUsuario = null;
                }
            }

            return ListUsuario;
        }


        public Dentinsta ObterUsuarioDentista(Dentinsta dentinsta)
        {
            Dentinsta usuario = new Dentinsta();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Dentista);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListUsuario, DbParams))
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
                        _Usuario.CPF = Convert.ToString(reader["CPF"]);
                        _Usuario.Email = Convert.ToString(reader["Email"]);
                        _Usuario.Telefone = Convert.ToString(reader["Telefone"]);
                        _Usuario.PublicID = (Guid)(reader["PublicID"]);

                        usuario = _Usuario;
                    }
                }
                catch (Exception e)
                {
                    usuario = null;
                }
            }
            return usuario;
        }
    }
}
