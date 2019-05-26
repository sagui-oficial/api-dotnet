using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.PlanoOperadora;

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

        public Model.PlanoOperadora Cadastrar(Model.PlanoOperadora planoOperadora)
        {
            PlanoOperadoraPersister planoOperadoraPersister = new PlanoOperadoraPersister();
            Model.PlanoOperadora responsePlanoOperadora = planoOperadoraPersister.SavePlanoOperadora(planoOperadora);

            if(responsePlanoOperadora != null)
            {
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