﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f4 = new Form5();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f5 = new Form4();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f5 = new Form6();
            f5.Show();
        }
    }
}
