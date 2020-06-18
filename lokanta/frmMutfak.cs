using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lokanta
{
    public partial class frmMutfak : Form
    {
        public frmMutfak()
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

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            cUrunCesitleri AnaKategori = new cUrunCesitleri();
            AnaKategori.urunCesitleriniGetir(cbKategoriler);
            cUrunCesitleri uc = (cUrunCesitleri)cbKategoriler.SelectedItem;
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label6.Visible = false;
            txtUrunAra.Visible = false;

            cUrunler c = new cUrunler();
            c.urunleriListele(lvGidaListesi);
        }
        private void Temizle()
        {
            txtGidaAdi.Clear();
            txtGidaFiyati.Clear();
            txtGidaFiyati.Text = string.Format("{0:##0.00}", 0);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı Ve Kategori Seçilmemiştir.", "Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.urunad = txtGidaAdi.Text;
                    c.aciklama = "Ürün Eklendi";
                    c.urun_tur_no = urun_tur_no;
                    int sonuc=c.urunEkle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir.");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Bir Kategori İsmi Giriniz.", "Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.Kategori_adi = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    int sonuc=gida.urunKategoriEkle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir.");
                        yenile();
                        Temizle();

                    }
                }
            }
        }
        int urun_tur_no = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler u = new cUrunler();
            if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
            {
                u.urunleriListele(lvGidaListesi);
            }
            else
            {
                cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedItem;
                urun_tur_no = cesit.Urun_tur_no;
                u.urunleriListeleUrunID(lvGidaListesi, urun_tur_no);
            }
        }

        private void button1_Click(object sender, EventArgs e)//değiştir butonu
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" & txtGidaFiyati.Text.Trim() == "" & cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı Fiyatı Ve Kategori Seçilmemiştir.", "Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.urunad = txtGidaAdi.Text;
                    c.urun_id = Convert.ToInt32(txtUrunId.Text);
                    c.urun_tur_no = urun_tur_no;
                    c.aciklama = "Ürün Güncellendi";
                    int sonuc = c.urunGuncelle(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellendi.");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen Bir Kategori Seçiniz.", "Bilgiler Eksik!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunCesitleri gida = new cUrunCesitleri();
                    gida.Kategori_adi = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    gida.Urun_tur_no=Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = gida.urunKategoriGuncelle(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir.");
                        yenile();
                        Temizle();

                    }
                }
            }

        }

        private void lvGidaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.SelectedItems.Count > 0)
            {
                txtGidaAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                txtGidaFiyati.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)//sil butonu
        {
            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürünü Silmek İstediğinizden Emin Misiniz?", "Dikkat! Bilgiler Silinecek!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunler c = new cUrunler();
                        c.urun_id = Convert.ToInt32(txtUrunId.Text);
                        int sonuc = c.urunSil(c, 1);
                        if (sonuc == 0)
                        {
                            MessageBox.Show("Ürün Silindi.");
                            yenile();
                            Temizle();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ürünü Silmek İçin Bir Seçim Yapınız!", "Dikkat! Ürün Seçilmedi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {


                    if (MessageBox.Show("Ürünü Silmek İstediğinizden Emin Misiniz?", "Dikkat! Bilgiler Silinecek!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cUrunCesitleri uc = new cUrunCesitleri();
                        int sonuc = uc.urunKategoriSil(Convert.ToInt32(txtKategoriId.Text));
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silindi.");
                            cUrunler c = new cUrunler();
                            c.urun_id = Convert.ToInt32(txtKategoriId.Text);
                            c.urunSil(c, 0);
                            yenile();
                            Temizle();
                        }
                    }
                }
            
            }
        }

        private void button2_Click(object sender, EventArgs e)// bul butonu
        {
            label6.Visible = true;
            txtUrunAra.Visible = true;

        }

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if(rbAltKategori.Checked)
            {
                cUrunler u = new cUrunler();
                u.urunleriListeleUrunAdi(lvGidaListesi, txtUrunAra.Text);
            }
            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtUrunAra.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            yenile();
           
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            yenile();
            

        }
        private void yenile()
        {
            cUrunCesitleri uc = new cUrunCesitleri();
            uc.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.urunCesitleriniGetir(lvKategoriler);
            cUrunler c = new cUrunler();
            c.urunleriListele(lvGidaListesi);
        }
    }
}
