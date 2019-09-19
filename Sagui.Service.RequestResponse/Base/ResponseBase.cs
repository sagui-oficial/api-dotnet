using Sagui.Model.ValueObject;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;

namespace Sagui.Service.RequestResponse.Base
{
    public class ResponseBase
    {
        //campos de rastreamento
        public DateTime ExecutionDate { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public List<Tuple<dynamic, dynamic, dynamic>> Message { get; set; }
        public ResponseType ResponseType { get; set; }
        public PagingParameter paging { get; set; }

        public ResponseBase()
        {
            Message = new List<Tuple<dynamic, dynamic, dynamic>>();
        }
    }
}