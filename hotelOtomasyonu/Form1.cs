using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //form hareketi için
        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if((int)m.Result==0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }

                    return;
            }
            base.WndProc(ref m);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }


        giris grs = new giris();
        anaEkran main = new anaEkran();
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==string.Empty || textBox2.Text==string.Empty)
            {
                MessageBox.Show("Lütfen kullamıcı adını ve şifrenizi giriniz.", "HATA | Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grs.girisYap(textBox1.Text, textBox2.Text, DateTime.Now);
                string bilgiTut = textBox1.Text.ToString() + " " + textBox2.Text.ToString();
                if(grs.girisDurumu==bilgiTut)
                {
                    main.Show();
                    this.Hide();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //fade kapanıs
            if(this.Opacity>0.0)
            {
                this.Opacity -= 0.025;

            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreGüncelle yeni = new SifreGüncelle();
            yeni.Show();
            this.Hide();

        }

        kayitGiris musteriGiris = new kayitGiris();
        frmKayitliMüsteri Müsteri = new frmKayitliMüsteri();
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Lütfen kullamıcı adını ve şifrenizi giriniz.", "HATA | Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                musteriGiris.MusteriGiris(textBox1.Text, textBox2.Text);
                string bilgiTut = textBox1.Text + " " + textBox2.Text.ToString();
                if (musteriGiris.girisDurumu == bilgiTut)
                {
                    Müsteri.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmkayitOl frm = new frmkayitOl();
            frm.Show();
            this.Hide();
        }
    }
}
