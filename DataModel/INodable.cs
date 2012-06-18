using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    interface INodeble
    {
        string GetTextName();

        Dictionary<string, List<INodeble>> getNodableCilds();

         
    }
}
