using Sagui.Model;
using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Arquivo
{
    public class ArquivoService
    {

        #region GTO

        public Model.Arquivos ObterArquivoGTOPorPublicId(Arquivos Arquivo)
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ObterArquivoGTOPorPublicId(Arquivo);
                ArquivoBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Arquivos> ListarArquivoPorGTO(Model.GTO gto)
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ListarArquivoPorGto(gto);
                ArquivoBusiness.Dispose();
                return _return;
            }
        }

        #endregion


        #region PlanoOperadora

        public List<Model.Arquivo_PlanoOperadora> ListarArquivosPlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ListarArquivoPorPlanoOperadora(planoOperadora);
                ArquivoBusiness.Dispose();
                return _return;
            }
        }

     
        public Model.Arquivo_PlanoOperadora ObterArquivoPlanoOperadoraPorPublicId(Arquivo_PlanoOperadora Arquivo)
        {
            using (var ArquivoBusiness = new Business.Arquivo.ArquivoBusiness())
            {
                var _return = ArquivoBusiness.ObterArquivoPlanoOperadoraPorPublicId(Arquivo);
                ArquivoBusiness.Dispose();
                return _return;
            }
        }

        #endregion
    }
}