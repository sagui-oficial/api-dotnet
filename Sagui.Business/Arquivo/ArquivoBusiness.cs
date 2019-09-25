using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Arquivo;
using Sagui.Model;

namespace Sagui.Business.Arquivo
{

    public class ArquivoBusiness : BusinessBase
    {
        #region GTO

       
        public Model.Arquivos ObterArquivoGTOPorPublicId(Arquivos arquivo)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ObterArquivoGTOPorPublicId(arquivo);

            return _arquivo;
        }


        public List<Model.Arquivos> ListarArquivoPorGto(Model.GTO gto)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ListarArquivoPorGTO(gto);

            return _arquivo;
        }

        #endregion






        #region PlanoOperadora
        public Model.Arquivo_PlanoOperadora ObterArquivoPlanoOperadoraPorPublicId(Arquivo_PlanoOperadora arquivo)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ObterArquivoPlanoOperadoraPorPublicId(arquivo);

            return _arquivo;
        }


        public List<Model.Arquivo_PlanoOperadora> ListarArquivoPorPlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ListarArquivoPorPlanoOperadora(planoOperadora);

            return _arquivo;
        }

        #endregion
    }
}