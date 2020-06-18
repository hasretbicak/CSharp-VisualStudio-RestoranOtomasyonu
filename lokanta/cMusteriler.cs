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
    class cMusteriler
    {
        cGenel gnl = new cGenel();

        private int _musteri_id;
        private string _musteri_ad;
        private string _musteri_soyad;
        private string _telefon;
        private string _adres;
        private string _email;

        #region Properties
        public int musteri_id { get => _musteri_id; set => _musteri_id = value; }
        public string musteri_ad { get => _musteri_ad; set => _musteri_ad = value; }
        public string musteri_soyad { get => _musteri_soyad; set => _musteri_soyad = value; }
        public string telefon { get => _telefon; set => _telefon = value; }
        public string adres { get => _adres; set => _adres = value; }
        public string email { get => _email; set => _email = value; } 
        #endregion

        public bool MusteriVarmi(string tlf)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarmi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;
            
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                
                con.Close();

            }
            return sonuc;

        }

        public int musteriEkle(cMusteriler m)
        {
            int sonuc = 0;
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into musteriler(ad, soyad, telefon, adres, email) values (@ad, @soyad, @telefon, @adres, @email); select SCOPE_IDENTITY() ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteri_ad;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musteri_soyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
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

        public bool musteriBilgileriGuncelle(cMusteriler m)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update musteriler set ad=@ad, soyad=@soyad, telefon=@telefon, adres=@adres, email=@email where id=@musteri_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteri_ad;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musteri_soyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
                cmd.Parameters.Add("@musteri_id", SqlDbType.VarChar).Value = m._musteri_id;

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

        public void musterileriGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler", con);

            SqlDataReader dr = null;

           
            try
            {
                if (con.State == ConnectionState.Closed)
                { 
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                { 
                    lv.Items.Add(dr["id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["telefon"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adres"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["email"].ToString());
                    sayac++;
                }
                
            }
            catch (SqlException ex)
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

        public void musterileriGetirId(int musteri_id, TextBox ad, TextBox soyad, TextBox tlf, TextBox adres, TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where id=@musteri_id", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteri_id", SqlDbType.Int).Value = musteri_id;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    ad.Text = dr["ad"].ToString();
                    soyad.Text = dr["soyad"].ToString();
                    tlf.Text = dr["telefon"].ToString();
                    adres.Text = dr["adres"].ToString();
                    email.Text = dr["email"].ToString();
                }
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
               
            }
            dr.Close();
            con.Dispose();
            con.Close();

        }

        public void musteriGetirAd(ListView lv, string musteri_ad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where ad like @musteri_ad + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteri_ad", SqlDbType.VarChar).Value = musteri_ad;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["id"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["telefon"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adres"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["email"].ToString());
                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            dr.Close();
            con.Dispose();
            con.Close();


        }

        public void musteriGetirSoyad(ListView lv, string soyad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where soyad like @soyad + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("soyad", SqlDbType.VarChar).Value = soyad;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["id"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["telefon"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adres"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["email"].ToString());
                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            dr.Close();
            con.Dispose();
            con.Close();


        }

        public void musteriGetirTlf(ListView lv, string telefon)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where telefon like @telefon + '%' ", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("telefon", SqlDbType.VarChar).Value = telefon;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["id"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["telefon"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adres"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["email"].ToString());
                    sayac++;

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            dr.Close();
            con.Dispose();
            con.Close();


        }
    }
}
