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
        //public static string HandlerConnection = @"Host=localhost;Port=5432;Pooling=true;Database=Sagui;User Id=postgres;Password=!!br4v05;";


        //Desenv
        //public static string HandlerConnection = @"Host=ec2-54-221-243-211.compute-1.amazonaws.com;Port=5432;Pooling=true;Database=d2u2lp40bjf8fk;User Id=ycydyagzcivkxd;Password=c71d3cfdc47cde4b75acda03dbdf1b8299871814aaa1ed6b7a16c6f3c6ae951c;SSL Mode=Require;Trust Server Certificate=true";

        //Produção
        public static string HandlerConnection = @"Host=ec2-174-129-27-3.compute-1.amazonaws.com;Port=5432;Pooling=true;Database=dadhakti70ocr;User Id=zcfzoskjnteuaj;Password=611d20c029b21551e78b2cd3629a8623e2017b8ad61157340610e3dc7af8a994;SSL Mode=Require;Trust Server Certificate=true";

        
    }
}
