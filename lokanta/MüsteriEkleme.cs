using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class MusteriEkleme : Form
    {
        internal object btnYeniMusteri;

        public MusteriEkleme()
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtTelefon.Text.Length>6)
            {
                if(txtMusteriAd.Text=="" || txtMusteriSoyad.Text=="")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad Alanlarını Giriniz.");

                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    bool sonuc = c.MusteriVarmi(txtTelefon.Text);
                    if(!sonuc)
                    {
                        c.musteri_ad = txtMusteriAd.Text;
                        c.musteri_soyad = txtMusteriSoyad.Text;
                        c.telefon = txtTelefon.Text;
                        c.adres = txtMusteriAdres.Text;
                        c.email = txtEmail.Text;
                        txtMusteriNo.Text=c.musteriEkle(c).ToString();

                        if(txtMusteriNo.Text!="")
                        {
                            MessageBox.Show("Müşteri Eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi!!!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu İsimde Bir Kayıt Bulunmaktadır..");
                    }

                }
            }
            else
            {
                MessageBox.Show("Lütfen En Az 7 Haneli Bir Telefon Numarası Giriniz.");
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (cGenel._musteriEkleme == 0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                cGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if (cGenel._musteriEkleme == 1)
            {
                frmPaketSiparis frm = new frmPaketSiparis();
                cGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad Alanlarını Giriniz.");

                }
                else
                {
                    cMusteriler c = new cMusteriler();

                    c.musteri_ad = txtMusteriAd.Text;
                    c.musteri_soyad = txtMusteriSoyad.Text;
                    c.telefon = txtTelefon.Text;
                    c.adres = txtMusteriAdres.Text;
                    c.email = txtEmail.Text;
                    c.musteri_id = Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc = c.musteriBilgileriGuncelle(c);
                    

                    if (sonuc)
                    {
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Güncellenemedi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu İsimde Biir Kayıt Bulunmaktadır..");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen En Az 7 Haneli Bir Telefon Numarası Giriniz.");
            }

        }

        private void MusteriEkleme_Load(object sender, EventArgs e)
        {
            if (cGenel._musteri_id>0)
            {
                cMusteriler c = new cMusteriler();
                txtMusteriNo.Text = cGenel._musteri_id.ToString();
                c.musterileriGetirId(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAd, txtMusteriSoyad, txtTelefon,  txtMusteriAdres, txtEmail);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
