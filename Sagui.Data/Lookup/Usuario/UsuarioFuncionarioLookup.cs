using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Usuario
{
    public class UsuarioFuncionarioLookup
    {
        public List<Model.Funcionario> ListUsuarioFuncionario()
        {
            List<Model.Funcionario> ListUsuario = new List<Model.Funcionario>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Funcionario _Usuario = new Model.Funcionario();
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
