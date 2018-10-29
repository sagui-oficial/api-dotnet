using Sagui.Base.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Base.DAL
{
    public class DALWorker
    {
        public static DALBase _database = null;

        static DALWorker()
        {
            _database = DbFactory.CreateDataBase();
        }

        protected DALBase dataBase
        {
            get
            {
                return _database;
            }
        }
    }
}
