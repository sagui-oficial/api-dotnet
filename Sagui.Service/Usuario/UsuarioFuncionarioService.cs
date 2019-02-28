using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioFuncionarioService : IUsuarioService<Model.Funcionario, Model.Funcionario>
    {
        public Model.Funcionario Atualizar(Model.Funcionario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.Atualizar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Funcionario Cadastrar(Model.Funcionario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Funcionario Deletar(Model.Funcionario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.Deletar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Funcionario> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.ListUsuariosFuncionario();
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Funcionario Obter(Model.Funcionario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.Obter(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}