using Sagui.Base.Utils;
using Sagui.Business.Validador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Arquivos
{
	public static class ValidadorArquivo
	{
		public static List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Arquivos arquivo)
		{
			List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();

			ValidadorData validarData = new ValidadorData();
			ValidadorCampo validadorCampo = new ValidadorCampo();

			ErrorsResult = validadorCampo.HandleValidation(arquivo.NomeArquivo, nameof(arquivo.NomeArquivo));
			ErrorsResult = validarData.HandleValidation(arquivo.DataArquivo, nameof(arquivo.DataArquivo));

			return ErrorsResult;
		}
	}
}
