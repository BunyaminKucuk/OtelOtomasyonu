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

namespace hotelOtomasyonu
{
    public partial class frmOdalar : Form
    {
        public frmOdalar()
        {
            InitializeComponent();
        }
        ArrayList odalar = new ArrayList();
        private void frmOdalar_Load(object sender, EventArgs e)
        {
            string odaAdi = "";
            string yeniDeger = "";

            for (int i = 1; i < this.Controls.Count + 1; i++)
            {
                odaAdi = Convert.ToString(this.Controls.Find("oda" + i.ToString(), true).FirstOrDefault() as Button);
                yeniDeger = odaAdi.Split(':').Last();
                odalar.Add(yeniDeger);

            }

            odalarinDurumu();

        }
        void odalarinDurumu()
        {
            string yenioda = "";
            csOdalar oda = new csOdalar();
            try
            {
                foreach (string odaninAdi in odalar) 
                {
                    oda.odaDegerleri(odaninAdi, "Dolu"); 
                    if (oda.durum_oku == "Dolu")
                    {
                        yenioda = odaninAdi;
                        this.Controls.Find(oda.butonAdi, true)[0].BackColor = Color.Red;
                        this.Controls.Find(oda.butonAdi, true)[0].Text =yenioda+"\n"+ oda.alanKisi;
                        oda.durum_oku = "";
                    }
                    

                }
                
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("" + hata); }
        }

        private void frmOdalar_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode==Keys.Escape)
            {

                Form anaEkran = new anaEkran();
                anaEkran.Show();
                this.Hide();
            }

        }
    }
}
