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
                       
            childs.Add("Документы",  this.Docs.Cast<INodeble>(););
            childs.Add("Сотрудники",  this.Employees.Cast<INodeble>());
            
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
            var cap = String.Format("[{0}] - [{1}]: {2}", StartDate.ToString(), EndDate.ToString(), PhaseDescription);

            childs.Add(cap, this.DownPhase.Cast<INodeble>());

            return childs;
        }
    }
    public partial class Employee : INodeble
    {
        public string GetTextName()
        {
            return String.Format("{0} {1}. {2}.", LastName, Name.TrimStart().Substring(0, 1), SureName.TrimStart().Substring(0, 1));
        }

        public Dictionary<string, IEnumerable<INodeble>> getNodableCilds()
        {
            var childs = new Dictionary<string, IEnumerable<INodeble>>();

            childs.Add("Документы", this.Docs.Cast<INodeble>());
            childs.Add("Движения", this.Movment.Cast<INodeble>());

            return childs;
        }
    }
    public partial class Doc : INodeble
    {

        public string GetTextName()
        {
            return String.Format("[{0}] {1}-{2}", InDocDate == null ? "Входящий" : "Иссходящий", InDocDate ?? OutDocDate, InDocNum ?? OutDocNun);
        }

        public Dictionary<string, IEnumerable<INodeble>> getNodableCilds()
        {
            var childs = new Dictionary<string, IEnumerable<INodeble>>();

            childs.Add("Движения", this.DocMovments.Cast<INodeble>());
            childs.Add("Фазы", this.RecordPhase);

            return childs;
        }
    }
    public partial class DocMovment : INodeble
    {
    }

}

