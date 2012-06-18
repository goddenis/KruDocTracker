using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace DataModel
{
    public partial class Contragent : INodeble
    {

        public string GetTextName()
        {
            return this.Name;
        }

        public Dictionary<string, IEnumerable<INodeble>> getNodableCilds()
        {
            var childs = new Dictionary<string, IEnumerable<INodeble>>();
            var docs = this.Docs.Cast<INodeble>();
            var emps = this.Employees.Cast<INodeble>();
            
            childs.Add("Документы", docs);
            childs.Add("Сотрудники", emps);
            return childs;
        }
    }

    public partial class DocRecordPhase : INodeble
    {

        public string GetTextName()
        {
            return this.PhaseDescription;
        }

        public Dictionary<string, IEnumerable<INodeble>> getNodableCilds()
        {
            var childs = new Dictionary<string, IEnumerable<INodeble>>();
            var cap = String.Format("[{0}] - [{1}]: {2}",StartDate.ToString(),EndDate.ToString(),PhaseDescription);
            
            childs.Add(cap, this.DownPhase.Cast<INodeble>());
            
            return childs;
        }
    }
    public partial class Employee : INodeble
    {
    }
    public partial class Doc : INodeble
    {
    }
    public partial class DocMovment : INodeble
    {
    }
    public partial class Employee : INodeble
    {
    }

}

