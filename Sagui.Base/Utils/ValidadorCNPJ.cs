using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sagui.Base.Utils
{
    public static class ValidadorCNPJ
    {
        public static List<Tuple<dynamic, dynamic, dynamic>> Validar(string CNPJ, string namevalue, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            CNPJ = CNPJ.Trim();
            CNPJ = CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");

            if (CNPJ.Length != 14)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DataRange, namevalue, Constantes.MensagemTamanhoCNPJIncorreto));
                return ErrorsResult;
            }
            else if (CNPJ.Distinct().Count() == 1)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoIncorreto, namevalue, Constantes.MensagemCNPJIncorreto));
                return ErrorsResult;
            }
            else
            {
                tempCnpj = CNPJ.Substring(0, 12);

                soma = 0;

                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                }

                resto = (soma % 11);

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;

                soma = 0;
                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                }

                resto = (soma % 11);

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = digito + resto.ToString();

                if (!CNPJ.EndsWith(digito))
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoIncorreto, namevalue, Constantes.MensagemCNPJIncorreto));
                }
            }

            return ErrorsResult;
        }
    }
}
