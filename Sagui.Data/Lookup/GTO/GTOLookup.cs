using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Data.Lookup.GTO
{
    public class GTOLookup
    {
        //todo: refazer a query para trazer Operadora e Paciente
        //todo: refazer a query para trazer Procedimento da GTO e Arquivo da GTO

        public List<Model.GTO> ListGTO()
        {
            List<Model.GTO> ListGTO = new List<Model.GTO>();

            using (DataInfrastructure dataInfrastructure = new DataInfrastructure(SQL.ListGTO))
            {
                try
                {
                    var reader = dataInfrastructure.command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.GTO _GTO = new Model.GTO();
                        _GTO.Id = Convert.ToInt32(reader["Id"]);
                        _GTO.Numero = Convert.ToInt32(reader["Numero"]);
                        _GTO.Status = Convert.ToInt32(reader["Status"]);
                        _GTO.Operadora = new Model.Operadora();
                        _GTO.Operadora.IdOperadora = Convert.ToInt32(reader["Operadora"]);
                        _GTO.Paciente = new Model.Paciente();
                        _GTO.Paciente.Id = Convert.ToInt32(reader["Paciente"]);
                        _GTO.Solicitacao = Convert.ToDateTime(reader["Solicitacao"]);
                        _GTO.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        ListGTO.Add(_GTO);
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
            return ListGTO;
        }
    }
}
