using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace hotelOtomasyonu
{
    class giris
    {
        DataBase db = new DataBase();
        public string kullanicAdi_tut { get; set; }
        public string kullanicıiSifre_tut { get; set; }
        public string girisDurumu { get; set; }
        public void girisYap(string kullaniciAdi, string kullaniciSifre, DateTime tarih)
        {
            if(db.baglanti.State==System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand loginName = new SqlCommand("select kullaniciAdi from kullaniciBilgileri where kullaniciadi=@kulAdi", db.baglanti);
                loginName.Parameters.AddWithValue("@kulAdi", kullaniciAdi);
                SqlDataReader kulAdi_oku = loginName.ExecuteReader();
                if (kulAdi_oku.Read())
                {
                    kullanicAdi_tut = kulAdi_oku["kullaniciAdi"].ToString();
                    SqlCommand loginPw = new SqlCommand("select kullaniciSifre from kullaniciBilgileri where kullaniciSifre=@sifre",db.baglanti);
                    loginPw.Parameters.AddWithValue("@sifre", kullaniciSifre);
                    SqlDataReader loginPw_oku = loginPw.ExecuteReader();
                    if(loginPw_oku.Read())
                    {
                        kullanicıiSifre_tut = loginPw_oku["kullaniciSifre"].ToString();
                        girisDurumu = kullanicAdi_tut + " " + kullanicıiSifre_tut;
                        SqlCommand dateUpdate = new SqlCommand("update kullaniciBilgileri set girisTarihi=@tarih where kullaniciadi=@kulAdi AND kullaniciSifre=@kulSifre", db.baglanti);
                        dateUpdate.Parameters.AddWithValue("@tarih", tarih);
                        dateUpdate.Parameters.AddWithValue("kulAdi", kullanicAdi_tut);
                        dateUpdate.Parameters.AddWithValue("kulSifre", kullanicAdi_tut);
                        dateUpdate.ExecuteNonQuery();
                        dateUpdate.Dispose();
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
