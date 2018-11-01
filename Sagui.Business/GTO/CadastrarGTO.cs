using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Base.Utils;
using Sagui.Business.Base;
using Sagui.Business.Validador;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Model;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.ValueObject;

namespace Sagui.Business.GTO
{

    public class GTOBusiness : BusinessBase
    {
        public ResponseGTO ListGTOs(RequestGTO gto)
        {
            GTOLookup gtoLookup = new GTOLookup();
            var listGTO = gtoLookup.ListGTO(gto);

            dynamic namevalue = nameof(listGTO);

            ResponseGTO responseGTO_Procedimentos = new ResponseGTO();

            if (listGTO.Count() == 0)
            {
                responseGTO_Procedimentos.ExecutionDate = DateTime.Now;
                responseGTO_Procedimentos.ResponseType = ResponseType.Info;
                responseGTO_Procedimentos.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemGTOsNaoEncontradas));
            }
            else
            {
                responseGTO_Procedimentos.ExecutionDate = DateTime.Now;
                responseGTO_Procedimentos.ResponseType = ResponseType.Success;
                responseGTO_Procedimentos.GTOs = listGTO;
            }
            return responseGTO_Procedimentos;

        }

        public ResponseGTO Cadastrar(RequestGTO gto)
        {
            var errors = Validador.GTO.ValidadorGTO.Validate(gto);

            if (errors.Count() == 0)
            {
                GTOPersister gtoPersister = new GTOPersister();
                gtoPersister.SaveGTO(gto, out Data.DataInfrastructure dataInfrastructure);

                foreach (Arquivos arquivo in gto.Arquivos)
                {
                    var errorsArquivos = Validador.Arquivos.ValidadorArquivo.Validate(arquivo);
                    if (errorsArquivos.Count() == 0)
                    {
                        //todo: Arquivo Persister
                    }
                    else
                    {
                        dataInfrastructure.transaction.Rollback();
                        ResponseGTO responseGTO_Arquivos = new ResponseGTO();
                        responseGTO_Arquivos.ExecutionDate = DateTime.Now;
                        responseGTO_Arquivos.ResponseType = ResponseType.Error;
                        responseGTO_Arquivos.Message = errors;
                        return responseGTO_Arquivos;
                    }
                }

                foreach (Procedimentos procedimento in gto.Procedimentos)
                {
                    var errorsProcedimentos = Validador.Procedimentos.ValidatorProcedimento.Validate(procedimento);
                    if (errorsProcedimentos.Count() == 0)
                    {
                        //todo: Procedimento Persister
                    }
                    else
                    {
                        dataInfrastructure.transaction.Rollback();
                        ResponseGTO responseGTO_Procedimentos = new ResponseGTO();
                        responseGTO_Procedimentos.ExecutionDate = DateTime.Now;
                        responseGTO_Procedimentos.ResponseType = ResponseType.Error;
                        responseGTO_Procedimentos.Message = errors;
                        return responseGTO_Procedimentos;
                    }
                }

                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Success;

                dataInfrastructure.Dispose();

                return responseGTO;
            }
            else
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.Message = errors;
                return responseGTO;
            }
        }
    }
}