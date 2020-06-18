using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Permissions;

namespace lokanta
{
    class cUrunler
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _urun_id;
        private int _urun_tur_no;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama; 
        #endregion

        #region Property
        public int urun_id { get => _urun_id; set => _urun_id = value; }
        public int urun_tur_no { get => _urun_tur_no; set => _urun_tur_no = value; }
        public string urunad { get => _urunad; set => _urunad = value; }
        public decimal fiyat { get => _fiyat; set => _fiyat = value; }
        public string aciklama { get => _aciklama; set => _aciklama = value; } 
        #endregion

        public void urunleriListeleUrunAdi(ListView lv, string urunad)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from urunler where durum=0 and urunad like '%'+@urunad+'%'", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = urunad;

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
                    lv.Items[sayac].SubItems.Add(dr["kategori_id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["urunad"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["aciklama"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["fiyat"]).ToString());

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
        }//Ürün adına göre listele

        public int urunEkle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into urunler(urunad, kategori_id, aciklama, fiyat) values (@urunad, @kategori_id, @aciklama, @fiyat)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@kategori_id", SqlDbType.Int).Value = u.urun_tur_no;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
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
        }// ürün ekle

        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*, kategori_adi from urunler Inner Join kategoriler on kategoriler.id=urunler.kategori_id where urunler.durum=0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["kategori_id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["kategori_adi"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["urunad"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["fiyat"])));
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
        }//Ürünler ve kategori listele

        public int urunGuncelle(cUrunler u)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update urunler set urunad=@urunad, kategori_id=@kategori_id, aciklama=@aciklama, fiyat=@fiyat where id=@urun_id", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@kategori_id", SqlDbType.Int).Value = u._urun_tur_no;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urun_id", SqlDbType.Int).Value = u._urun_id;

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
        }//UrunleriGuncelle

        public int urunSil(cUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);

            string sql = "Update urunler set durum=1 where";
            if (kat == 0)
            {
                sql += "kategori_id=@urun_id";
            }
            else
            {
                sql += "id=@urun_id";
            }
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urun_id", SqlDbType.Int).Value = u._urun_id;

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
        }//Uurunleri Sil

        public void urunleriListeleUrunID(ListView lv, int urun_id)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*, kategori_adi from urunler Inner Join kategoriler on kategoriler.id=urunler.kategori_id  where urunler.durum=0 and urunler.kategori_id=@urun_id", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("@urun_id", SqlDbType.Int).Value = urun_id;

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
                    lv.Items[sayac].SubItems.Add(dr["kategori_id"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["kategori_adi"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["urunad"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["fiyat"]).ToString());

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
        }//Ürünleri ID ye göre Listele

        public void urunleriListeleIstatistik(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {

            {
                lv.Items.Clear();

                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select top 10 dbo.urunler.urunad, sum(dbo.satislar.adet) as adeti from dbo.kategoriler Inner Join dbo.urunler on dbo.kategoriler.id=dbo.urunler.kategori_id Inner Join dbo.satislar on dbo.urunler.id=dbo.satislar.urun_id Inner Join dbo.adisyonlar on dbo.satislar.adisyon_id=dbo.adisyonlar.id where (CONVERT(datetime, tarih, 104) between CONVERT(datetime, @Baslangic, 104) and CONVERT(datetime, @Bitis, 104)) group by dbo.urunler.urunad order by adeti desc", con);

                SqlDataReader dr = null;
                cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
                cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();

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
                        lv.Items.Add(dr["urunad"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());

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
        }//2 Tarih arası bütün ürünleri getir

        public void urunleriListeleIstatistikUrunID(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urun_kat_id)
        {

            
                lv.Items.Clear();

                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select top 10 dbo.urunler.urunad, sum(dbo.satislar.adet) as adeti from dbo.kategoriler Inner Join dbo.urunler on dbo.kategoriler.id=dbo.urunler.kategori_id Inner Join dbo.satislar on dbo.urunler.id=dbo.satislar.urun_id Inner Join dbo.adisyonlar on dbo.satislar.adisyon_id=dbo.adisyonlar.id where (CONVERT(datetime, tarih, 104) between CONVERT(datetime, @Baslangic, 104) and CONVERT(datetime, @Bitis, 104)) and (dbo.urunler.kategori_id=@kategori_id) group by dbo.urunler.urunad order by adeti desc", con);

                SqlDataReader dr = null;
                cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
                cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
                cmd.Parameters.Add("@kategori_id", SqlDbType.Int).Value = urun_kat_id;

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
                        lv.Items.Add(dr["urunad"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());

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
            
        }//Belli Kategoriye ait Ürünleri Getir

    }
}
