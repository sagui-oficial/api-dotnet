using Sagui.Model;
using Sagui.Model.ValueObject;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockUsuario
    {
        public RequestUsuarioFuncionario CriarMockUsuarioFuncionario()
        {
            RequestUsuarioFuncionario UsuarioFuncionario = new RequestUsuarioFuncionario();
            UsuarioFuncionario.Nome = "Maria";
            UsuarioFuncionario.Funcao = "Secretaria";
            UsuarioFuncionario.Anotacoes = "Faz tudo";
            UsuarioFuncionario.CPF = "30030030030";
            UsuarioFuncionario.Email = "aaa@aaa.com.br";
            UsuarioFuncionario.Telefone = "11912345678";
            UsuarioFuncionario.TipoUsuario = TipoUsuario.Tipo.Funcionario.GetHashCode();

            return UsuarioFuncionario;
        }

        public RequestUsuarioDentista CriarMockUsuarioDentista()
        {
            RequestUsuarioDentista UsuarioDentista = new RequestUsuarioDentista();
            UsuarioDentista.Nome = "Maria";
            UsuarioDentista.Funcao = "Secretaria";
            UsuarioDentista.Anotacoes = "Faz tudo";
            UsuarioDentista.CPF = "30030030030";
            UsuarioDentista.Email = "aaa@aaa.com.br";
            UsuarioDentista.CRO = "CRO0001111";
            UsuarioDentista.Telefone = "11912345678";
            UsuarioDentista.TipoUsuario = TipoUsuario.Tipo.Dentista.GetHashCode();

            return UsuarioDentista;
        }


        public RequestUsuarioPaciente CriarMockUsuarioPaciente()
        {
            RequestUsuarioPaciente UsuarioPaciente = new RequestUsuarioPaciente();
            UsuarioPaciente.Nome = "Maria";
            UsuarioPaciente.Funcao = "Secretaria";
            UsuarioPaciente.Anotacoes = "Faz tudo";
            UsuarioPaciente.CPF = "30030030030";
            UsuarioPaciente.Email = "aaa@aaa.com.br";
            UsuarioPaciente.Telefone = "11912345678";
            UsuarioPaciente.TipoUsuario = TipoUsuario.Tipo.Paciente.GetHashCode();

            PlanoOperadoraPaciente planoOperadoraPaciente = new PlanoOperadoraPaciente();
            planoOperadoraPaciente.PlanoOperadora = new PlanoOperadora
            {
                CNPJ = "0000000000000",
                NomeFantasia = "Plano",
                Id = 1,
                RazaoSocial = "Plano SA"
            };
            planoOperadoraPaciente.NumeroPlano = "123456789";

            UsuarioPaciente.ListaPlanoOperadoraPaciente = new List<PlanoOperadoraPaciente>();
            UsuarioPaciente.ListaPlanoOperadoraPaciente.Add(planoOperadoraPaciente);

            return UsuarioPaciente;
        }

    }
}
