using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.Usuario
{
    public class UsuarioPersister : DBParams, IDataInfrastructure
    {
        #region PACIENTE

        public Model.Paciente SaveUsuario(Model.Paciente Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Email), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);


            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateUsuarioPaciente, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    Usuario.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        public Model.Paciente AtualizarUsuario(Model.Paciente Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.CPF);
            DbParams.Add(nameof(Usuario.Email), Usuario.Email);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);
            DbParams.Add(nameof(Usuario.PublicID), Usuario.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdateUsuarioPaciente, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteScalar();
                               
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        #endregion

        #region FUNCIONARIO

        public Model.Funcionario SaveUsuario(Model.Funcionario Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.CPF);
            DbParams.Add(nameof(Usuario.Email), Usuario.Email);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateUsuarioFuncionario, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    Usuario.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        public Model.Funcionario AtualizarUsuario(Model.Funcionario Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.CPF);
            DbParams.Add(nameof(Usuario.Email), Usuario.Email);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);
            DbParams.Add(nameof(Usuario.PublicID), Usuario.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdateUsuarioFuncionario, DbParams);

            try
            {
               
                dataInfrastructure.command.ExecuteNonQuery();
                               
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        #endregion

        #region DENTISTA

        public Model.Dentinsta SaveUsuario(Model.Dentinsta Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.CPF);
            DbParams.Add(nameof(Usuario.CRO), Usuario.CRO);
            DbParams.Add(nameof(Usuario.Email), Usuario.Email);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);
            DbParams.Add(nameof(Usuario.PublicID), Usuario.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.CreateUsuarioDentista, DbParams);

            try
            {
                var newId = dataInfrastructure.command.ExecuteScalar();

                if (Convert.ToInt32(newId) > 0)
                {
                    Usuario.Id = Convert.ToInt32(newId);
                }
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        public Model.Dentinsta AtualizarUsuario(Model.Dentinsta Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.CPF), Usuario.CPF);
            DbParams.Add(nameof(Usuario.CRO), Usuario.CRO);
            DbParams.Add(nameof(Usuario.Email), Usuario.Email);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);
            DbParams.Add(nameof(Usuario.Telefone), Usuario.Telefone);
            DbParams.Add(nameof(Usuario.TipoUsuario), Usuario.TipoUsuario);
            DbParams.Add(nameof(Usuario.PublicID), Usuario.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.UpdateUsuarioDentista, DbParams);

            try
            {
                 dataInfrastructure.command.ExecuteScalar();
                               
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        #endregion

        public Model.UsuarioBase DeletarUsuario(Model.UsuarioBase Usuario)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            Dictionary<string, object> DbParams = new Dictionary<string, object>();
            DbParams.Add(nameof(Usuario.PublicID), Usuario.PublicID);

            DataInfrastructure dataInfrastructure = DataInfrastructure.GetInstanceDb(SQL.DeleteUsuario, DbParams);

            try
            {
                dataInfrastructure.command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Usuario = null;
            }

            return Usuario;
        }

        public void CommitCommand(bool commit)
        {
            DataInfrastructure.ConnTranControl(commit);
            DataInfrastructure.dataInfrastructure.Dispose();
        }
    }
}
