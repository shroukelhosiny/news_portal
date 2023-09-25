using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace software
{
    public partial class Form3 : Form
    {
        OracleDataAdapter Adapter;
        OracleCommandBuilder commandBuilder;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = " Data Source = orcl; User Id= scott; Password=tiger;";
            string c = " ";
            if (radioButton2.Checked)
            {
                c = "select * from Reader";
                Adapter = new OracleDataAdapter(c, constr);
                ds = new DataSet();
                Adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            else if (radioButton1.Checked)
            {
                c = "select * from News";
                Adapter = new OracleDataAdapter(c, constr);
                ds = new DataSet();
                Adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                commandBuilder = new OracleCommandBuilder(Adapter);
                Adapter.Update(ds.Tables[0]);
          
        }

    }
}
