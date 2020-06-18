using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            int butonSayisi = c.paketAdisyonIdBulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 50;
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));

            for(int i=1; i<=butonSayisi; i++)
            {
                Button btn = new Button();
                btn.AutoSize = false;
                btn.Size = new Size(179, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text= lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;

                if(i==2)
                {
                    sol = 1;
                    alt += 50;
                   
                }
                btn.Click += new EventHandler(dinamikMetod);
                btn.MouseEnter += new EventHandler(dinamikMetod2);

            }
        }
        protected void dinamikMetod(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            Button dinamikButton = (sender as Button);
            frmBill frm = new frmBill();
            cGenel._servis_tur_no = 2;
            cGenel._adisyon_id = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButton.Name)));
            frm.Show();
        }
        protected void dinamikMetod2(object sender, EventArgs e)
        {
            Button dinamikButton = (sender as Button);
            cAdisyon c = new cAdisyon();
            c.musteriDetaylar(lvMusteriDetaylari, Convert.ToInt32(dinamikButton.Name));
            sonSiparisTarihi();
            lvSatisdetaylari.Items.Clear();
            cSiparis s = new cSiparis();
            cGenel._servis_tur_no = 2;
            cGenel._adisyon_id = Convert.ToString(c.musterininsonadisyonId(Convert.ToInt32(dinamikButton.Name)));
            lblGenelToplam.Text = s.GenelToplamBul(Convert.ToInt32(dinamikButton.Name)).ToString() + "TL";

        }
        void sonSiparisTarihi()
        {
            if(lvMusteriDetaylari.Items.Count>0)
            {
                int s = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + "Adet";
            }
        }
        void toplam()
        {
            int kayitSayisi = lvSatisdetaylari.Items.Count;
            decimal toplam = 0;
            for(int i=0; i<kayitSayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisdetaylari.Items[i].SubItems[2].Text)*Convert.ToDecimal(lvSatisdetaylari.Items[i].SubItems[3].Text);
            }
            lblToplamSiparis.Text = toplam.ToString() + "TL";
        }

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvMusteriDetaylari.SelectedItems.Count>0)
            {
                cSiparis c = new cSiparis();
                c.adisyonpaketsiparisDetaylari(lvSatisdetaylari, Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
            }
        }

        private void lvSatisdetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
