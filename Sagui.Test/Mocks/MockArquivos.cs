using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public static class MockArquivos
    {
        public static RequestArquivoGTO CriarMockArquivo()
        {
            RequestArquivoGTO arquivo = new RequestArquivoGTO();
            arquivo.DataCriacao = DateTime.Now;
            arquivo.Nome = "ArquivoTeste";
            arquivo.PathArquivo = @"D:\Sagui\Imagens\LandingPage.jpg";

            return arquivo;
        }

        public static RequestArquivoGTO CriarMockArquivoNaBase()
        {
            RequestArquivoGTO arquivo = new RequestArquivoGTO();
            arquivo.DataCriacao = DateTime.Now;
            arquivo.Nome = "ArquivoTeste";
            arquivo.PathArquivo = @"D:\Sagui\Imagens\LandingPage_Base.jpg";
            arquivo.Stream = null;

            return arquivo;
        }
    }
}
