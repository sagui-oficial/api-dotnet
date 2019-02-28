using Sagui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.GTO
{
    public class UsuarioPacienteLookup
    {
        public List<Model.Paciente> ListUsuarioPaciente()
        {
            List<Model.Paciente> ListUsuario = new List<Model.Paciente>();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Paciente);
                        

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListUsuario, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Paciente _Usuario = new Model.Paciente();
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

        public Paciente ObterUsuarioPaciente(Paciente paciente)
        {
            Paciente usuarioPaciente = new Paciente();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Paciente);
            DbParams.Add(nameof(Paciente.PublicID), paciente.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListUsuario, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Paciente _Usuario = new Model.Paciente();
                        _Usuario.Id = Convert.ToInt32(reader["Id"]);
                        _Usuario.Nome = Convert.ToString(reader["Nome"]);
                        _Usuario.Funcao = Convert.ToString(reader["Funcao"]);
                        _Usuario.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        _Usuario.CPF = Convert.ToString(reader["CPF"]);
                        _Usuario.Email = Convert.ToString(reader["Email"]);
                        _Usuario.Telefone = Convert.ToString(reader["Telefone"]);
                        _Usuario.PublicID = (Guid)(reader["PublicID"]);

                        usuarioPaciente = _Usuario;
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
            return usuarioPaciente;
        }
    }
}
