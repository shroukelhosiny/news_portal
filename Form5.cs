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
    public partial class Form5 : Form
    {
        string ordb = "Data Source = orcl;User Id= scott;Password=tiger;";
        OracleConnection conn;
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetNewsName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("fristname", textBox1.Text);
            cmd.Parameters.Add("lastname", textBox3.Text);
            cmd.Parameters.Add("category", textBox2.Text);
            cmd.Parameters.Add("NewsName", OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0]);
                }
                dr.Close();
            }
            catch
            {
                MessageBox.Show("Not Exist");
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetNewsNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("fristname", textBox1.Text);
            cmd.Parameters.Add("lastname", textBox3.Text);
            cmd.Parameters.Add("category", textBox2.Text);
            cmd.Parameters.Add("Cnews", OracleDbType.Int32, ParameterDirection.Output);
           // int count = (int)cmd.ExecuteNonQuery();
            //textBox4.Text = count.ToString();
            try
            {
                cmd.ExecuteNonQuery();
                textBox4.Text = Convert.ToString(cmd.Parameters["Cnews"].Value.ToString());
            }
            catch
            {
                MessageBox.Show("not Exist");
            }
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

       
    }
}
