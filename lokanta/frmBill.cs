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
    public partial class frmBill : Form
    {
        public frmBill()
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
        
        int odeme_turu= 0;
        private void frmBill_Load(object sender, EventArgs e)
        {
            gbIndirim.Visible = false;

            if (cGenel._servis_tur_no==1)
            {
                cSiparis cs = new cSiparis();

                lblAdisyonId.Text = cGenel._adisyon_id;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if(lvUrunler.Items.Count>0)
                {
                    decimal toplam = 0;
                    for(int i=0; i<lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[2].Text);
                    }

                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);

                }
                if (chkIndirim.Checked)
                    gbIndirim.Visible = false;
                else
                    gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else if(cGenel._servis_tur_no==2)
            {
                cSiparis cs = new cSiparis();

                lblAdisyonId.Text = cGenel._adisyon_id;
                cPaketler pc = new cPaketler();
                odeme_turu=pc.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (odeme_turu==1)
                {
                    rbNakit.Checked = true;
                }
                else if(odeme_turu==2)
                {
                    rbKrediKarti.Checked = true;
                }
                else
                {
                    rbTicket.Checked = true;
                }




                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.000}", kdv);

                }
                if (chkIndirim.Checked)
                    gbIndirim.Visible = false;
                else
                    gbIndirim.Visible = true;
                txtIndirimTutari.Clear();



            }
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", Convert.ToDecimal(txtIndirimTutari.Text));

                    }
                    catch (Exception)
                    {
                        lblIndirim.Text = string.Format("{0:0.000}", 0);
                    }

                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz !!!");
                }

            }
            catch (Exception)
            {
                lblIndirim.Text = string.Format("{0:0.000}", 0);
                
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtIndirimTutari.Clear();

            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(lblIndirim.Text)>0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);
            }
            decimal kdv = Convert.ToDecimal(lblOdenecek.Text)*18/100;
            lblKdv.Text = string.Format("{0:0.000}", kdv);

        }


        cMasalar masalar = new cMasalar();
        cRezervasyon rezerve = new cRezervasyon();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            if(cGenel._servis_tur_no==1) // MASADA SİPARİŞ
            {
                int masa_id = masalar.TableGetbyNumber(cGenel._ButtonName);
                int musteri_id = 0;

                if(masalar.TableGetbyState(masa_id, 4)==true)
                {
                    musteri_id = rezerve.getByClientFromRezervasyon(masa_id);


                }
                else
                {
                    musteri_id = 1;

                }
                int odeme_tur_id = 0;
                if(rbNakit.Checked)
                {
                    odeme_tur_id = 1;
                }
                if(rbKrediKarti.Checked)
                {
                    odeme_tur_id = 2;
                }
                if(rbTicket.Checked)
                {
                    odeme_tur_id = 3;
                }

                cOdeme odeme = new cOdeme();

                odeme.adisyon_id=Convert.ToInt32(lblAdisyonId.Text);
                odeme.odeme_tur_id = odeme_tur_id;
                odeme.musteri_id = musteri_id;
                odeme.aratoplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.kdv_tutari = Convert.ToDecimal(lblKdv.Text);
                odeme.genel_tutar = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);

                if(result)
                {
                    MessageBox.Show("Hesap Kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(masa_id), 1);

                    cRezervasyon c = new cRezervasyon();
                    c.rezervatinClose(Convert.ToInt32(lblAdisyonId.Text));

                    cAdisyon a = new cAdisyon();
                    a.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu.");
                }

            }
            else if(cGenel._servis_tur_no ==2) //PAKET SİPARİŞİ
            {
                int odeme_turu = 0;
                if (rbNakit.Checked)
                {
                    odeme_turu = 1;
                }
                if (rbKrediKarti.Checked)
                {
                    odeme_turu = 2;
                }
                if (rbTicket.Checked)
                {
                    odeme_turu = 3;
                }
                cOdeme odeme = new cOdeme();

                odeme.adisyon_id = Convert.ToInt32(lblAdisyonId.Text);
                odeme.odeme_tur_id = odeme_turu;
                odeme.musteri_id = 1; // paket siparişi ID sini getirmelisin
                odeme.aratoplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.kdv_tutari = Convert.ToDecimal(lblKdv.Text);
                odeme.genel_tutar = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);

                if (result)
                {
                    MessageBox.Show("Hesap Kapatılmıştır.");

                    cAdisyon a = new cAdisyon();
                    a.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 0); 

                    cPaketler P = new cPaketler();
                    P.OrderServiseClose(Convert.ToInt32(lblAdisyonId.Text));
                    

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu.");
                }

            }




        }

        private void lblAdisyonId_Click(object sender, EventArgs e)
        {

        }

        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Hasret Lokantası", Baslik, sb, 350, 100, st);

            e.Graphics.DrawString("_____________________________________________", Baslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı            Adet            Fiyat", Baslik, sb, 150, 250, st);
            e.Graphics.DrawString("__________________________________________________________", Baslik, sb, 150, 280, st);
            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 350 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 350 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[2].Text, icerik, sb, 480, 350 + i * 30, st);

            }
            e.Graphics.DrawString("_____________________________________________________________________________", altBaslik, sb, 150, 350+30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı : ..............."+lblIndirim.Text + "TL", altBaslik, sb, 250, 350+30 * (lvUrunler.Items.Count+1),  st);
            e.Graphics.DrawString("KDV Tutarı : ..................." + lblKdv.Text + "TL", altBaslik, sb, 250, 350 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar : ................." + lblToplamTutar.Text + "TL", altBaslik, sb, 250, 350 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar : ............." + lblOdenecek.Text + "TL", altBaslik, sb, 250, 350 + 30 * (lvUrunler.Items.Count + 4), st);





        }

        private void lvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
