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
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _urun_tur_no;
        private string _kategori_adi;
        private string _aciklama;
        #endregion

        #region Properties
        public int Urun_tur_no { get => _urun_tur_no; set => _urun_tur_no = value; }
        public string Kategori_adi { get => _kategori_adi; set => _kategori_adi = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }
        #endregion

        public void getProductTypes(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select urunad, fiyat, urunler.id From kategoriler Inner Join urunler on kategoriler.id=urunler.kategori_id Where urunler.kategori_id=@kategori_id", conn);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            comm.Parameters.Add("@kategori_id", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["urunad"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["fiyat"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["id"].ToString());
                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();


        }

        public void getProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select * from urunler where id=@id", conn);


            comm.Parameters.Add("@kategori_id", SqlDbType.Int).Value = txt;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
           SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["urunad"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["fiyat"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["id"].ToString());
                i++;

            }
            dr.Close();
            conn.Dispose();
            conn.Close();


        }

        public void urunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where durum=0", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cUrunCesitleri uc = new cUrunCesitleri();
                    uc._urun_tur_no = Convert.ToInt32(dr["id"]);
                    uc._kategori_adi = dr["kategori_adi"].ToString();
                    uc._aciklama = dr["aciklama"].ToString();

                    cb.Items.Add(uc);
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
        }//Ürün Çeşitlerini Getir Combobox

        public void urunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where durum=0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["kategori_adi"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["aciklama"].ToString());

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
        }//Ürün Çeşitlerini Getir Listview

        public void urunCesitleriniGetir(ListView lv, string source)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where durum=0 and kategori_adi like '%' +@source+ '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;

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
                    lv.Items[sayac].SubItems.Add(dr["kategori_adi"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["aciklama"].ToString());

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
        }//Arama

        public int urunKategoriEkle(cUrunCesitleri uc)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into kategoriler(kategori_adi, aciklama) values (@kategori_adi, @aciklama)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@kategori_adi", SqlDbType.VarChar).Value = uc._kategori_adi;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = uc._aciklama;
                
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());



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
        }//Ürün çeşit ekle

        public int urunKategoriGuncelle(cUrunCesitleri uc)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update kategoriler set kategori_adi=@kategori_adi, aciklama=@aciklama where id=@kategori_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@kategori_adi", SqlDbType.VarChar).Value = uc._kategori_adi;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = uc._aciklama;
                cmd.Parameters.Add("@kategori_id", SqlDbType.Int).Value = uc._urun_tur_no;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());



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

        public int urunKategoriSil(int id)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update kategoriler set durum=1 where id=@kategori_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@kategori_id", SqlDbType.Int).Value = id;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());



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

        public override string ToString()
        {
            return Kategori_adi;
        }




    }
}
