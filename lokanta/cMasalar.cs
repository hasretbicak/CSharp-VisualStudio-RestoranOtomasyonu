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
    class cMasalar
    {
        #region Fields
        private int _id;
        private int _kapasite;
        private int _servis_turu;
        private int _durum;
        private int _onay;
        private string _masa_bilgi;
        #endregion

        #region Properties
        public int id
        {
            get => _id;
            set => _id = value;
        }
        public int kapasite
        {
            get => _kapasite;
            set => _kapasite = value;
        }
        public int servis_turu
        {
            get => _servis_turu;
            set => _servis_turu = value;
        }
        public int durum
        {
            get => _durum;
            set => _durum = value;
        }
        public int onay
        {
            get => _onay;
            set => _onay = value;
        }
        public object masa_id { get; set; }
        public string masa_bilgi { get => _masa_bilgi; set => _masa_bilgi = value; }
        #endregion

        cGenel gnl = new cGenel();


        public string SessionSum(int durum, string masa_id)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select tarih, masa_id From adisyonlar Right Join masalar on adisyonlar.masa_id=masalar.id Where masalar.durum=@durum AND adisyonlar.durum=0 and masalar.id=@masa_id", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
            cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = Convert.ToInt32(masa_id);

            try
            {
                if (con.State == ConnectionState.Closed) 
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["tarih"]).ToString();
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
            return dt;

        }

        public int TableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;

            if (length > 8)
            {
                return Convert.ToInt32(aa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(length - 1, 1));
            }

            return Convert.ToInt32(aa.Substring(length - 1, 1));
        }

        public bool TableGetbyState(int ButtonName, int durum)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select durum From masalar Where id=@masa_id and durum=@durum", con);
           
            cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value=ButtonName;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value=durum;
            try
            { 
               if(con.State==ConnectionState.Closed)
               {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;



        }

        public void setChangeTableState(string ButonName, int durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masalar Set durum=@durum Where id=@masa_id", con);

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            string aa = ButonName;
            int uzunluk = aa.Length;

            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
            if(uzunluk>8)
            {
                masa_id=aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masa_id = aa.Substring(uzunluk - 1, 1);
            }

            cmd.Parameters.Add("@masa_id", SqlDbType.Int).Value = masa_id;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();


        }

        public void MasaKapasitesiveDurumuGetir(ComboBox cm)
        {
            cm.Items.Clear();
            string durum = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from masalar ", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cMasalar c = new cMasalar();
                if (c._durum == 2)
                    durum = "DOLU";
                else if (c._durum == 3)
                    durum = "REZERVE";
                c._kapasite = Convert.ToInt32(dr["kapasite"]);
                c._masa_bilgi = "Masa:" + dr["id"].ToString() + "Kapasitesi:" + dr["kapasite"].ToString();
                c._id = Convert.ToInt32(dr["id"]);
                cm.Items.Add(c);
            }
            dr.Close();
            con.Dispose();
            con.Close();

        }

        public override string ToString()
        {
            return masa_bilgi;
        }
    }
}
