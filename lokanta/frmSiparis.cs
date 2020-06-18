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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }
        //Hesap Makinesi
        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text +=(1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text +=(2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text +=(3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text +=(4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text +=(5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text +=(6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text +=(7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text +=(8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text +=(9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text +=(0).ToString();
                    break;

                default:

                    MessageBox.Show("Sayi Gir : ");
                    break;


            }
        }
        int masa_id =0; int adisyon_id = 0;
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            cSiparis cs = new cSiparis();lblMasaNo.Text = cGenel._ButtonValue;

            cMasalar ms = new cMasalar();
            masa_id = ms.TableGetbyNumber(cGenel._ButtonName);
            if(ms.TableGetbyState(masa_id, 2)==true || ms.TableGetbyState(masa_id, 4) == true)
            {
                cAdisyon Ad = new cAdisyon();
                adisyon_id = Ad.getByAddition(masa_id);
                cSiparis orders = new cSiparis();
                orders.getByOrder(lvSiparisler, adisyon_id);

            }

           btn1.Click += new EventHandler(islem);
           btn2.Click += new EventHandler(islem);
           btn3.Click += new EventHandler(islem);
           btn4.Click += new EventHandler(islem);
           btn5.Click += new EventHandler(islem);
           btn6.Click += new EventHandler(islem);
           btn7.Click += new EventHandler(islem);
           btn8.Click += new EventHandler(islem);
           btn9.Click += new EventHandler(islem);
           btn0.Click += new EventHandler(islem);
        }

        cUrunCesitleri uc = new cUrunCesitleri();

        private void btnAnaYemek3_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnAnaYemek3);

        }

        private void btnIcecekler8_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnIcecekler8);
        }

        private void btnTatlilar7_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnTatlilar7);
        }

        private void btnSalata6_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnSalata6);
        }

        private void btnFastfood5_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnFastfood5);
        }

        private void btnCorba1_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnCorba1);
        }

        private void btnAraSicak2_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnAraSicak2);
        }

        private void btnMakarna4_Click(object sender, EventArgs e)
        {
            uc.getProductTypes(lvMenu, btnMakarna4);
        }

        int sayac; int sayac2;
     
       

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if(txtAdet.Text=="")
            {
                txtAdet.Text = "1";
            }

            if(lvMenu.Items.Count>0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());


                lvYeniEklenenler.Items.Add(adisyon_id.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(masa_id.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;

                txtAdet.Text = "";

            }

        }
        ArrayList silinler = new ArrayList();
        private void btnSiparis_Click(object sender, EventArgs e)
        {

            cMasalar masa = new cMasalar();
            frmMasalar ms = new frmMasalar();
            cAdisyon newAddition = new cAdisyon();
            
            cSiparis saveOrder = new cSiparis();
            bool sonuc = false;

            if(masa.TableGetbyState(masa_id, 1)==true)
            {
                newAddition.servis_tur_no = 1;
                newAddition.personel_id = 1;
                newAddition.masa_id = masa_id;
                newAddition.tarih = DateTime.Now;
                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 2);

                if(lvSiparisler.Items.Count>0)
                {
                    for(int i=0; i<lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.masa_id = masa_id;
                        saveOrder.urun_id = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.adisyon_id = newAddition.getByAddition(masa_id);
                        saveOrder.adet= Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);

                    }
                    this.Close();
                    ms.Show();

                }

            }
            else if(masa.TableGetbyState(masa_id, 2)==true || masa.TableGetbyState(masa_id, 4)==true)
            {
                
                if (lvYeniEklenenler.Items.Count>0)
                {
                    for(int i=0; i<lvYeniEklenenler.Items.Count; i++)
                    {
                        saveOrder.masa_id = masa_id;
                        saveOrder.urun_id = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.adisyon_id = newAddition.getByAddition(masa_id);
                        saveOrder.adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    

                }
                if(silinler.Count>0)
                {
                    foreach(string item in silinler)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }

                }
                

                this.Close();
                ms.Show();


            }
            else if(masa.TableGetbyState(masa_id, 3) == true)
            {
               
                //newAddition.servis_tur_no = 1;
                //newAddition.personel_id = 1;
                //newAddition.masa_id = masa_id;
                //newAddition.tarih = DateTime.Now;
                //sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 4);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.masa_id = masa_id;
                        saveOrder.urun_id = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.adisyon_id = newAddition.getByAddition(masa_id);
                        saveOrder.adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);

                    }
                    this.Close();
                    ms.Show();

                }
            }

            
        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    cSiparis saveOrder = new cSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }

                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
            }
        }


        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if(txtAra.Text=="")
            {
                txtAra.Text = "";
            }
            else
            { 
                cUrunCesitleri cu = new cUrunCesitleri();
                cu.getProductSearch(lvMenu, Convert.ToInt32(txtAra.Text));

            }
           
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            cGenel._servis_tur_no = 1;
            cGenel._adisyon_id = adisyon_id.ToString();
            frmBill frm = new frmBill();
            this.Close();
            frm.Show();
        }
    }
}
