using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Procedimentos
{
	public class ValidatorProcedimento
	{
		public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Procedimentos procedimento)
		{
			List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

			ValidadorData validarData = new ValidadorData();
			ValidadorCampo validadorCampo = new ValidadorCampo();

			ErrorsResult = validadorCampo.HandleValidation(procedimento.NomeProcedimento, nameof(procedimento.NomeProcedimento));
			ErrorsResult = validadorCampo.HandleValidation(procedimento.Codigo, nameof(procedimento.Codigo));
			ErrorsResult = validadorCampo.HandleValidation(procedimento.ValorProcedimento, nameof(procedimento.ValorProcedimento));

			return ErrorsResult;
		}
	}
}



