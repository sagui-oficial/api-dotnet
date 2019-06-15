using System;
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
using Sagui.Model.ValueObject;

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
            gto.TotalProcedimentos = gto.Procedimentos.Count();
            gto.ValorTotalProcedimentos = gto.Procedimentos.Sum(p => p.ValorProcedimento);

            GTOPersister gtoPersister = new GTOPersister();

            var _gto = gtoPersister.SaveGTO(gto);

            if (_gto != null)
            {
                gto.Id = _gto.Id;

                foreach (Procedimentos procedimento in gto.Procedimentos)
                {
                    ProcedimentoGTOPersister procedimentoGTOPersister = new ProcedimentoGTOPersister();
                    var _persisted = procedimentoGTOPersister.SaveProcedimentoGTO(gto.Id, procedimento);

                    if (!_persisted)
                    {
                        procedimentoGTOPersister.CommitCommand(false);
                        return null;
                    }
                }

                //foreach (Arquivos arquivo in gto.Arquivos)
                //{
                //    arquivo.Stream = ManipulaArquivo.GerarStreamArquivo(arquivo.PathArquivo);
                //    arquivo.Extensao = Path.GetExtension(arquivo.PathArquivo);

                //    ArquivoPersister arquivoPersister = new ArquivoPersister();

                //    var _arquivo = arquivoPersister.SaveArquivo(gto.Id, arquivo);
                //    if (_arquivo.Id == 0)
                //    {
                //        arquivoPersister.CommitCommand(false);
                //        return null;
                //    }
                //    else
                //    {
                //        arquivo.Id = _arquivo.Id;
                //    }

                //    ArquivoGTOPersister arquivoGTOPersister = new ArquivoGTOPersister();

                //    if (!arquivoGTOPersister.SaveArquivoGTO(gto.Id, arquivo.Id))
                //    {
                //        arquivoGTOPersister.CommitCommand(false);
                //    }
                //}

                gtoPersister.CommitCommand(true);
            }
            else
            {
                gto = _gto;
            }

            return gto;
        }

        

        public Model.GTO Atualizar(Model.GTO gto)
        {
            gto.TotalProcedimentos = gto.Procedimentos.Count();
            gto.ValorTotalProcedimentos = gto.Procedimentos.Sum(p => p.ValorProcedimento);

            if (gto.Status == Status.GTO.Paga.GetHashCode())
            {
                gto.Procedimentos.ForEach(p => p.Pago = true);
            }


            GTOPersister gtoPersister = new GTOPersister();
            Model.GTO responseGTO = gtoPersister.AtualizarGTO(gto);

            if (responseGTO != null)
            {
                ProcedimentoGTOPersister procedimentoGTOPersister = new ProcedimentoGTOPersister();
                var _persisted2 = procedimentoGTOPersister.DeletarProcedimentoGTO(gto.Id);

                if (!_persisted2)
                {
                    procedimentoGTOPersister.CommitCommand(false);
                    return null;
                }

                foreach (Procedimentos procedimento in gto.Procedimentos)
                {

                    var _persisted = procedimentoGTOPersister.SaveProcedimentoGTO(gto.Id, procedimento);


                    if (!_persisted)
                    {
                        procedimentoGTOPersister.CommitCommand(false);
                        return null;
                    }
                }

                gtoPersister.CommitCommand(true);
            }
            else
            {
                gtoPersister.CommitCommand(false);
            }




            return responseGTO;
        }

        public Model.GTO Deletar(Model.GTO gto)
        {

            GTOPersister gtoPersister = new GTOPersister();
            Model.GTO responseGTO = gtoPersister.DeleteGTO(gto);

            if (responseGTO == null)
            {
                gtoPersister.CommitCommand(false);
            }
            else
            {
                gtoPersister.CommitCommand(true);
            }

            return responseGTO;
        }

        public Model.GTO ObterGTO(Model.GTO GTO)
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ObterGTO(GTO);

            return listGTO;
        }
        

        public List<Model.GTO> ListarGTOPorPlanoOperadora(Model.PlanoOperadora planoOperadora)
        {
            GTOLookup procedimentoLookup = new GTOLookup();
            var listGTO = procedimentoLookup.ListarGTOPorPlanoOperadora(planoOperadora);

            return listGTO;
        }

        public List<Model.GTO> ListarGTOLote(Model.Lote lote)
        {
            GTOLookup procedimentoLookup = new GTOLookup();
            var listGTO = procedimentoLookup.ListarGTOLote(lote);

            return listGTO;
        }
    }
}