using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace lokanta
{
    class cOdeme
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _odeme_id;
        private int _adisyon_id;
        private int _odeme_tur_id;
        private decimal _aratoplam;
        private decimal _indirim;
        private decimal _kdv_tutari;
        private decimal _genel_tutar;
        private DateTime _tarih;
        private int _musteri_id;
        #endregion

        #region Properties
        public int odeme_id { get => _odeme_id; set => _odeme_id = value; }
        public int adisyon_id { get => _adisyon_id; set => _adisyon_id = value; }
        public int odeme_tur_id { get => _odeme_tur_id; set => _odeme_tur_id = value; }
        public decimal aratoplam { get => _aratoplam; set => _aratoplam = value; }
        public decimal indirim { get => _indirim; set => _indirim = value; }
        public decimal kdv_tutari { get => _kdv_tutari; set => _kdv_tutari = value; }
        public decimal genel_tutar { get => _genel_tutar; set => _genel_tutar = value; }
        public DateTime tarih { get => _tarih; set => _tarih = value; }
        public int musteri_id { get => _musteri_id; set => _musteri_id = value; }
        #endregion

        
        public bool billClose(cOdeme bill)
        {
            cGenel gnl = new cGenel();

            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into hesapOdemeleri (adisyon_id, odeme_tur_id, musteri_id, aratoplam, kdv_tutari, toplam_tutar, indirim) values (@adisyon_id, @odeme_tur_id, @musteri_id, @aratoplam, @kdv_tutari, @toplam_tutar, @indirim)", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyon_id", SqlDbType.Int).Value = bill._adisyon_id;
                cmd.Parameters.Add("odeme_tur_id", SqlDbType.Int).Value = bill._odeme_tur_id;
                cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = bill._musteri_id;
                cmd.Parameters.Add("aratoplam", SqlDbType.Money).Value = bill._aratoplam;
                cmd.Parameters.Add("kdv_tutari", SqlDbType.Money).Value = bill._kdv_tutari;
                cmd.Parameters.Add("indirim", SqlDbType.Money).Value = bill._indirim;
                cmd.Parameters.Add("toplam_tutar", SqlDbType.Money).Value = bill._genel_tutar;
                

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
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

        } //Müşteri hesabı kapatıyoruz.Masa

        public decimal sumTotalForClientId(int musteri_id)
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(toplam_tutar) as total from hesapOdemeleri where musteri_id=@musteri_id", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;
                total = Convert.ToDecimal(cmd.ExecuteScalar());

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

           

            return total;
        } //Müşterinin toplam harcamasını yazıyoruz.

    }
}
