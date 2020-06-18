using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace lokanta
{
    class cPaketler
    {
        #region Fields
        private int _id;
        private int _adisyon_id;
        private int _musteri_id;
        private string _aciklama;
        private int _durum;
        private int _odeme_tur_id;
        #endregion

        #region Properties
        public int id { get => _id; set => _id = value; }
        public int adisyon_id { get => _adisyon_id; set => _adisyon_id = value; }
        public int musteri_id { get => _musteri_id; set => _musteri_id = value; }
        public string aciklama { get => _aciklama; set => _aciklama = value; }
        public int durum { get => _durum; set => _durum = value; }
        public int odeme_tur_id { get => _odeme_tur_id; set => _odeme_tur_id = value; }
        #endregion
        cGenel gnl = new cGenel();
        public bool OrderServiceOpen(cPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into paketSiparisleri(adisyon_id, musteri_id, odeme_tur_id, aciklama) Values (@adisyon_id, @musteri_id, @odeme_tur_id, @aciklama)", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = order._adisyon_id;
                cmd.Parameters.Add("@musteri_id", SqlDbType.Int).Value = order._musteri_id;
                cmd.Parameters.Add("@odeme_tur_id", SqlDbType.Int).Value = order._odeme_tur_id;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = order._aciklama;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());


            }
            catch(Exception ex)
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

        } //Paket servisi açma

        public void OrderServiseClose(int adisyon_id)
        {
           
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update paketSiparisleri set paketSiparisleri.durum=1 where paketSiparisleri.adisyon_id=@adisyon_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = adisyon_id;
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                throw;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }

        } //Paket servisi kapatma

        public int OdemeTurIdGetir(int adisyon_id)
        {
            int odeme_tur_id = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparisleri.odeme_tur_id from paketSiparisleri Inner Join adisyonlar on paketSiparisleri.adisyon_id=adisyonlar.id where adisyonlar.id=@adisyon_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = adisyon_id;
                odeme_tur_id = Convert.ToInt32(cmd.ExecuteNonQuery());


            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                throw;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return odeme_tur_id;

        } // açılan adisyon ve paket sipariş ait ön girilen ödeme tür id

        public int musteriSonAdisyonIdGetir(int musteri_id)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.id from adisyonlar Inner Join paketSiparisleri on paketSiparisleri.adisyon_id=adisyonlar.id where (adisyonlar.durum=0) and (paketSiparisleri.durum=0) and paketSiparisleri.musteri_id=@musteri_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@musteri_id", SqlDbType.Int).Value = musteri_id;
                 no= Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                throw;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }


            return no;
        }

        public bool getCheckOpenAdditionId(int adisyon_id)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from adisyonlar where (durum=0) and (id=adisyon_id)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyon_id", SqlDbType.Int).Value = adisyon_id;
                
                result = Convert.ToBoolean(cmd.ExecuteScalar());


            }
            catch (Exception ex)
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


      
    }
}
