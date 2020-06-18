using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lokanta
{
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
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

        private void frmRaporlar_Load(object sender, EventArgs e)
        {

        }

        private void btnAnaYemekler_Click(object sender, EventArgs e)
        {
            Istatistik("Ana Yemekler İstatistiği", 3, Color.Red);
        }
        private void Istatistik(string gfName, int kat_id, Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistikUrunID(lvIstatistik, dtBaslangic, dtBitis, kat_id);
            gbIstatistik.Text = gfName;

            if (lvIstatistik.Items.Count > 0)
            {

                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek İstatistik Yok. Başka Bir Zaman Dilimi Seçiniz.");
            }
        }

        private void btnIcecekler8_Click(object sender, EventArgs e)
        {
            Istatistik("İçecekler İstatistiği", 8, Color.Orange);
        }

        private void btnTatlilar7_Click(object sender, EventArgs e)
        {
            Istatistik("Tatlılar İstatistiği", 7, Color.Blue);
        }

        private void btnSalata6_Click(object sender, EventArgs e)
        {
            Istatistik("Salatalar İstatistiği", 6, Color.Green);
        }

        private void btnFastfood5_Click(object sender, EventArgs e)
        {
            Istatistik("FastFood İstatistiği", 5, Color.LightBlue);
        }

        private void btnCorba1_Click(object sender, EventArgs e)
        {
            Istatistik("Çorbalar İstatistiği", 1, Color.Yellow);
        }

        private void btnMakarna4_Click(object sender, EventArgs e)
        {
            Istatistik("Makarna İstatistiği", 4, Color.Purple);
        }

        private void btnAraSicak2_Click(object sender, EventArgs e)
        {
            Istatistik("Ara Sıcak İstatistiği", 2, Color.Goldenrod);
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.GreenYellow;
            cUrunler u = new cUrunler();
            lvIstatistik.Items.Clear();
            u.urunleriListeleIstatistik(lvIstatistik, dtBaslangic, dtBitis);
            gbIstatistik.Text = "Tüm Ürünler ";

            if (lvIstatistik.Items.Count > 0)
            {

                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text, lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek İstatistik Yok. Başka Bir Zaman Dilimi Seçiniz.");
            }
        }
    }
}
