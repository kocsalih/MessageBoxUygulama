using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int islemSonuc = yeniMusteriEkle(new Musteri()
            {

                id = Guid.NewGuid(),
                isim = textBox1.Text,
                soyisim = textBox2.Text,
                emailAdres = textBox3.Text,
                telefonNumarasi = textBox4.Text
            });


            if (islemSonuc > 0)
            {
                DialogResult res = MessageBox.Show("Müşteri Ekleme Başarılı, yeni Müşteri Eklmek istermisiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    bildirim = new NotifyIcon();
                    bildirim.BalloonTipText = "Toplam Müşteri Kayıt Adeti: " + sanalDatabase.musteriler.Count.ToString();
                    bildirim.BalloonTipTitle = "Musteri Adet Bilgisi";
                    bildirim.Visible = true;
                    bildirim.Icon = SystemIcons.Information;
                    bildirim.ShowBalloonTip(2000);
                }

                else if (res == DialogResult.No)
                {


                }

                ekrantemizle();
                ekranlistele();

            }
            else
            {
                MessageBox.Show("Hata: Kayıt ekleme işlemi yapılamadı.");
            }


        }

        private void ekranlistele()
        {
            listBox1.DataSource = sanalDatabase.musteriler;
        }

        private void ekrantemizle()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private int yeniMusteriEkle(Musteri musteri)
        {
            sanalDatabase.musteriler.Add(musteri);
            return 1;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
