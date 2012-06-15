using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            return null;

        }

        private void ConnectionBuilderForm_Load(object sender, EventArgs e)
        {
            _builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            this.propertyGrid1.SelectedObject = _builder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var c = new SqlConnection(_builder.ToString()))
            {
                try
                {
                    c.Open();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            try
            {
                var c = new SqlConnection(_builder.ToString());
                c.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
