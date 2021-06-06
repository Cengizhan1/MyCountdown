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
    public partial class İşlem : Form
    {
        public İşlem()
        {
            InitializeComponent();
        }
        Random rastgele = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            //Rastgele sayılar üretiliyor 
            int sayı1 = rastgele.Next(1, 10);
            int sayı2 = rastgele.Next(1, 10);
            int sayı3 = rastgele.Next(1, 10);
            int sayı4 = rastgele.Next(1, 10);
            int sayı5 = rastgele.Next(1, 10);
            int sayı6 = rastgele.Next(1, 10) * 10;
            int sayı7 = rastgele.Next(100, 1000);
            //Rastgele sayılar labellara aktarılıyor
            label1.Text = sayı1.ToString();
            label2.Text = sayı2.ToString();
            label3.Text = sayı3.ToString();
            label4.Text = sayı4.ToString();
            label5.Text = sayı5.ToString();
            label6.Text = sayı6.ToString();
            label7.Text = sayı7.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Fonksiyon cagrılıyor değeri sonuca aktarılıyor
            double sonuc = Evaluate(textBox1.Text);
            double hedef = Convert.ToDouble(label7.Text);
            //Hedef ve sonuc karsılaştırılıyor
            if (hedef == sonuc)
            {
                MessageBox.Show("Tebrikler cevabınız doğru  !!!  tam puan aldınız ...");
                return;
            }
            double fark = hedef - sonuc;
            if (fark <= 9 && fark >= -9)
            {
                MessageBox.Show("Hedef sayı ile aradaki fark  " + fark + " olduğu için " + (10 - fark) + " puan alınmıştır...");
                return;
            }
            MessageBox.Show(" Hedef sayıya 9 farktan uzak olduğun için puan alamadınız ...");
        }

        //Bu fonksiyonda textboxa string olarak girilen değerlerin dönütürülüp işlemlerin yapılması sağlanıyor
        public static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    }
}
