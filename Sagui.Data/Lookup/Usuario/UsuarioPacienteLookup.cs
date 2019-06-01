using Sagui.Model;
using Sagui.Model.ValueObject;
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
            DbParams.Add("TipoUsuario", TipoUsuario.Tipo.Paciente.GetHashCode());
                        

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
                        _Usuario.CPF = Convert.ToString(reader["CPF"]);
                        _Usuario.Email = Convert.ToString(reader["Email"]);
                        _Usuario.Telefone = Convert.ToString(reader["Telefone"]);
                        _Usuario.PublicID = (Guid)(reader["PublicID"]);
                        _Usuario.NumeroPlano = Convert.ToString(reader["NumeroPlano"]);
                        _Usuario.PlanoOperadoraId = Convert.ToInt32(reader["PlanoOperadoraId"]);

                        PlanoOperadora planoOperadora = new PlanoOperadora();
                        planoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
                        planoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        _Usuario.PlanoOperadora = planoOperadora;
                        
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

        public Paciente ObterUsuarioPaciente(Paciente paciente)
        {
            Paciente usuarioPaciente = default(Paciente);

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Paciente.TipoUsuario), TipoUsuario.Tipo.Paciente.GetHashCode());
            DbParams.Add(nameof(Paciente.PublicID), paciente.PublicID.ToString());

            using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ObterUsuario, DbParams))
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
                        usuarioPaciente.NumeroPlano = Convert.ToString(reader["NumeroPlano"]);
                        usuarioPaciente.PlanoOperadoraId = Convert.ToInt32(reader["PlanoOperadoraId"]);

                        PlanoOperadora planoOperadora = new PlanoOperadora();
                        planoOperadora.Id = Convert.ToInt32(reader["PlanoOperadoraId"]);
                        planoOperadora.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                        usuarioPaciente.PlanoOperadora = planoOperadora;

                       

                    }
                }
                catch (Exception e)
                {
                    usuarioPaciente = null;
                }
            }
            return usuarioPaciente;
        }

        //public List<Model.PlanoOperadoraPaciente> ListarPlanoOperadoraPaciente(Model.Paciente Paciente)
        //{
        //    List<Model.PlanoOperadoraPaciente> ListaPlanoOperadoraPaciente = new List<Model.PlanoOperadoraPaciente>();


        //    Dictionary<string, object> DbParams = new Dictionary<string, object>();
        //    DbParams.Add("PacienteId", Paciente.Id);

        //    using (DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.ListarPlanoOperadoPaciente, DbParams))
        //    {
        //        try
        //        {
        //            var reader = dataInfrastructure.command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Model.PlanoOperadoraPaciente _PlanoOperadoraPaciente = new Model.PlanoOperadoraPaciente();
        //                _PlanoOperadoraPaciente.PacienteId = Convert.ToInt32(reader["PacienteId"]);
        //                _PlanoOperadoraPaciente.PlanoOperadoraId = Convert.ToInt32(reader["PlanoOperadoraId"]);
        //                _PlanoOperadoraPaciente.NumeroPlano = Convert.ToString(reader["NumeroPlano"]);
        //                ListaPlanoOperadoraPaciente.Add(_PlanoOperadoraPaciente);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            ListaPlanoOperadoraPaciente = null;
        //        }
        //    }

        //    return ListaPlanoOperadoraPaciente;
        //}
    }
}
