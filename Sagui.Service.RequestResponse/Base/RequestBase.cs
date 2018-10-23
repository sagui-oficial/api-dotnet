using Sagui.Service.RequestResponse.ValueObject;
using System;

namespace Sagui.Service.RequestResponse.Base
{
    public class RequestBase
    {
        //campos de rastreamento
        public DateTime ExecutionDate { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public Tuple<dynamic, dynamic, dynamic> Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
