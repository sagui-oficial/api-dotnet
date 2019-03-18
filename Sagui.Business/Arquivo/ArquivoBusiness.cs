using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sagui.Base.Utils;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.Arquivo;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Procedimento;
using Sagui.Model;

namespace Sagui.Business.GTO
{

    public class ArquivoBusiness : BusinessBase
    {
        public List<Model.Arquivos> ListArquivos()
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ListGTO();

            return listGTO;
        }

        public Model.Arquivos ObterArquivo(Model.Arquivos arquivos)
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ObterGTO(GTO);

            return listGTO;
        }
    }
}