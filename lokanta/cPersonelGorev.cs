using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace lokanta
{
    class cPersonelGorev
    {
        cGenel gnl = new cGenel();
        private int _personel_gorev_id;
        private string _tanim;

        public int personel_gorev_id { get => _personel_gorev_id; set => _personel_gorev_id = value; }
        public string tanim { get => _tanim; set => _tanim = value; }

        public void PersonelGorevGetir(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from personelGorevleri", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    cPersonelGorev c = new cPersonelGorev();
                    c._personel_gorev_id = Convert.ToInt32(dr["id"].ToString());
                    c._tanim = dr["gorev"].ToString();
                    cb.Items.Add(c);
                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            dr.Close();
            con.Close();
            
        }

        public string PersonelGorevTanim(int per)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select gorev from personelGorevleri where id=@per_id", con);
            cmd.Parameters.Add("per_id", SqlDbType.Int).Value = per;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
                
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            
            con.Close();
            return sonuc;

        }

        public override string ToString()
        {
            return _tanim;
        }


    }
}
