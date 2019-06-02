using Sagui.Base.Utils;
using Sagui.Business.Validador.Base;
using Sagui.Business.Validador.Procedimentos;
using Sagui.Model;
using Sagui.Model.Base;
using System;
using System.Collections.Generic;

namespace Sagui.Business.Validador.GTO
{
    public class ValidadorGTO : Validador<Model.GTO>
    {
        private ValidatorProcedimento validatorProcedimento;
        private Arquivos.ValidadorArquivo validadorArquivo;

        public ValidadorGTO()
        {
            validatorProcedimento = new ValidatorProcedimento();
            validadorArquivo = new Arquivos.ValidadorArquivo();
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.GTO gto)
        {
            ErrorsResult = validarData.HandleValidation(gto.Solicitacao, nameof(gto.Solicitacao), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(gto.Vencimento, nameof(gto.Vencimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(gto.Numero, nameof(gto.Numero), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(gto.Status, nameof(gto.Status), ref ErrorsResult);


            if (gto.PlanoOperadora == null)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.OperadoraNaoinformada, nameof(gto.PlanoOperadora), Constantes.MensagemOperadoraNaoinformada));
            }
            else
            {
                ErrorsResult = validadorCampo.HandleValidation(gto.PlanoOperadora.Id, nameof(gto.PlanoOperadora.Id), ref ErrorsResult);
            }

            if (gto.Paciente == null)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.PacienteNaoinformado, nameof(gto.Paciente), Constantes.MensagemPacienteNaoinformado));
            }
            else
            {
                ErrorsResult = validadorCampo.HandleValidation(gto.Paciente.Id, nameof(gto.Paciente.Id), ref ErrorsResult);
                //ErrorsResult = validadorCampo.HandleValidation(gto.Paciente.Nome, nameof(gto.Paciente.Nome), ref ErrorsResult);
            }

            //if (gto.Procedimentos.Count == 0)
            //{
            //    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProcedimentosNaoInformados, nameof(gto.Procedimentos), Constantes.MensagemProcedimentosNaoInformados));
            //}
            //else
            //{
            //    foreach (Model.Procedimentos procedimento in gto.Procedimentos)
            //    {
            //        ErrorsResult = validatorProcedimento.Validate(procedimento);
            //    }
            //}

            //if (gto.Arquivos.Count == 0)
            //{
            //    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.MensagemArquivosNaoAnexados, nameof(gto.Arquivos), Constantes.MensagemArquivosNaoAnexados));
            //}
            //else
            //{
            //    foreach (Model.Arquivos arquivo in gto.Arquivos)
            //    {
            //        ErrorsResult = validadorArquivo.Validate(arquivo);
            //    }
            //}

            return ErrorsResult;
        }

        
    }
}
