using Sagui.Base.Utils;
using Sagui.Business.Validador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Business.Validador
{
    public class ValidadorCampo : ValidadorBase
    {
        public override List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value, string namevalue, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult)
        {
            Type t = value.GetType();

            if (t == typeof(string))
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemCampoNaoPreenchida));
                }
            }
            else if (t == typeof(Int32))
            {
                if (value == 0 || value == null)
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemCampoNaoPreenchida));
                }
            }
            else if (t == typeof(double))
            {
                if (value == 0 || value == null)
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemCampoNaoPreenchida));
                }
            }
            else if (t == typeof(decimal))
            {
                if (value == 0 || value == null)
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemCampoNaoPreenchida));
                }
            }
            else if (t == typeof(byte[]))
            {
                if (value.lenght == 0 || value == null)
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoNaoPreenchido, namevalue, Constantes.MensagemCampoNaoPreenchida));
                }
            }
            return ErrorsResult;
        }

        public override List<Tuple<dynamic, dynamic, dynamic>> HandleValidation(dynamic value1, dynamic value2)
        {
            throw new NotImplementedException();
        }
    }
}
