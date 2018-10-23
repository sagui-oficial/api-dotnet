using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagui.Business.Validador.GTO;
using Sagui.Model;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.ValueObject;

namespace Sagui.Business.GTO
{
    public class CadastrarGTOBusiness : IDisposable
    {
        protected bool disposed = false;

        #region Destructor
        ~CadastrarGTOBusiness()
        {
            Dispose(false);
        }
        #endregion

        public ResponseGTO Cadastrar(Model.GTO gto)
        {
            var errors = ValidadorGTO.Validate(gto);

            if (errors.Count() == 0)
            {
                ResponseGTO responseGTO = new ResponseGTO();
                return responseGTO;
            }
            else
            {
                ResponseGTO responseGTO = new ResponseGTO();
                responseGTO.ExecutionDate = DateTime.Now;
                responseGTO.ResponseType = ResponseType.Error;
                responseGTO.ErrorsMessage = errors;
                return responseGTO;
            }
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}