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
    class cAdisyon
    {
        
        cGenel gnl = new cGenel();

        #region fields
        private int _id;
        private int _servis_tur_no;
        private decimal _tutar;
        private DateTime _tarih;
        private int _personel_id;
        private int _durum;
        private int _masa_id;
        #endregion

        #region Properties
        public int id { get => _id; set => _id = value; }
        public int servis_tur_no { get => _servis_tur_no; set => _servis_tur_no = value; }
        public decimal tutar { get => _tutar; set => _tutar = value; }
        public DateTime tarih { get => _tarih; set => _tarih = value; }
        public int personel_id { get => _personel_id; set => _personel_id = value; }
        public int durum { get => _durum; set => _durum = value; }
        public int masa_id { get => _masa_id; set => _masa_id = value; }
        #endregion

        public int getByAddition(int masa_id)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 id From adisyonlar Where masa_id=@masa_id Order by id desc", con);

            cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = masa_id;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                masa_id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return masa_id;



        } //açık olan masanın adisyon numarası

        public bool setByAdditionNew(cAdisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into adisyonlar(servis_tur_no, tarih, personel_id, masa_id, durum) values(@servis_tur_no, @tarih, @personel_id, @masa_id, @durum)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@servis_tur_no", SqlDbType.Int).Value = Bilgiler._servis_tur_no;

                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = Bilgiler._tarih;
                cmd.Parameters.Add("@personel_id", SqlDbType.Int).Value = Bilgiler._personel_id;
                cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = Bilgiler._masa_id;
                cmd.Parameters.Add("@durum", SqlDbType.Bit).Value = 0;
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

        public void adisyonKapat(int adisyon_id, int durum)
        {
            cGenel gnl = new cGenel();
            

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update adisyonlar set durum=@durum where id=@adisyon_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyon_id", SqlDbType.Int).Value = adisyon_id;
                cmd.Parameters.Add("durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();

            }

                   }

        public int paketAdisyonIdBulAdedi()
        {
            int miktar = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from adisyonlar where (durum=0) and (servis_tur_no=2)", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            return miktar;

        }   

        public void acikPaketAdisyonlar(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparisleri.musteri_id, musteriler.ad +''+musteriler.soyad as musteri, adisyonlar.id as adisyon_id from paketSiparisleri Inner Join musteriler on musteriler.id=paketSiparisleri.musteri_id Inner Join adisyonlar on adisyonlar.id=paketSiparisleri.adisyon_id where adisyonlar.durum=0", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["musteri_id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyon_id"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
           

        }

        public int musterininsonadisyonId(int musteri_id)
        {

            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.id from adisyonlar Inner Join paketSiparisleri on paketSiparisleri.adisyon_id=adisyonlar.id where paketSiparisleri.durum=0 and adisyonlar.durum=0 and paketSiparisleri.musteri_id=@musteri_id", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@musteri_id", SqlDbType.Int).Value = musteri_id;

              
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void musteriDetaylar(ListView lv, int musteri_id)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparisleri.musteri_id, paketSiparisleri.adisyon_id, musteriler.ad, musteriler.soyad, CONVERT(varchar(10), adisyonlar.tarih, 104) as tarih from adisyonlar Inner Join paketSiparisleri on paketSiparisleri.adisyon_id=adisyonlar.id Inner Join musteriler on musteriler.id=paketSiparisleri.musteri_id where adisyonlar.servis_tur_no=2 and adisyonlar.durum=0 and paketSiparisleri.musteri_id=@musteri_id", con);

            cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["musteri_id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["tarih"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyon_id"].ToString());
                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            


        }

        public int rezervasyonAdisyonAc(cAdisyon bilgiler)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into adisyonlar(servis_tur_no, tarih, personel_id, masa_id) values(@servis_tur_no, @tarih, @personel_id, @masa_id); Select scope_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@servis_tur_no", SqlDbType.Int).Value = bilgiler._servis_tur_no;

                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = bilgiler._tarih;
                cmd.Parameters.Add("@personel_id", SqlDbType.Int).Value = bilgiler._personel_id;
                cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = bilgiler._masa_id;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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

    }
    
}