using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmMusteriAra : Form
    {
        public frmMusteriAra()
        {
            InitializeComponent();
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


        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musterileriGetir(lvMusterilers);

        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
           
        }



        private void btnYeniMusteri_Click_1(object sender, EventArgs e)
        {
            MusteriEkleme m = new MusteriEkleme();
            cGenel._musteriEkleme = 1;
            m.Show();
        }

        private void btnMusteriGuncelle_Click_1(object sender, EventArgs e)
        {
            if (lvMusterilers.SelectedItems.Count > 0)
            {
                MusteriEkleme frm = new MusteriEkleme();
                cGenel._musteriEkleme = 1;
                cGenel._musteri_id = Convert.ToInt32(lvMusterilers.SelectedItems[0].SubItems[0].Text);

                this.Close();
                frm.Show();
            }
        }

        private void btnMusteriSec_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSiparisler_Click_1(object sender, EventArgs e)
        {
            cGenel._servis_tur_no = 1;

            frmSiparisKontrol frm = new frmSiparisKontrol();
            this.Close();
            frm.Show();

        }

        private void txtAd_TextChanged_1(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirAd(lvMusterilers, txtAd.Text);
        }

        private void txtSoyad_TextChanged_1(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirSoyad(lvMusterilers, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged_1(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirTlf(lvMusterilers, txtTelefon.Text);
        }

        private void txtAdisyonId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAdisyonBul_Click_1(object sender, EventArgs e)
        {
            if (txtAdisyonId.Text != "")
            {
                cGenel._adisyon_id = txtAdisyonId.Text;
                cPaketler c = new cPaketler();
                bool sonuc = c.getCheckOpenAdditionId(Convert.ToInt32(txtAdisyonId.Text));
                if (sonuc)
                {
                    frmBill frm = new frmBill();
                    cGenel._servis_tur_no = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonId.Text + "Diye Bir Adisyon Bulunamadı..");
                }
            }
            else
            {
                MessageBox.Show("Aramak İstediğiniz Adisyonu Yazınız!");
            }
        }
    }
}
