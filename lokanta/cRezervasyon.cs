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
    class cRezervasyon
    {
        #region Fields
        private int _id;
        private int _masa_id;
        private int _musteri_id;
        private DateTime _tarih;
        private int _kisi_sayisi;
        private string _aciklama;
        private int _adisyon_id;
        #endregion

        #region Properties
        public int id { get => _id; set => _id = value; }
        public int masa_id { get => _masa_id; set => _masa_id = value; }
        public int musteri_id { get => _musteri_id; set => _musteri_id = value; }
        public DateTime tarih { get => _tarih; set => _tarih = value; }
        public int kisi_sayisi { get => _kisi_sayisi; set => _kisi_sayisi = value; }
        public string aciklama { get => _aciklama; set => _aciklama = value; }
        public int adisyon_id { get => _adisyon_id; set => _adisyon_id = value; } 
        #endregion

        public int getByClientFromRezervasyon(int masa_id)
        {
            cGenel gnl = new cGenel();
            int musteri_id = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 musteri_id from rezervasyonlar where masa_id=@masa_id order by musteri_id desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("masa_id", SqlDbType.Int).Value = masa_id;
                musteri_id = Convert.ToInt32(cmd.ExecuteScalar());

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


            return musteri_id;
        } //    Müşteri_id masa numarasına göre

        public bool rezervatinClose(int adisyon_id)
        {
            cGenel gnl = new cGenel();
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update rezervasyonlar set durum=1 where adisyon_id=@adisyon_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyon_id", SqlDbType.Int).Value = adisyon_id;
                result = Convert.ToBoolean(cmd.ExecuteScalar());

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

            return result;
        } //Hesap kapatırken rezervasyonlu masayı kapattık.

        public void musteriIdGetirFromRezervasyon(ListView lv)
        {
            cGenel gnl = new cGenel();
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select rezervasyonlar.musteri_id, (ad+soyad) as musteri from rezervasyonlar Inner Join musteriler on rezervasyonlar.musteri_id=musteriler.id where rezervasyonlar.durum=0", conn);

            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["musteri_id"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        } //Rezervasyon getir

        public void eskiRezervasyonGetir(ListView lv, int musteri_id)
        {
            cGenel gnl = new cGenel();
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select rezervasyonlar.musteri_id, ad, soyad, adisyon_id, tarih from rezervasyonlar Inner Join musteriler on rezervasyonlar.musteri_id=musteriler.id where rezervasyonlar.musteri_id=@musteri_id and rezervasyonlar.durum=0 order by rezervasyonlar.id desc", conn);
            comm.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["musteri_id"].ToString());
                lv.Items[i].SubItems.Add(dr["ad"].ToString());
                lv.Items[i].SubItems.Add(dr["soyad"].ToString());
                lv.Items[i].SubItems.Add(dr["adisyon_id"].ToString());
                lv.Items[i].SubItems.Add(dr["tarih"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        } //eski rezervasyon getir

        public DateTime enSonRezervasyonTarihi(int musteri_id)
        {

           
                DateTime tar = new DateTime();
                tar = DateTime.Now;
                cGenel gnl = new cGenel();
                SqlConnection conn = new SqlConnection(gnl.conString);
                SqlCommand comm = new SqlCommand("Select tarih from rezervasyonlar where rezervasyonlar.musteri_id=@musteri_id and rezervasyonlar.durum=0 order by rezervasyonlar.id desc", conn);
                comm.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                tar = Convert.ToDateTime(comm.ExecuteScalar());
               
                conn.Dispose();
                conn.Close();
           
                return tar;
        }

        public int acikRezervasyonSayisi()
        {
            int sonuc = 0;
            cGenel gnl = new cGenel();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select count(*) from rezervasyonlar where rezervasyonlar.durum=0", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch(Exception)
            {
                throw;
            }
            conn.Dispose();
            conn.Close();

            return sonuc;
        }

        public bool rezervasyonAcikmiKontrol(int musteri_id)
        {
            cGenel gnl = new cGenel();
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 rezervasyonlar.id from rezervasyonlar where musteri_id=@musteri_id and durum=1 order by id desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;
                result = Convert.ToBoolean(cmd.ExecuteScalar());

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

            return result;
        } //rezervasyon kontrolü

        public bool rezervasyonAc(cRezervasyon r)
        {
            cGenel gnl = new cGenel();
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into rezervasyonlar (musteri_id, masa_id, adisyon_id, kisi_sayisi, tarih, aciklama, durum) values (@musteri_id, @masa_id, @adisyon_id, @kisi_sayisi, @tarih, @aciklama, 1)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = r._musteri_id;
                cmd.Parameters.Add("masa_id", SqlDbType.Int).Value = r._masa_id;
                cmd.Parameters.Add("adisyon_id", SqlDbType.Int).Value = r._adisyon_id;
                cmd.Parameters.Add("kisi_sayisi", SqlDbType.Int).Value = r._kisi_sayisi;
                cmd.Parameters.Add("tarih", SqlDbType.Date).Value = r._tarih;
                cmd.Parameters.Add("aciklama", SqlDbType.VarChar).Value = r._aciklama;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

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

            return result;
        }

        public int RezerveMasaIdGetir(int musteri_id)
        {
            int sonuc = 0;
            cGenel gnl = new cGenel();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select rezervasyonlar.masa_id from rezervasyonlar Inner Join adisyonlar on rezervasyonlar.adisyon_id=adisyonlar.id where rezervasyonlar.durum=1 and adisyonlar.durum=0 and rezervasyonlar.musteri_id=@musteri_id", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                comm.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;
                sonuc = Convert.ToInt32(comm.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }
            conn.Dispose();
            conn.Close();

            return sonuc;
        } //rezerve masanın id sini getir.



    }
}
