using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.Comum
{
    public static class DALComum
    {
        public static string HandlerName = "Sagui.Base.DAL.DALBaseSQL";
        //public static string HandlerConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sagui;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string HandlerConnection = @"Host=localhost;Port=5432;Pooling=true;Database=Sagui;User Id=postgres;Password=!!br4v05;";
    }
}
