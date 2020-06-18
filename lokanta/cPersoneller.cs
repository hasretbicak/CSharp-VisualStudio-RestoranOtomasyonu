using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace lokanta
{
    class cPersoneller
    {
        cGenel gnl = new cGenel();
        #region field
        private int _personel_id;
        private int _personel_gorev_id;
        private string _personel_ad;
        private string _personel_soyad;
        private string _personel_parola;
        private string _personel_kullanici_adi;
        private bool _personel_durum;
        #endregion

        #region Properties
        public int Personel_id
        {
            get => _personel_id;
            set => _personel_id = value;
        }
        public int Personel_gorev_id
        {
            get => _personel_gorev_id;
            set => _personel_gorev_id = value;
        }
        public string Personel_ad
        {
            get => _personel_ad;
            set => _personel_ad = value;
        }
        public string Personel_soyad
        {
            get => _personel_soyad;
            set => _personel_soyad = value;
        }
        public string Personel_parola
        {
            get => _personel_parola;
            set => _personel_parola = value;
        }
        public string Personel_kullanici_adi
        {
            get => _personel_kullanici_adi;
            set => _personel_kullanici_adi = value;
        }
        public bool Personel_durum
        {
            get => _personel_durum;
            set => _personel_durum = value;
        } 
        #endregion

        public bool personelEntryControl(string password, int UserId)
        
        {
            bool result = false; 
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from personeller where id=@Id and parola=@password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password; 

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
                throw;
            }

            return result;
        }
        public void personelGetbyInformation(ComboBox cb)
        {
            cGenel gnl = new cGenel();
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from personeller", con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._personel_id = Convert.ToInt32(dr["id"]);
                p._personel_gorev_id = Convert.ToInt32(dr["gorev_id"]);
                p._personel_ad = Convert.ToString(dr["ad"]);
                p._personel_soyad = Convert.ToString(dr["soyad"]);
                p._personel_parola= Convert.ToString(dr["parola"]);
                p._personel_kullanici_adi = Convert.ToString(dr["kullanici_adi"]);
                p._personel_durum= Convert.ToBoolean(dr["durum"]);
                cb.Items.Add(p);

            }
            dr.Close();
            con.Close(); 
                


        }
        public override string ToString()
        {
            return Personel_ad;

        }

        public void PersonelBilgileriniGetirLV(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select personeller.*, personelGorevleri.gorev from personeller Inner Join personelGorevleri on personelGorevleri.id=personeller.gorev_id where personeller.durum=0", con);
                                             
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["id"].ToString());
                lv.Items[i].SubItems.Add(dr["gorev_id"].ToString());
                lv.Items[i].SubItems.Add(dr["gorev"].ToString());
                lv.Items[i].SubItems.Add(dr["ad"].ToString());
                lv.Items[i].SubItems.Add(dr["soyad"].ToString());
                lv.Items[i].SubItems.Add(dr["kullanici_adi"].ToString());
                i++;
            }
            dr.Close();
            con.Close();




        }

        public void PersonelBilgileriniGetirFromIDLV(ListView lv, int per_id)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select personeller.*, personelGorevleri.gorev from personeller Inner Join personelGorevleri on personelGorevleri.id=personeller.gorev_id where personeller.durum=0 and personeller.id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = per_id;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["id"].ToString());
                lv.Items[i].SubItems.Add(dr["gorev_id"].ToString());
                lv.Items[i].SubItems.Add(dr["gorev"].ToString());
                lv.Items[i].SubItems.Add(dr["ad"].ToString());
                lv.Items[i].SubItems.Add(dr["soyad"].ToString());
                lv.Items[i].SubItems.Add(dr["kullanici_adi"].ToString());
                i++;
            }
            dr.Close();
            con.Close();

        }

        public string personelBilgiGetirİsim(int per_id)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select ad from personeller where personeller.durum=0 and personeller.id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = per_id;


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();
            return sonuc;

        }

        public bool personelSifreDegistir(int personel_id, string pass)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update personeller set parola=@pass where id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = personel_id;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();




            return sonuc;
        }

        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into personeller(ad, soyad, parola, gorev_id) values (@ad, @soyad, @parola, @gorev_id)", con);
            cmd.Parameters.Add("ad", SqlDbType.VarChar).Value = _personel_ad;
            cmd.Parameters.Add("soyad", SqlDbType.VarChar).Value = _personel_soyad;
            cmd.Parameters.Add("parola", SqlDbType.VarChar).Value = _personel_parola;
            cmd.Parameters.Add("gorev_id", SqlDbType.Int).Value =_personel_gorev_id;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();




            return sonuc;
        }

        public bool personelGuncelle(cPersoneller cp, int per_id)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update personeller set ad=@ad, soyad=@soyad, parola=@parola, gorev_id=@gorev_id where id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = per_id;
            cmd.Parameters.Add("ad", SqlDbType.VarChar).Value = _personel_ad;
            cmd.Parameters.Add("soyad", SqlDbType.VarChar).Value = _personel_soyad;
            cmd.Parameters.Add("parola", SqlDbType.Int).Value = _personel_parola;
            cmd.Parameters.Add("gorev_id", SqlDbType.Int).Value = _personel_gorev_id;
           


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();

            return sonuc;
        }

        public bool personelSil(int per_id)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update personeller set durum=1 where id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = per_id;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();

            return sonuc;
        }

    }
}
