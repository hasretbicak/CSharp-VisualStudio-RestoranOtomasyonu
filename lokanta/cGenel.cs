using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokanta
{
    class cGenel
    {
        public string conString=("Server=LAPTOP-EPAJK836\\SQLEXPRESS; Database=sureyya;Trusted_Connection=True");
        public static int _personel_id;
        public static int _gorev_id;
        public static int _musteriEkleme;
        public static int _musteri_id;

        public static string _ButtonValue;
        public static string _ButtonName;

        public static int _servis_tur_no;
        public static string _adisyon_id;
    }
}
