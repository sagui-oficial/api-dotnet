using Sagui.Service.Contracts.Base;
using System.Collections.Generic;

namespace Sagui.Service.Contracts
{
    public interface IPlanoOperadoraService<TRequest, TResponse> : ICRUDBase<TResponse, TRequest> where TRequest : class where TResponse : class
    {

    }
}
