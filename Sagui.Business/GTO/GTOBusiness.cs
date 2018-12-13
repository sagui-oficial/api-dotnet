using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.Arquivo;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Procedimento;
using Sagui.Model;

namespace Sagui.Business.GTO
{

    public class GTOBusiness : BusinessBase
    {
        public List<Model.GTO> ListGTOs(Model.GTO gto)
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ListGTO(gto);

            return listGTO;
        }

        public Model.GTO Cadastrar(Model.GTO gto)
        {
            GTOPersister gtoPersister = new GTOPersister();

            var _gto = gtoPersister.SaveGTO(gto, out Data.DataInfrastructure dataInfrastructure);

            if (_gto.Id > 0)
            {
                gto.Id = _gto.Id;

                Data.DataInfrastructure _dataInfrastructure = dataInfrastructure;

                foreach (Procedimentos procedimento in gto.Procedimentos)
                {
                    ProcedimentoGTOPersister procedimentoGTOPersister = new ProcedimentoGTOPersister();
                    var _persisted = procedimentoGTOPersister.SaveProcedimentoGTO(gto.Id, procedimento.IdProcedimento, _dataInfrastructure, out dataInfrastructure);

                    if (!_persisted)
                    {
                        dataInfrastructure.transaction.Rollback();
                        return null;
                    }
                }

                foreach (Arquivos arquivo in gto.Arquivos)
                {

                    //using (var stream = new FileStream(arquivo.PathArquivo, FileMode.Open, FileAccess.Read))
                    //{
                    //    using (var reader = new BinaryReader(stream))
                    //    {
                    //        arquivo.Stream = reader.ReadBytes((int)stream.Length);
                    //    }
                    //}

                    arquivo.Stream = new byte[0];

                    ArquivoPersister arquivoPersister = new ArquivoPersister();
                    var _arquivo = arquivoPersister.SaveArquivo(gto.Id, arquivo, _dataInfrastructure, out dataInfrastructure);
                    if (_arquivo.Id == 0)
                    {
                        dataInfrastructure.transaction.Rollback();
                        return null;
                    }
                    else
                    {
                        arquivo.Id = _arquivo.Id;
                    }
                }

                dataInfrastructure.transaction.Commit();
                dataInfrastructure.Dispose();
            }

            return gto;
        }
    }
}