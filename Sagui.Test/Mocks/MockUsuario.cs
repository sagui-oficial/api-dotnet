using Sagui.Model;
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
        public RequestUsuario CriarMockUsuario()
        {
            RequestUsuario Usuario = new RequestUsuario();
            Usuario.Id = 1;
            Usuario.Nome = "Maria";
            Usuario.Funcao = "Secretaria";
            Usuario.Anotacoes = "Faz tudo";
            Usuario.CPF = "30030030030";
            Usuario.Email = "aaa@aaa.com.br";

            return Usuario;
        }
    }
}
