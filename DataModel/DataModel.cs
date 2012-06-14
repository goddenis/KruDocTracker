using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace DataModel
{
    public class DataModel
    {
        void test()
        {
            DataModelContainer ctx = new DataModelContainer(new EntityConnection());
            var emp = ctx.Employes.SingleOrDefault(e => e.Id == 1);

            var contr = emp.hh15;

            DBContext fdf;

        }
    }
}
