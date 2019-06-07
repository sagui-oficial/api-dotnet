using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.PlanoOperadora;
using Sagui.Data.Persister.Procedimento;
using Sagui.Model;

namespace Sagui.Business.PlanoOperadora
{

    public class PlanoOperadoraBusiness : BusinessBase
    {
        public List<Model.PlanoOperadora> ListPlanoOperadora()
        {
            PlanoOperadoraLookup planoOperadoraLookup = new PlanoOperadoraLookup();
            var listPlanoOperadora = planoOperadoraLookup.ListPlanoOperadora();

            return listPlanoOperadora;
        }

        public Model.PlanoOperadora Obter(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraLookup planoOperadoraLookup = new PlanoOperadoraLookup();
            var listPlanoOperadora = planoOperadoraLookup.ObterPlanoOperadora(planoOperadora);

            return listPlanoOperadora;
        }

        public Model.PlanoOperadora Cadastrar(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraPersister planoOperadoraPersister = new PlanoOperadoraPersister();
            Model.PlanoOperadora responsePlanoOperadora = planoOperadoraPersister.SavePlanoOperadora(planoOperadora);

            if(responsePlanoOperadora != null)
            {
                foreach (Procedimentos procedimento in planoOperadora.Procedimentos)
                {
                    Procedimento_PlanoOperadoraPersister procedimento_PlanoOperadora = new Procedimento_PlanoOperadoraPersister();
                    var _persisted = procedimento_PlanoOperadora.SaveProcedimento_PlanoOperadora(planoOperadora.Id, procedimento);

                    if (!_persisted)
                    {
                        procedimento_PlanoOperadora.CommitCommand(false);
                        return null;
                    }
                }


                planoOperadoraPersister.CommitCommand(true);
            }
            else
            {
                planoOperadoraPersister.CommitCommand(false);
            }

            return responsePlanoOperadora;
        }
        public Model.PlanoOperadora Atualizar(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraPersister planoOperadoraPersister = new PlanoOperadoraPersister();
            Model.PlanoOperadora responsePlanoOperadora = planoOperadoraPersister.AtualizarPlanoOperadora(planoOperadora);

            if (responsePlanoOperadora != null)
            {
                Procedimento_PlanoOperadoraPersister procedimento_PlanoOperadoraPersister = new Procedimento_PlanoOperadoraPersister();
                var _persisted2 = procedimento_PlanoOperadoraPersister.DeletarProcedimento_PlanoOperadora(planoOperadora.Id);

                if (!_persisted2)
                {
                    procedimento_PlanoOperadoraPersister.CommitCommand(false);
                    return null;
                }

                foreach (Procedimentos procedimento in planoOperadora.Procedimentos)
                {

                    var _persisted = procedimento_PlanoOperadoraPersister.SaveProcedimento_PlanoOperadora(planoOperadora.Id, procedimento);


                    if (!_persisted)
                    {
                        procedimento_PlanoOperadoraPersister.CommitCommand(false);
                        return null;
                    }
                }


                planoOperadoraPersister.CommitCommand(true);
            }
            else
            {
                planoOperadoraPersister.CommitCommand(false);
            }

            return responsePlanoOperadora;
        }

        public Model.PlanoOperadora Deletar(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraPersister planoOperadoraPersister = new PlanoOperadoraPersister();
            Model.PlanoOperadora responsePlanoOperadora = planoOperadoraPersister.DeletarPlanoOperadora(planoOperadora);

            if (responsePlanoOperadora != null)
            {
                planoOperadoraPersister.CommitCommand(true);
            }
            else
            {
                planoOperadoraPersister.CommitCommand(false);
            }

            return responsePlanoOperadora;
        }
    }
}