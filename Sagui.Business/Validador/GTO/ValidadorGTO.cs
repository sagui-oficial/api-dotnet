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
			ErrorsResult = validadorCampo.HandleValidation(gto.IdGTO, nameof(gto.IdGTO), ref ErrorsResult);
			ErrorsResult = validadorCampo.HandleValidation(gto.NumeroGTO, nameof(gto.NumeroGTO), ref ErrorsResult);
			ErrorsResult = validadorCampo.HandleValidation(gto.Status, nameof(gto.Status), ref ErrorsResult);

			if (gto.Arquivos.Count == 0)
			{
				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ArquivosNaoAnexados, nameof(gto.Arquivos), Constantes.MensagemArquivosNaoAnexados));
			}

			if (gto.Operadora == null)
			{

				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.OperadoraNaoinformada, nameof(gto.Operadora), Constantes.MensagemOperadoraNaoinformada));
			}

			if (gto.Paciente == null)
			{
				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.PacienteNaoinformado, nameof(gto.Paciente), Constantes.MensagemPacienteNaoinformado));
			}

			if (gto.Procedimentos.Count == 0)
			{
				ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProcedimentosNaoInformados, nameof(gto.Procedimentos), Constantes.MensagemProcedimentosNaoInformados));
			}

			return ErrorsResult;
		}
	}
}
