using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sagui.Base.Utils
{
    public static class ValidadorCPF
    {
        public static List<Tuple<dynamic, dynamic, dynamic>> Validar(string CPF, string namevalue, ref List<Tuple<dynamic, dynamic, dynamic>> ErrorsResult)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.DataRange, namevalue, Constantes.MensagemTamanhoCPFIncorreto));
                return ErrorsResult;
            }
            else if (CPF.Distinct().Count() == 1)
            {
                ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoIncorreto, namevalue, Constantes.MensagemCPFIncorreto));
                return ErrorsResult;
            }
            else
            {
                tempCpf = CPF.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }


                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = digito + resto.ToString();

                if (!CPF.EndsWith(digito))
                {
                    ErrorsResult.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.CampoIncorreto, namevalue, Constantes.MensagemCPFIncorreto));
                }
            }

            return ErrorsResult;
        }
    }
}
