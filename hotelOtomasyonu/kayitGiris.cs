using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace hotelOtomasyonu
{
    class kayitGiris
    {
        DataBase db = new DataBase();
        public string kulAdi_tut { get; set; }
        public string sifre_tut { get; set; }
        public string girisDurumu { get; set; }
        public void MusteriGiris(string kulAdi, string sifre)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand loginName = new SqlCommand("select kullaniciAdi from musteriBilgileri where kullaniciAdi=@kulAdi", db.baglanti);
                loginName.Parameters.AddWithValue("@kulAdi", kulAdi);
                SqlDataReader kulAdi_oku = loginName.ExecuteReader();
                if (kulAdi_oku.Read())
                {
                    kulAdi_tut = kulAdi_oku["kullaniciAdi"].ToString();
                    SqlCommand loginPw = new SqlCommand("select sifre from musteriBilgileri where sifre=@sifre", db.baglanti);
                    loginPw.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader loginPw_oku = loginPw.ExecuteReader();
                    if (loginPw_oku.Read())
                    {
                        sifre_tut = loginPw_oku["sifre"].ToString();
                        girisDurumu = kulAdi_tut + " " + sifre_tut;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı şifreyi yanlış girdin!", "Hata | Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loginPw.Dispose();
                    loginPw_oku.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adını yanlış girdin!", "Hata | Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                loginName.Dispose();
                kulAdi_oku.Close();
                db.baglanti.Close();
            }

            catch { }

            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
