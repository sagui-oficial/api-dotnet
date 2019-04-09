using Sagui.Model;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Lookup.GTO
{
    public class UsuarioPacienteLookup
    {
        public List<Model.Paciente> ListUsuarioPaciente()
        {
            List<Model.Paciente> ListUsuario = new List<Model.Paciente>();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Paciente);
                        

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListUsuario, DbParams))
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
                    ListUsuario = null;
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
            Paciente usuarioPaciente = default(Paciente);

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Paciente.TipoUsuario), TipoUsuario.Tipo.Paciente);
            DbParams.Add(nameof(Paciente.PublicID), paciente.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListUsuario, DbParams))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarioPaciente = new Model.Paciente();
                        usuarioPaciente.Id = Convert.ToInt32(reader["Id"]);
                        usuarioPaciente.Nome = Convert.ToString(reader["Nome"]);
                        usuarioPaciente.Funcao = Convert.ToString(reader["Funcao"]);
                        usuarioPaciente.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        usuarioPaciente.CPF = Convert.ToString(reader["CPF"]);
                        usuarioPaciente.Email = Convert.ToString(reader["Email"]);
                        usuarioPaciente.Telefone = Convert.ToString(reader["Telefone"]);
                        usuarioPaciente.PublicID = (Guid)(reader["PublicID"]);
                    }
                }
                catch (Exception e)
                {
                    usuarioPaciente = null;
                }
            }
            return usuarioPaciente;
        }
    }
}
