using Sagui.Data.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Data.Persister.GTO
{
    public class UsuarioPersister: PersisterBase
    {
        public Model.Paciente SaveUsuario(Model.Paciente Usuario, out DataInfrastructure _dataInfrastructure)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateUsuario, DbParams);

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
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return Usuario;
        }


        public Model.Funcionario SaveUsuario(Model.Funcionario Usuario, out DataInfrastructure _dataInfrastructure)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateUsuario, DbParams);

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
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return Usuario;
        }


        public Model.Dentinsta SaveUsuario(Model.Dentinsta Usuario, out DataInfrastructure _dataInfrastructure)
        {
            if (Usuario == null)
                throw new ArgumentNullException(nameof(Usuario));

            DbParams.Add(nameof(Usuario.Anotacoes), Usuario.Anotacoes);
            DbParams.Add(nameof(Usuario.Funcao), Usuario.Funcao);
            DbParams.Add(nameof(Usuario.Nome), Usuario.Nome);

            DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.CreateUsuario, DbParams);

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
                dataInfrastructure.transaction.Rollback();
            }


            _dataInfrastructure = dataInfrastructure;


            return Usuario;
        }
    }
}
