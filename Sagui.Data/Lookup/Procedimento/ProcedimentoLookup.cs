﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.Procedimento
{
    public class ProcedimentoLookup
    {
        public List<Model.Procedimentos> ListProcedimento()
        {
            List<Model.Procedimentos> ListProcedimento = new List<Model.Procedimentos>();


           using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListProcedimento))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();
                                       
                    while (reader.Read())
                    {
                        Model.Procedimentos _Procedimento = new Model.Procedimentos();
                        _Procedimento.IdProcedimento = Convert.ToInt32(reader["IdProcedimento"]);
                        _Procedimento.NomeProcedimento = Convert.ToString(reader["NomeProcedimento"]);
                        _Procedimento.Codigo = Convert.ToInt32(reader["Codigo"]);
                        _Procedimento.ValorProcedimento = Convert.ToDouble(reader["ValorProcedimento"]);
                        _Procedimento.Exigencias = Convert.ToString(reader["Exigencias"]);
                        _Procedimento.Anotacoes = Convert.ToString(reader["Anotacoes"]);
                        ListProcedimento.Add(_Procedimento);

                        
                    }


                }
                catch (Exception e)
                {

                }
                finally
                {
                    dataInfrastructure.Dispose();
                }
            }
            return ListProcedimento;
        }
    }
}
