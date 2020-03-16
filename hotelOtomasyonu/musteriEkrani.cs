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
    public partial class musteriEkrani : Form
    {
        public musteriEkrani()
        {
            InitializeComponent();
        }
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

        private void musteriEkrani_Load(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
            dataGridView2.DataSource = me.tablola();
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
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // verileri yansıtma
            idtut.Text = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
            musteriAdi.Text = dataGridView2.Rows[e.RowIndex].Cells["adi"].Value.ToString();
            musteriSoyAdi.Text = dataGridView2.Rows[e.RowIndex].Cells["soyadi"].Value.ToString();
            txtcinsiyeti.Text = dataGridView2.Rows[e.RowIndex].Cells["cinsiyet"].Value.ToString();
            tel.Text = dataGridView2.Rows[e.RowIndex].Cells["telefon"].Value.ToString();
            txtmaile.Text = dataGridView2.Rows[e.RowIndex].Cells["mail"].Value.ToString();
            txttcNo.Text = dataGridView2.Rows[e.RowIndex].Cells["tcNo"].Value.ToString();
            seciliOdalar.Text = dataGridView2.Rows[e.RowIndex].Cells["odaNo"].Value.ToString();
            txtucreti.Text = dataGridView2.Rows[e.RowIndex].Cells["ucret"].Value.ToString();
            txtgirisTarihie.Value = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["girisTarihi"].Value);
            txtcikisTarihie.Value = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells["cikisTarihi"].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
            dataGridView2.DataSource = me.tablola();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtcinsiyeti.Text = "";
            txtmaile.Text = "";
            txttcNo.Text = "";
            txtucreti.Text = "";
            tel.Text = "";
            seciliOdalar.Text = "";
            musteriAdi.Text = "";
            musteriSoyAdi.Text = "";
            txtcikisTarihie.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            txtgirisTarihie.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
        }
 
        private void button125_Click(object sender, EventArgs e)
        {
            DateTime girisTarih = Convert.ToDateTime(txtgirisTarihie.Value);
            DateTime cikisTarih = Convert.ToDateTime(txtcikisTarihie.Value);
            int id = Convert.ToInt16(idtut.Text);
            csMusteriEkrani me = new csMusteriEkrani();
            me.musteriGuncelle(id, musteriAdi.Text, musteriSoyAdi.Text, txtcinsiyeti.Text, tel.Text, txtmaile.Text, txttcNo.Text, seciliOdalar.Text, txtucreti.Text, girisTarih, cikisTarih);
            dataGridView2.DataSource = me.tablola();
            MessageBox.Show(musteriAdi.Text + " " + musteriSoyAdi.Text +" " +"isimli kişini verileri güncellenmiştir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idtut.Text);
            csMusteriEkrani me = new csMusteriEkrani();
            me.musteriSil(id,seciliOdalar.Text);
            dataGridView2.DataSource = me.tablola();
            MessageBox.Show(musteriAdi.Text + " " + musteriSoyAdi.Text +" "+ "isimli kişini verileri silinmiştir");

        }
            
        private void button4_Click(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
            dataGridView2.DataSource= me.aramaYap(txtara.Text);

        }


    }
}
