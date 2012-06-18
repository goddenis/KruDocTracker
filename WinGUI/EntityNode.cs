using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects.DataClasses;

namespace WinGUI
{
    class EntityNode<T> : TreeNode where T : IEntityWithRelationships
    {
        private T nodeObject;
        public EntityNode(T obj)
        {
            nodeObject = obj;
            this.Name = nodeObject.ToString();
            this.Text = nodeObject.ToString();
        }
    }
}
