using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    class cSiparis
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _id;
        private int _adisyon_id;
        private int _urun_id;
        private int _adet;
        private int _masa_id; 
        #endregion

        #region Properties
        public int id { get => _id; set => _id = value; }
        public int adisyon_id { get => _adisyon_id; set => _adisyon_id = value; }
        public int urun_id { get => _urun_id; set => _urun_id = value; }
        public int adet { get => _adet; set => _adet = value; }
        public int masa_id { get => _masa_id; set => _masa_id = value; }
     
        #endregion

        public void getByOrder(ListView lv, int adisyon_id)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select urunad, fiyat, satislar.id, satislar.urun_id, satislar.adet From satislar Inner Join urunler on satislar.urun_id = urunler.id Where adisyon_id = @adisyon_id", con);

            SqlDataReader dr=null;
            cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = adisyon_id;
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["urunad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adet"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["fiyat"])*Convert.ToDecimal(dr["adet"])));
                    lv.Items[sayac].SubItems.Add(dr["id"].ToString());

                    sayac++;
                }
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }


        }
        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into satislar(adisyon_id, urun_id, adet, masa_id) values (@adisyon_id, @urun_id, @adet, @masa_id)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = Bilgiler._adisyon_id;
                cmd.Parameters.Add("@urun_id", SqlDbType.Int).Value = Bilgiler._urun_id;
                cmd.Parameters.Add("@adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = Bilgiler._masa_id;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());



            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
               
                con.Dispose();
                con.Close();
            }
            return sonuc;


        }
        
        public void setDeleteOrder(int satis_id)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From satislar Where id=@satis_id)", con);

            cmd.Parameters.Add("@satis_id", SqlDbType.Int).Value = satis_id;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }

        public decimal GenelToplamBul(int musteri_id)
        {
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT SUM(dbo.satislar.adet * fiyat) AS fiyat FROM dbo.musteriler INNER JOIN dbo.paketSiparisleri ON dbo.musteriler.id = dbo.paketSiparisleri.musteri_id INNER JOIN adisyonlar on adisyonlar.id=paketSiparisleri.adisyon_id Inner Join dbo.satislar ON dbo.adisyonlar.id = dbo.satislar.adisyon_id INNER JOIN dbo.urunler ON dbo.satislar.urun_id = dbo.urunler.id WHERE(dbo.paketSiparisleri.musteri_id = @musteri_id) AND(dbo.paketSiparisleri.durum = 0)", con);
            cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar());
              

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {

                con.Dispose();
                con.Close();
            }
            return geneltoplam;

        }

        public void adisyonpaketsiparisDetaylari(ListView lv, int adisyon_id)
        {
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select satislar.id as satis_id, urunler.urunad, urunler.fiyat, satislar.adet from satislar Inner Join adisyonlar on adisyonlar.id=satislar.adisyon_id Inner Join urunler on urunler.id=satislar.urun_id where satislar.adisyon_id=@adisyon_id", con);
            cmd.Parameters.Add("adisyon_id", SqlDbType.Int).Value = adisyon_id;
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int i = 0;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lv.Items.Add(dr["satis_id"].ToString());
                    lv.Items[i].SubItems.Add(dr["urunad"].ToString());
                    lv.Items[i].SubItems.Add(dr["adet"].ToString());
                    lv.Items[i].SubItems.Add(dr["fiyat"].ToString());

                    i++;
                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {

                con.Dispose();
                con.Close();
            }


        }

       
    }

}
