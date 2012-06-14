using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinGUI
{
    public partial class ConnectionBuilderForm : Form
    {
        private System.Data.Common.DbConnectionStringBuilder _builder;
        public ConnectionBuilderForm()
        {
            InitializeComponent();
        }

        internal static string BuildConnectionString()
        {
            var cbf = new ConnectionBuilderForm();
            if (cbf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return cbf._builder.ConnectionString;
            }

            throw new Exception("Не заполнена строка подключения");
        }

        private void ConnectionBuilderForm_Load(object sender, EventArgs e)
        {
            _builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            this.propertyGrid1.SelectedObject = _builder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
