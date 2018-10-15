using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Operadora
{
	public class ValidadorOperadora
	{
		public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Operadora operadora)
		{
			List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

			ValidadorData validarData = new ValidadorData();
			ValidadorCampo validadorCampo = new ValidadorCampo();

			ErrorsResult = validadorCampo.HandleValidation(operadora.NomeOperadora, nameof(operadora.NomeOperadora));

			return ErrorsResult;
		}
	}
}
