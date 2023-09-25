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
    public partial class Form2 : Form
    {
        string ordb = "Data Source = orcl;User Id= scott;Password=tiger;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ReaderID from Reader";
            cmd.CommandType = CommandType.Text;

            OracleDataReader d = cmd.ExecuteReader();
            while (d.Read())
            {
                comboBox1.Items.Add(d[0]);
            }
            d.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select FName,LName,Email,ReaderPassword,age,FAVCategory from Reader where ReaderID=:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader data_Reader = c.ExecuteReader();
            if (data_Reader.Read())
            {

                textBox7.Text = data_Reader[0].ToString();
                textBox1.Text = data_Reader[1].ToString();
                textBox6.Text = data_Reader[2].ToString();
                textBox2.Text = data_Reader[3].ToString();
                textBox5.Text = data_Reader[4].ToString();
                textBox4.Text = data_Reader[5].ToString();
            }
            data_Reader.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Reader values(:id,:fname,:lname,:email,:password,:age,:fav_cat,:login_date,:admin_ID)";
            cmd.Parameters.Add("id", comboBox1.Text);
            cmd.Parameters.Add("fname", textBox7.Text);
            cmd.Parameters.Add("lname", textBox1.Text);
            cmd.Parameters.Add("email", textBox6.Text);
            cmd.Parameters.Add("password", textBox2.Text);
            cmd.Parameters.Add("age", textBox5.Text);
            cmd.Parameters.Add("fav_cat", textBox4.Text);
            cmd.Parameters.Add("login_date",DateTime.Now);
            cmd.Parameters.Add("admin_ID", 111);
            try
            {
                int x = cmd.ExecuteNonQuery();
                if (x != -1)
                {
                    comboBox1.Items.Add(comboBox1.Text);
                    MessageBox.Show("wellcome in our news portal");
                }
            }
            catch
            {
                MessageBox.Show("repeated registration");
            }
           
        }
          
        

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
