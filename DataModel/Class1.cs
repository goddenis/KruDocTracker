using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace DataModel
{
    public class Class1
    {
        void test()
        {
            DataModelContainer ctx = new DataModelContainer(new EntityConnection());
            var emp = ctx.Employes.SingleOrDefault(e => e.Id == 1);

            var contr = emp.hh15;

            contr.

        }
    }
}
