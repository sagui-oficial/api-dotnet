using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sagui.Base.Utils;
using Sagui.Business.Base;
using Sagui.Data.Lookup.Arquivo;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.Arquivo;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Procedimento;
using Sagui.Model;

namespace Sagui.Business.Arquivo
{

    public class ArquivoBusiness : BusinessBase
    {
        public List<Model.Arquivos> ListArquivos()
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var listArquivos = arquivoLookup.ListArquivos();

            return listArquivos;
        }

        public Model.Arquivos ObterArquivo(Model.Arquivos arquivo)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ObterArquivo(arquivo);

            return _arquivo;
        }

        public List<Model.Arquivos> ListarArquivoPorGto(Model.GTO gto)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ListarArquivoPorGTO(gto);

            return _arquivo;
        }

        public Model.Arquivos ObterArquivoPorPlanoOperadora(Model.Arquivos arquivo)
        {
            ArquivoLookup arquivoLookup = new ArquivoLookup();
            var _arquivo = arquivoLookup.ObterArquivo(arquivo);

            return _arquivo;
        }
    }
}