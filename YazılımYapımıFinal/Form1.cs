using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazılımYapımıFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form ekranını açma işlemi
            Kelime k = new Kelime();
            k.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form ekranını açma işlemi
            İşlem i = new İşlem();
            i.Show();
            this.Hide();
        }
    }
}
