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
    public partial class frmSetting : Form
    {
        public frmSetting()
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

        private void frmSetting_Load(object sender, EventArgs e)
        {
            cPersoneller cp = new cPersoneller();
            cPersonelGorev cpg = new cPersonelGorev();
            string gorev = cpg.PersonelGorevTanim(cGenel._gorev_id);
            if(gorev=="Müdür")
            {
                cp.personelGetbyInformation(cbPersonel);
                cpg.PersonelGorevGetir(cbGörevi);
                cp.PersonelBilgileriniGetirLV(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblBilgi.Text = "Yetkili kullanıcı : Müdür  : " + cp.personelBilgiGetirİsim(cGenel._personel_id);

            }
            else 
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Sınırlı Yetki : Personel : " + cp.personelBilgiGetirİsim(cGenel._personel_id);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtYeniSifre.Text.Trim()!="" ||txtYeniSifreTekrar.Text.Trim()!="" )
            {

                if(txtYeniSifre.Text==txtYeniSifreTekrar.Text)
                {
                    if(txtPersonelId.Text!="")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleşmiştir.!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }

            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız!");
            }

        }

        private void cbGörevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGörevi.SelectedItem;
            txtGorevId2.Text = Convert.ToString(c.personel_gorev_id);

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;

        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller c = (cPersoneller)cbPersonel.SelectedItem;
            txtPersonelId.Text = Convert.ToString(c.Personel_id);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count>0)
            {
                if(MessageBox.Show("Silmek İstediğinize Emin Misiniz!!", "uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    cPersoneller c = new cPersoneller();
                    bool sonuc=c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if(sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Silinmiştir");
                        c.PersonelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Silinirken Bir Hata Oluştu!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Kayıt Seçiniz.");
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text.Trim()!="" & txtSoyad.Text.Trim()!="" & txtSifre.Text.Trim()!="" & txtSifreTekrar.Text.Trim()!="" & txtGorevId2.Text.Trim()!="")
            {
                if((txtSifreTekrar.Text.Trim()==txtSifre.Text.Trim())&&(txtSifre.Text.Length>5 || txtSifreTekrar.Text.Length>5))
                {
                    cPersoneller c = new cPersoneller();
                    c.Personel_ad = txtAd.Text.Trim();
                    c.Personel_soyad = txtSoyad.Text.Trim();
                    c.Personel_parola = txtSifre.Text;
                    c.Personel_gorev_id = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc=c.personelEkle(c);

                    if(sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
                        c.PersonelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (txtAd.Text != "" || txtSoyad.Text != "" || txtSifre.Text != "" || txtSifreTekrar.Text != "" || txtGorevId2.Text != "")
                {
                    if ((txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim()) && (txtSifre.Text.Length > 5 || txtSifreTekrar.Text.Length > 5))
                    {
                        cPersoneller c = new cPersoneller();
                        c.Personel_ad = txtAd.Text.Trim();
                        c.Personel_soyad = txtSoyad.Text.Trim();
                        c.Personel_parola = txtSifre.Text;
                        c.Personel_gorev_id = Convert.ToInt32(txtGorevId2.Text);
                        bool sonuc = c.personelGuncelle(c, Convert.ToInt32(txtPersonelId.Text));

                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
                            c.PersonelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı Değil!");
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız!");
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() != "" || textBox6.Text.Trim() != "")
            {

                if (textBox5.Text == textBox6.Text)
                {
                    if (cGenel._personel_id.ToString() != "")
                    {
                        cPersoneller c = new cPersoneller();
                        bool sonuc = c.personelSifreDegistir(Convert.ToInt32(cGenel._personel_id), textBox5.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleşmiştir.!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil!");
                }

            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız!");
            }

        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                btnSil.Enabled = true;
                txtPersonelId.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGörevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;

            }
            else
            {
                btnSil.Enabled = false;
            }
            
        }
    }
}
