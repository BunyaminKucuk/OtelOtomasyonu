using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace hotelOtomasyonu
{
    public partial class frmMusteriKayit : Form
    {
        public frmMusteriKayit()
        {
            InitializeComponent();
        }
        //form hareketi için
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }

                    return;
            }
            base.WndProc(ref m);
        }
        ArrayList odalar = new ArrayList();
        void koltukYazdir()
        {
            string oda = "";
            for(int i =0;i<odalar.Count;i++)
            {
                oda += odalar[i].ToString() + ",";
            }
            if (odalar.Count >= 1)
            {
                oda = oda.Remove(oda.Length - 1, 1);
            }
            seciliOdalar.Text = oda;
        }

        private void odaTikla(object sender, EventArgs e)
        {

            if (((Button)sender).BackColor == Color.Lime)
            {
                ((Button)sender).BackColor = Color.DarkOrange;
                if (!odalar.Contains(((Button)sender).Text))
                {
                    odalar.Add(((Button)sender).Text);
                }
                koltukYazdir();
            }
            else if (((Button)sender).BackColor == Color.DarkOrange)
            {
                ((Button)sender).BackColor = Color.Lime;
                if (odalar.Contains(((Button)sender).Text))
                {
                    odalar.Remove(((Button)sender).Text);
                }
                koltukYazdir();
            }
        }
        public DateTime girisTarih { get; set; }
        public DateTime cikisTarih { get; set; }
        private void button125_Click(object sender, EventArgs e)
        {

            girisTarih = Convert.ToDateTime(girisTarihi.Value);
            cikisTarih = Convert.ToDateTime(cikisTarihi.Value);


            musteriKayit kayit = new musteriKayit();
            for(int i=0;i<odalar.Count;i++)
            {
                string oda = odalar[i].ToString();
                kayit.kayitAl(musteriAdi.Text, musteriSoyAdi.Text, cinsiyet.Text, tel.Text, mail.Text, txttcNo.Text, oda, ucret.Text, girisTarih, cikisTarih);
                    
            }
            tmrKontrol.Start();
        }

        private void tmrKontrol_Tick(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand donustur = new SqlCommand("select * from odalar where durumu=@durum", db.baglanti);
                donustur.Parameters.AddWithValue("@durum", "Dolu");
                SqlDataReader donustur_oku = donustur.ExecuteReader();
               
                while (donustur_oku.Read())
                {
                    string butonAdi = donustur_oku["butonAdi"].ToString();
                    string durumu = donustur_oku["durumu"].ToString();
                   
                    if (butonAdi=="oda1" && durumu=="Dolu")
                    {
                        ODA1.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda2" && durumu == "Dolu")
                    {
                        ODA2.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda3" && durumu == "Dolu")
                    {
                        ODA3.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda4" && durumu == "Dolu")
                    {
                        ODA4.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda5" && durumu == "Dolu")
                    {
                        ODA5.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda6" && durumu == "Dolu")
                    {
                        ODA6.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda7" && durumu == "Dolu")
                    {
                        ODA7.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda8" && durumu == "Dolu")
                    {
                        ODA8.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda9" && durumu == "Dolu")
                    {
                        ODA9.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda10" && durumu == "Dolu")
                    {
                        ODA10.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda11" && durumu == "Dolu")
                    {
                        ODA11.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda12" && durumu == "Dolu")
                    {
                        ODA12.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda13" && durumu == "Dolu")
                    {
                        ODA13.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda14" && durumu == "Dolu")
                    {
                        ODA14.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda15" && durumu == "Dolu")
                    {
                        ODA15.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda16" && durumu == "Dolu")
                    {
                        ODA16.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda17" && durumu == "Dolu")
                    {
                        ODA17.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda18" && durumu == "Dolu")
                    {
                        ODA18.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda19" && durumu == "Dolu")
                    {
                        ODA19.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda20" && durumu == "Dolu")
                    {
                        ODA20.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda21" && durumu == "Dolu")
                    {
                        ODA21.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda22" && durumu == "Dolu")
                    {
                        ODA22.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda23" && durumu == "Dolu")
                    {
                        ODA23.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda24" && durumu == "Dolu")
                    {
                        ODA24.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda25" && durumu == "Dolu")
                    {
                        ODA25.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda26" && durumu == "Dolu")
                    {
                        ODA26.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda27" && durumu == "Dolu")
                    {
                        ODA27.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda28" && durumu == "Dolu")
                    {
                        ODA28.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda29" && durumu == "Dolu")
                    {
                        ODA29.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda30" && durumu == "Dolu")
                    {
                        ODA30.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda31" && durumu == "Dolu")
                    {
                        ODA31.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda32" && durumu == "Dolu")
                    {
                        ODA32.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda33" && durumu == "Dolu")
                    {
                        ODA33.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda34" && durumu == "Dolu")
                    {
                        ODA34.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda35" && durumu == "Dolu")
                    {
                        ODA35.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda36" && durumu == "Dolu")
                    {
                        ODA36.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda37" && durumu == "Dolu")
                    {
                        ODA37.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda38" && durumu == "Dolu")
                    {
                        ODA38.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda39" && durumu == "Dolu")
                    {
                        ODA39.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda40" && durumu == "Dolu")
                    {
                        ODA40.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda41" && durumu == "Dolu")
                    {
                        ODA41.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda42" && durumu == "Dolu")
                    {
                        ODA42.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda43" && durumu == "Dolu")
                    {
                        ODA43.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda44" && durumu == "Dolu")
                    {
                        ODA44.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda45" && durumu == "Dolu")
                    {
                        ODA45.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda46" && durumu == "Dolu")
                    {
                        ODA46.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda47" && durumu == "Dolu")
                    {
                        ODA47.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda48" && durumu == "Dolu")
                    {
                        ODA48.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda49" && durumu == "Dolu")
                    {
                        ODA49.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda50" && durumu == "Dolu")
                    {
                        ODA50.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda51" && durumu == "Dolu")
                    {
                        ODA51.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda52" && durumu == "Dolu")
                    {
                        ODA52.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda53" && durumu == "Dolu")
                    {
                        ODA53.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda54" && durumu == "Dolu")
                    {
                        ODA54.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda55" && durumu == "Dolu")
                    {
                        ODA55.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda56" && durumu == "Dolu")
                    {
                        ODA56.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda57" && durumu == "Dolu")
                    {
                        ODA57.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda58" && durumu == "Dolu")
                    {
                        ODA58.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda59" && durumu == "Dolu")
                    {
                        ODA59.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda60" && durumu == "Dolu")
                    {
                        ODA60.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda61" && durumu == "Dolu")
                    {
                        ODA61.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda62" && durumu == "Dolu")
                    {
                        ODA62.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda63" && durumu == "Dolu")
                    {
                        ODA63.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda64" && durumu == "Dolu")
                    {
                        ODA64.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda65" && durumu == "Dolu")
                    {
                        ODA65.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda66" && durumu == "Dolu")
                    {
                        ODA66.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda67" && durumu == "Dolu")
                    {
                        ODA67.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda68" && durumu == "Dolu")
                    {
                        ODA68.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda69" && durumu == "Dolu")
                    {
                        ODA69.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda70" && durumu == "Dolu")
                    {
                        ODA70.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda71" && durumu == "Dolu")
                    {
                        ODA71.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda72" && durumu == "Dolu")
                    {
                        ODA72.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda73" && durumu == "Dolu")
                    {
                        ODA73.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda74" && durumu == "Dolu")
                    {
                        ODA74.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda75" && durumu == "Dolu")
                    {
                        ODA75.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda76" && durumu == "Dolu")
                    {
                        ODA76.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda77" && durumu == "Dolu")
                    {
                        ODA77.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda78" && durumu == "Dolu")
                    {
                        ODA78.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda79" && durumu == "Dolu")
                    {
                        ODA79.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda80" && durumu == "Dolu")
                    {
                        ODA80.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda81" && durumu == "Dolu")
                    {
                        ODA81.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda82" && durumu == "Dolu")
                    {
                        ODA82.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda83" && durumu == "Dolu")
                    {
                        ODA83.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda84" && durumu == "Dolu")
                    {
                        ODA84.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda85" && durumu == "Dolu")
                    {
                        ODA85.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda86" && durumu == "Dolu")
                    {
                        ODA86.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda87" && durumu == "Dolu")
                    {
                        ODA87.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda88" && durumu == "Dolu")
                    {
                        ODA88.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda89" && durumu == "Dolu")
                    {
                        ODA89.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda90" && durumu == "Dolu")
                    {
                        ODA90.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda91" && durumu == "Dolu")
                    {
                        ODA91.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda92" && durumu == "Dolu")
                    {
                        ODA92.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda93" && durumu == "Dolu")
                    {
                        ODA93.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda94" && durumu == "Dolu")
                    {
                        ODA94.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda95" && durumu == "Dolu")
                    {
                        ODA95.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda96" && durumu == "Dolu")
                    {
                        ODA96.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda97" && durumu == "Dolu")
                    {
                        ODA97.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda98" && durumu == "Dolu")
                    {
                        ODA98.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda99" && durumu == "Dolu")
                    {
                        ODA99.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda100" && durumu == "Dolu")
                    {
                        ODA100.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda101" && durumu == "Dolu")
                    {
                        ODA101.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda102" && durumu == "Dolu")
                    {
                        ODA102.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda103" && durumu == "Dolu")
                    {
                        ODA103.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda104" && durumu == "Dolu")
                    {
                        ODA104.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda105" && durumu == "Dolu")
                    {
                        ODA105.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda106" && durumu == "Dolu")
                    {
                        ODA106.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda107" && durumu == "Dolu")
                    {
                        ODA107.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda108" && durumu == "Dolu")
                    {
                        ODA108.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda109" && durumu == "Dolu")
                    {
                        ODA109.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda110" && durumu == "Dolu")
                    {
                        ODA110.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda111" && durumu == "Dolu")
                    {
                        ODA111.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda112" && durumu == "Dolu")
                    {
                        ODA112.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda113" && durumu == "Dolu")
                    {
                        ODA113.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda114" && durumu == "Dolu")
                    {
                        ODA114.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda115" && durumu == "Dolu")
                    {
                        ODA115.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda116" && durumu == "Dolu")
                    {
                        ODA116.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda117" && durumu == "Dolu")
                    {
                        ODA117.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda118" && durumu == "Dolu")
                    {
                        ODA118.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda119" && durumu == "Dolu")
                    {
                        ODA119.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda120" && durumu == "Dolu")
                    {
                        ODA120.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda121" && durumu == "Dolu")
                    {
                        ODA121.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda122" && durumu == "Dolu")
                    {
                        ODA122.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda123" && durumu == "Dolu")
                    {
                        ODA123.BackColor = Color.Red;
                    }
                    if (butonAdi == "oda124" && durumu == "Dolu")
                    {
                        ODA124.BackColor = Color.Red;
                    }
                }
                donustur.Dispose();
                donustur_oku.Close();
                db.baglanti.Close();
                tmrKontrol.Stop();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show("" + hata);
            }
            finally
            {
                db.baglanti.Close();
            }
        }

        private void frmMusteriKayit_Load(object sender, EventArgs e)
        {
            tmrKontrol.Start();
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geri_Click(object sender, EventArgs e)
        {
            
            Form anaEkran = new anaEkran();
            anaEkran.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // hesepla kısımı
            DateTime tarih1, tarih2;
            TimeSpan günsayisi;
            tarih1 = girisTarihi.Value;
            tarih2 = cikisTarihi.Value;
            günsayisi = tarih1 - tarih2;
            aralik.Text = günsayisi.Duration().TotalDays.ToString();
            string a = aralik.Text;
            int kalicakGün = Convert.ToInt16(a);
            string metin = seciliOdalar.Text;
            string[] parca = metin.Split(',');
            int odaSayisi = parca.Length;
            int odaUcreti = 0;
            //int sonuc = 0;
            odasayısı.Text = odaSayisi.ToString();
            int kralUcret = 0;
            if (seciliOdalar.Text == "ODA 122")
            {
                 kralUcret = odaSayisi * (kalicakGün * 1600);
                 ucret.Text = kralUcret.ToString();
            }
            else if(seciliOdalar.Text == "ODA 124")
            {
                kralUcret = odaSayisi * (kalicakGün * 1600);
                ucret.Text = kralUcret.ToString();
            }
            else if(seciliOdalar.Text == "ODA 121")
            {
                kralUcret = odaSayisi * (kalicakGün * 1600);
                ucret.Text = kralUcret.ToString();
            }
            else if(seciliOdalar.Text == "KODA 123")
            {
                kralUcret = odaSayisi * (kalicakGün * 1600);
                ucret.Text = kralUcret.ToString();
            }
            else
            {
               odaUcreti = odaSayisi * (kalicakGün * 400);
               ucret.Text = odaUcreti.ToString();

            }
        }
    }
}
