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

    public class GTOBusiness : BusinessBase
    {
        public List<Model.GTO> ListGTOs()
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ListGTO();

            return listGTO;
        }

        public Model.GTO Cadastrar(Model.GTO gto)
        {
            GTOPersister gtoPersister = new GTOPersister();

            var _gto = gtoPersister.SaveGTO(gto);

            if (_gto != null)
            {
                gto.Id = _gto.Id;

                foreach (Procedimentos procedimento in gto.Procedimentos)
                {
                    ProcedimentoGTOPersister procedimentoGTOPersister = new ProcedimentoGTOPersister();
                    var _persisted = procedimentoGTOPersister.SaveProcedimentoGTO(gto.Id, procedimento.IdProcedimento);

                    if (!_persisted)
                    {
                        procedimentoGTOPersister.DataInfrastructureControl(false);
                        return null;
                    }
                }

                foreach (Arquivos arquivo in gto.Arquivos)
                {
                    arquivo.Stream = ManipulaArquivo.GerarStreamArquivo(arquivo.PathArquivo);
                    arquivo.Extensao = Path.GetExtension(arquivo.PathArquivo);

                    ArquivoPersister arquivoPersister = new ArquivoPersister();

                    var _arquivo = arquivoPersister.SaveArquivo(gto.Id, arquivo);
                    if (_arquivo.Id == 0)
                    {
                        arquivoPersister.DataInfrastructureControl(false);
                        return null;
                    }
                    else
                    {
                        arquivo.Id = _arquivo.Id;
                    }
                }

                gtoPersister.DataInfrastructureControl(true);
            }
            else
            {
                gto = _gto;
            }

            return gto;
        }

        public Model.GTO Atualizar(Model.GTO gto)
        {

            GTOPersister gtoPersister = new GTOPersister();
            gtoPersister.AtualizarGTO(gto, out Data.DataInfrastructure dataInfrastructure);

            Model.GTO responseGTO = new Model.GTO();
            responseGTO = gto;

            dataInfrastructure.Dispose();

            return responseGTO;

        }

        public Model.GTO Deletar(Model.GTO gto)
        {

            GTOPersister gtoPersister = new GTOPersister();
            gtoPersister.DeleteGTO(gto, out Data.DataInfrastructure dataInfrastructure);

            Model.GTO responseGTO = new Model.GTO();
            responseGTO = gto;

            dataInfrastructure.Dispose();

            return responseGTO;

        }

        public Model.GTO ObterGTO(Model.GTO GTO)
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ObterGTO(GTO);

            return listGTO;
        }


    }
}