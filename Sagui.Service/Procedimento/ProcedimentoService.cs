using Sagui.Model;
using Sagui.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Sagui.Service.Procedimento
{
    public class ProcedimentoService : IProcedimentoService<Model.Procedimentos, Model.Procedimentos>
    {
        public Procedimentos Atualizar(Procedimentos Procedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.Atualizar(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public Model.Procedimentos Cadastrar(Model.Procedimentos Procedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.Cadastrar(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public Procedimentos Deletar(Model.Procedimentos Procedimento)
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.Deletar(Procedimento);
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }

        public List<Procedimentos> Listar()
        {
            using (var ProcedimentoBusiness = new Business.Procedimento.ProcedimentoBusiness())
            {
                var _return = ProcedimentoBusiness.ListProcedimentos();
                ProcedimentoBusiness.Dispose();
                return _return;
            }
        }
    }
}
