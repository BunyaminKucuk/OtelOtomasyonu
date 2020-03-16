﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace hotelOtomasyonu
{
    class yeniSifre
    {

        DataBase db = new DataBase();
        public string cevap_tut { get; set; }
        public string soru_tut { get; set; }
        public void Guncelle(string adSoyad, string kulAdi, string sifre,string tekrar,string soru, string cevap, GroupBox grup)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                if (sifre==tekrar)
                {
                    db.baglanti.Open();
                    SqlCommand bilgiGuncelle = new SqlCommand("update musteriBilgileri set adSoyad=@adSoyad,sifre=@sifre where kullaniciAdi=@kullaniciAdi and soru=@soru and cevap=@cevap",db.baglanti);
                    bilgiGuncelle.Parameters.AddWithValue("@adSoyad", adSoyad);
                    bilgiGuncelle.Parameters.AddWithValue("@sifre", sifre);
                    bilgiGuncelle.Parameters.AddWithValue("@kullaniciAdi", kulAdi);
                    bilgiGuncelle.Parameters.AddWithValue("@soru", soru);
                    bilgiGuncelle.Parameters.AddWithValue("@cevap", cevap);
                    int a = bilgiGuncelle.ExecuteNonQuery();
                    bilgiGuncelle.Dispose();
                    if (a == 1)
                    {
                        MessageBox.Show("İşlem basarılı", " Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (Control item in grup.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                            }
                        }
                    }
                    else { MessageBox.Show("Girdiğiniz Bilgiler hatalıdır."); }
             
                }

                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor!", "Hata | Hotel Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                db.baglanti.Close();
                
            }

            catch(Exception e) {
                MessageBox.Show(e.ToString());
            }

            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
