using Sagui.Model;
using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Sagui.Service.PlanoOperadora
{
    public class PlanoOperadoraService : IPlanoOperadoraService<Model.PlanoOperadora, Model.PlanoOperadora>
    {
        public Model.PlanoOperadora Atualizar(Model.PlanoOperadora PlanoOperadora)
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.Atualizar(PlanoOperadora);
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
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

        public Model.PlanoOperadora Deletar(Model.PlanoOperadora PlanoOperadora)
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.Deletar(PlanoOperadora);
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.PlanoOperadora> Listar(Model.PlanoOperadora PlanoOperadora)
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.ListPlanoOperadora();
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
        }

        public Model.PlanoOperadora Obter(Model.PlanoOperadora PlanoOperadora)
        {
            using (var PlanoOperadoraBusiness = new Business.PlanoOperadora.PlanoOperadoraBusiness())
            {
                var _return = PlanoOperadoraBusiness.Obter(PlanoOperadora);
                PlanoOperadoraBusiness.Dispose();
                return _return;
            }
        }
    }
}
