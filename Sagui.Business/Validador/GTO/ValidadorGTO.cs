using Sagui.Base.Utils;
using Sagui.Business.Validador;
using Sagui.Business.Validador.Arquivos;
using Sagui.Business.Validador.Operadora;
using Sagui.Business.Validador.Paciente;
using Sagui.Business.Validador.Procedimentos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sagui.Business.Validador.GTO
{
    public static class ValidadorGTO
    {
        public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.GTO gto)
        {
            List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

            ValidadorData validarData = new ValidadorData();
            ValidadorCampo validadorCampo = new ValidadorCampo();

            ErrorsResult = validarData.HandleValidation(gto.Solicitacao, nameof(gto.Solicitacao), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(gto.Vencimento, nameof(gto.Vencimento), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(gto.Id, nameof(gto.Id), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(gto.Numero, nameof(gto.Numero), ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(gto.Status, nameof(gto.Status), ref ErrorsResult);


            if (gto.Operadora == null)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.OperadoraNaoinformada, nameof(gto.Operadora), Constantes.MensagemOperadoraNaoinformada));
            }
            else
            {
                ErrorsResult = validadorCampo.HandleValidation(gto.Operadora.IdOperadora, nameof(gto.Operadora.IdOperadora), ref ErrorsResult);
            }

            if (gto.Paciente == null)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.PacienteNaoinformado, nameof(gto.Paciente), Constantes.MensagemPacienteNaoinformado));
            }
            else
            {
                ErrorsResult = validadorCampo.HandleValidation(gto.Paciente.IdPaciente, nameof(gto.Paciente.IdPaciente), ref ErrorsResult);
                ErrorsResult = validadorCampo.HandleValidation(gto.Paciente.NomePaciente, nameof(gto.Paciente.NomePaciente), ref ErrorsResult);
            }

            if (gto.Procedimentos.Count == 0)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProcedimentosNaoInformados, nameof(gto.Procedimentos), Constantes.MensagemProcedimentosNaoInformados));
            }
            else
            {
                foreach(Model.Procedimentos procedimento in gto.Procedimentos)
                {
                    ErrorsResult = validadorCampo.HandleValidation(procedimento.IdProcedimento, nameof(procedimento.IdProcedimento), ref ErrorsResult);
                }
            }

            return ErrorsResult;
        }
    }
}
