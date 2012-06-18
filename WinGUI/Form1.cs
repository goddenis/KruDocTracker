using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel;
namespace WinGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var conn = ConnectionBuilderForm.BuildConnectionString();
            DataModel.ContextHelper.SetConnection(conn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ctx = ContextHelper.GetContext();

            var contrs = ctx.Contragents.Where(x => x.Id != null);
            foreach (var c in contrs)
            {
                this.treeView1.Nodes.Add(new EntityNode<Contragent>(c));
            }

        }
    }
}
