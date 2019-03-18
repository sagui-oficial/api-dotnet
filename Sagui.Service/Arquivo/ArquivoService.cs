using Sagui.Model;
using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Arquivo
{
    public class ArquivoService
    {

        public List<Model.Arquivos> Listar()
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ListArquivos();
                ArquivoBusiness.Dispose();
                return _return;
            }
        }

        public Model.Arquivos Obter(Model.Arquivos Arquivo)
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ObterArquivo(Arquivo);
                ArquivoBusiness.Dispose();
                return _return;
            }
        }
    }
}