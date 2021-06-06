using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YazılımYapımıFinal
{
    public partial class Kelime : Form
    {
        public Kelime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            //bulunacakkelime diye alfabedeki bütün harfleri içeren bir kelime oluşturuluyor daha sonra bu kelimenin içinden rastgele
            //harfler seçilerek rastgele kelimemiz oluşturuluyor. Burada sesli harfleri iki kere yazdım daha anlamlı harfler gelmesi için
            string bulunacakKelime = "aabcçdeefgğhııiijklmnooööprsştuuüüvyz";
            string harfler = "";

            for (int i = 0; i < 8; i++)
            {
                int harfnumarasi = rastgele.Next(0, bulunacakKelime.Length - 1);
                harfler += bulunacakKelime[harfnumarasi];
            }
            //Harfler labellara yazdırılıyor
            label1.Text = harfler[0].ToString();
            label2.Text = harfler[1].ToString();
            label3.Text = harfler[2].ToString();
            label4.Text = harfler[3].ToString();
            label5.Text = harfler[4].ToString();
            label6.Text = harfler[5].ToString();
            label7.Text = harfler[6].ToString();
            label8.Text = harfler[7].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kullanıcının tahmin ettiği kelime alınıyor
            string hedefKelime = textBox1.Text;
            //Rastgele oluşturulan harfler bir kelimeye atanıyor
            string rastgeleHarfler = label1.Text + label2.Text + label3.Text + label4.Text + label5.Text + label6.Text + label7.Text + label8.Text+textBox2.Text;
            //Girdiğimiz kelime rastgele harflerle uyuşuyor mu kontrol ediliyor
            for (int i = 0; i < hedefKelime.Length - 1; i++)
            {
                if (rastgeleHarfler.Contains(hedefKelime[i]))
                {
                    continue;
                }

                else
                {
                    MessageBox.Show("Girdiğiniz kelime rastgele harflerle eşleşmiyor !!!!");
                    return;
                }
            }

            int sıraNo = Sözlük.FindString(hedefKelime);
            if (sıraNo != -1)
            {
                int uzunluk = hedefKelime.Length;
                MessageBox.Show("Kulime bulunmuştur  " + uzunluk + " harfli olduğu için  " + uzunluk + "puan alınmıştır  ");

            }
            else MessageBox.Show("Bulunamamıştır");
        }

        private void Kelime_Load(object sender, EventArgs e)
        {
            //Dosya okuma işlemleri
            string file = @"C:\Users\Cengizhan\source\repos\YazılımYapımıFinal\kelime.txt";
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1254)))
            {
                //Dosyadan bir kelime okunuyor sonra while döngüsüne alınıyor. Daha sonrasında okunan kelime elimizdeki kelime ile aynı mı diye kontrol ediliyor.
                //Eğer aynı değilse sonra okunacak değere geçiliyor okunacak değer kalmayıncaya dek devam ediyor

                string oku = sr.ReadLine();
                while (oku != null)
                {
                    while (oku != null)
                    {
                        Sözlük.Items.Add(oku);
                        oku = sr.ReadLine();
                    }
                }


                sr.Close();
            }



            int i = 0;
            string k = "";
            for (int j = 0; j < Sözlük.Items.Count; j++)
            {

                k = Sözlük.Items[j].ToString();
                if (k.IndexOf("-", 0, k.Length) != -1)
                {
                    Sözlük.Items.RemoveAt(j);
                    continue;
                }
                if (k.IndexOf(",", 0, k.Length) != -1)
                {
                    Sözlük.Items.RemoveAt(j);
                    continue;
                }
                if (k.IndexOf("(", 0, k.Length) != -1)
                {
                    Sözlük.Items.RemoveAt(j);
                    continue;
                }
                if (k.IndexOf("'", 0, k.Length) != -1)
                {
                    Sözlük.Items.RemoveAt(j);
                    continue;
                }



            }
        }
    }
}
