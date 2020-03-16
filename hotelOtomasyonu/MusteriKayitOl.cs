using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace hotelOtomasyonu
{
    class MusteriKayitOl
    {
        DataBase db = new DataBase();
        public void kayitOl(string adiSoyadi, string KulAdi, string sifre, string tekrar, string soru,string cevap,GroupBox grup)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                if(sifre==tekrar)
                {
                    db.baglanti.Open();
                    SqlCommand kayit_Ol = new SqlCommand("insert into musteriBilgileri values(@adSoyad,@kullaniciAdi,@sifre,@soru,@cevap)", db.baglanti);
                    kayit_Ol.Parameters.AddWithValue("@adSoyad", adiSoyadi);
                    kayit_Ol.Parameters.AddWithValue("@kullaniciAdi", KulAdi);
                    kayit_Ol.Parameters.AddWithValue("@sifre", sifre);
                    kayit_Ol.Parameters.AddWithValue("@soru", soru);
                    kayit_Ol.Parameters.AddWithValue("@cevap", cevap);
                    kayit_Ol.ExecuteNonQuery();
                    MessageBox.Show(adiSoyadi + " " + "İsimli müşteri başarılı bir şekilde kayıt oluşmuştur: ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (Control item in grup.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                    }

                    kayit_Ol.Dispose();

                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor", "HATA",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show("" + hata);
            }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
