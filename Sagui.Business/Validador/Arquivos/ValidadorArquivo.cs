using Sagui.Base.Utils;
using Sagui.Business.Validador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador.Arquivos
{
	public class ValidadorArquivo : IValidadorBase<Model.Arquivos>
    {
        private List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult;
        private ValidadorData validarData;
        private ValidadorCampo validadorCampo;

        public ValidadorArquivo()
        {
            ErrorsResult = new List<Tuple<dynamic, dynamic, dynamic>>();
            validarData = new ValidadorData();
            validadorCampo = new ValidadorCampo();
        }

		public List<Tuple<dynamic, dynamic, dynamic>> Validate(Model.Arquivos arquivo)
		{
			ErrorsResult = validadorCampo.HandleValidation(arquivo.PathArquivo, nameof(arquivo.PathArquivo),  ref ErrorsResult);
            ErrorsResult = validadorCampo.HandleValidation(arquivo.Nome, nameof(arquivo.Nome), ref ErrorsResult);
            ErrorsResult = validarData.HandleValidation(arquivo.DataCriacao, nameof(arquivo.DataCriacao), ref ErrorsResult);

			return ErrorsResult;
		}
	}
}
