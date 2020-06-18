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
    class UrunCesitleri
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

            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while(dr.Read())
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

    }
}
