using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
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

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musterileriGetir(lvMusteriler);
            cMasalar masa = new cMasalar();
            masa.MasaKapasitesiveDurumuGetir(cbMasa);
            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;

        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musteriGetirAd(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler m = new cMusteriler();
            m.musteriGetirAd(lvMusteriler, txtAdres.Text);
        }
        void Temizle()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasaNo.Clear();
            txtTarih.Clear();
            txtAdres.Clear();
        }

        private void btnRezervasyonAc_Click(object sender, EventArgs e)
        {
            cRezervasyon r = new cRezervasyon();
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.rezervasyonAcikmiKontrol(Convert.ToInt32(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)));
                if (!sonuc)
                {
                    if (txtTarih.Text != "")
                    {
                        if (txtKisiSayisi.Text != "")
                        {
                            cMasalar masa = new cMasalar();
                            if(masa.TableGetbyState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.tarih = Convert.ToDateTime(txtTarih.Text);
                                a.servis_tur_no=1;
                                a.masa_id = Convert.ToInt32(txtMasaNo.Text);
                                a.personel_id = cGenel._personel_id;

                                r.musteri_id = Convert.ToInt32(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                                r.masa_id= Convert.ToInt32(txtMasaNo.Text);
                                r.tarih= Convert.ToDateTime(txtTarih.Text);
                                r.kisi_sayisi = Convert.ToInt32(txtKisiSayisi.Text);
                                r.aciklama = txtAciklama.Text;

                                r.adisyon_id = a.rezervasyonAdisyonAc(a);
                                sonuc = r.rezervasyonAc(r);
                                masa.setChangeTableState(txtMasaNo.Text, 3);

                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon Başarıyla Açılmıştır.");
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon Kaydı Gerçekleşememiştir. Lütfen Yetkiliyle İletişime Geçiniz.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Dolu Masaya Rezervasyon Yapamazsınız.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Kişi Sayısı Seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Bir Tarih Seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Müşteriye Açılmış Bir Rezervasyon Bulunmaktadır.");
                }   
            }
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Width = 23;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            cMasalar kapasitesi =(cMasalar)cbMasa.SelectedItem;
            int kapasite = kapasitesi.kapasite;
            txtMasaNo.Text = Convert.ToString(kapasitesi.id);

            cbKisiSayisi.Items.Clear();
            for(int i=0; i<kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            cbMasa.Width = 220;
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            cbMasa.Width = 23;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 23;
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 100;
        }

        private void btnRezervasyonlar_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol frm = new frmSiparisKontrol();
            this.Close();
            frm.Show();

        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriEkleme frm = new MusteriEkleme();
            cGenel._musteriEkleme = 0;
            this.Close();
            frm.Show();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.Items.Count > 0)
            {
                MusteriEkleme me = new MusteriEkleme();
                cGenel._musteriEkleme = 0;
                cGenel._musteri_id= Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                this.Close(); 
                me.Show();
            }
        }

        private void lvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
