using Sagui.Model;
using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Sagui.Service.PlanoOperadora
{
    public class PlanoOperadoraService : IProcedimentoService<Model.PlanoOperadora, Model.PlanoOperadora>
    {
        public Model.PlanoOperadora Atualizar(Model.PlanoOperadora model)
        {
            throw new NotImplementedException();
        }

        public Model.PlanoOperadora Cadastrar(Model.PlanoOperadora PlanoOperadora)
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.Cadastrar(PlanoOperadora);
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
        }

        public Model.PlanoOperadora Deletar(Model.PlanoOperadora model)
        {
            throw new NotImplementedException();
        }

        public List<Model.PlanoOperadora> Listar()
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.ListPlanoOperadora();
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
        }
    }
}
