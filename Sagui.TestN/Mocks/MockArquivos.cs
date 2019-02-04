using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockArquivos
    {
        public RequestArquivo CriarMockArquivo()
        {
            RequestArquivo arquivo = new RequestArquivo();
            arquivo.DataCriacao = DateTime.Now;
            arquivo.Nome = "ArquivoTeste";
            arquivo.PathArquivo = @"C:\";

            return arquivo;
        }
    }
}
