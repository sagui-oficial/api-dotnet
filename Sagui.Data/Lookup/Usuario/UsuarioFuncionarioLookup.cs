using Sagui.Model;
using Sagui.Model.ValueObject;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Lookup.Usuario
{
    public class UsuarioFuncionarioLookup
    {
        public List<Model.Funcionario> ListUsuarioFuncionario()
        {
            List<Model.Funcionario> ListUsuario = new List<Model.Funcionario>();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Funcionario);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListUsuario, DbParams))
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
                    ListUsuario = null;
                }
            }

            return ListUsuario;
        }

        public Funcionario Obter(Funcionario funcionario)
        {
            Funcionario usuario = new Funcionario();

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(usuario.TipoUsuario), TipoUsuario.Tipo.Funcionario);
            DbParams.Add(nameof(usuario.PublicID), funcionario.PublicID);

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterUsuario, DbParams))
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
