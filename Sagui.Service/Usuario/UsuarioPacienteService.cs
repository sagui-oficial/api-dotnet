using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioPacienteService : IUsuarioService<Model.Paciente, Model.Paciente>
    {
        public Model.Paciente Atualizar(Model.Paciente Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.Atualizar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Paciente Cadastrar(Model.Paciente Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Paciente Deletar(Model.Paciente Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.Deletar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Paciente> Listar(Model.Paciente Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.ListUsuarios();
                usuarioBusiness.Dispose();
                return _return;
            }
        }


        public Model.Paciente Obter(Model.Paciente Paciente)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.ObterPaciente(Paciente);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        //public List<Model.PlanoOperadoraPaciente> ListarPlanoOperadoraPaciente(Model.Paciente Paciente)
        //{
        //    using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
        //    {
        //        var _return = usuarioBusiness.ListarPlanoOperadoraPaciente(Paciente);
        //        usuarioBusiness.Dispose();
        //        return _return;
        //    }
        //}
    }
}