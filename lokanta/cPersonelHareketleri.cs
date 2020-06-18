using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace lokanta
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _id;
        private int _personel_id;
        private string _islem;
        private DateTime _tarih;
        private bool _durum;
        #endregion

        #region Properties
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public int Personel_id
        {
            get => _personel_id;
            set => _personel_id = value;
        }
        public string Islem
        {
            get => _islem;
            set => _islem = value;
        }
        public DateTime Tarih
        {
            get => _tarih;
            set => _tarih = value;
        }
        public bool Durum
        {
            get => _durum;
            set => _durum = value;
        } 
        #endregion

        public bool PersonelActionSave(cPersonelHareketleri ph)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into personelHareketleri(personel_id, islem, tarih)Values(@personel_id,@islem,@tarih)", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@personel_id", SqlDbType.Int).Value = ph._personel_id;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph._islem;
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph._tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }

    }
}
