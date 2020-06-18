namespace lokanta
{
    partial class frmRaporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.grpMenuBasl = new System.Windows.Forms.GroupBox();
            this.btnAraSicak2 = new System.Windows.Forms.Button();
            this.btnCorba1 = new System.Windows.Forms.Button();
            this.btnSalata6 = new System.Windows.Forms.Button();
            this.btnMakarna4 = new System.Windows.Forms.Button();
            this.btnIcecekler8 = new System.Windows.Forms.Button();
            this.btnFastfood5 = new System.Windows.Forms.Button();
            this.btnTatlilar7 = new System.Windows.Forms.Button();
            this.btnAnaYemekler = new System.Windows.Forms.Button();
            this.gbIstatistik = new System.Windows.Forms.GroupBox();
            this.lvIstatistik = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRapor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnZRaporu = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.tableAdapterManager1 = new lokanta.DataSet1TableAdapters.TableAdapterManager();
            this.dataSet11 = new lokanta.DataSet1();
            this.grpMenuBasl.SuspendLayout();
            this.gbIstatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(689, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(773, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bitiş Tarihi :";
            // 
            // dtBaslangic
            // 
            this.dtBaslangic.CalendarForeColor = System.Drawing.Color.White;
            this.dtBaslangic.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBaslangic.Location = new System.Drawing.Point(987, 39);
            this.dtBaslangic.Name = "dtBaslangic";
            this.dtBaslangic.Size = new System.Drawing.Size(476, 45);
            this.dtBaslangic.TabIndex = 1;
            // 
            // dtBitis
            // 
            this.dtBitis.CalendarForeColor = System.Drawing.Color.White;
            this.dtBitis.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtBitis.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtBitis.Location = new System.Drawing.Point(987, 102);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(476, 45);
            this.dtBitis.TabIndex = 1;
            // 
            // grpMenuBasl
            // 
            this.grpMenuBasl.BackColor = System.Drawing.Color.Transparent;
            this.grpMenuBasl.Controls.Add(this.btnAraSicak2);
            this.grpMenuBasl.Controls.Add(this.btnCorba1);
            this.grpMenuBasl.Controls.Add(this.btnSalata6);
            this.grpMenuBasl.Controls.Add(this.btnMakarna4);
            this.grpMenuBasl.Controls.Add(this.btnIcecekler8);
            this.grpMenuBasl.Controls.Add(this.btnFastfood5);
            this.grpMenuBasl.Controls.Add(this.btnTatlilar7);
            this.grpMenuBasl.Controls.Add(this.btnAnaYemekler);
            this.grpMenuBasl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpMenuBasl.ForeColor = System.Drawing.Color.White;
            this.grpMenuBasl.Location = new System.Drawing.Point(22, 39);
            this.grpMenuBasl.Name = "grpMenuBasl";
            this.grpMenuBasl.Size = new System.Drawing.Size(516, 640);
            this.grpMenuBasl.TabIndex = 2;
            this.grpMenuBasl.TabStop = false;
            this.grpMenuBasl.Text = "Menü";
            // 
            // btnAraSicak2
            // 
            this.btnAraSicak2.BackgroundImage = global::lokanta.Properties.Resources.arasıcak;
            this.btnAraSicak2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAraSicak2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAraSicak2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAraSicak2.Location = new System.Drawing.Point(257, 481);
            this.btnAraSicak2.Name = "btnAraSicak2";
            this.btnAraSicak2.Size = new System.Drawing.Size(239, 127);
            this.btnAraSicak2.TabIndex = 0;
            this.btnAraSicak2.UseVisualStyleBackColor = true;
            this.btnAraSicak2.Click += new System.EventHandler(this.btnAraSicak2_Click);
            // 
            // btnCorba1
            // 
            this.btnCorba1.BackgroundImage = global::lokanta.Properties.Resources.çorba;
            this.btnCorba1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCorba1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorba1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCorba1.Location = new System.Drawing.Point(257, 329);
            this.btnCorba1.Name = "btnCorba1";
            this.btnCorba1.Size = new System.Drawing.Size(239, 134);
            this.btnCorba1.TabIndex = 0;
            this.btnCorba1.UseVisualStyleBackColor = true;
            this.btnCorba1.Click += new System.EventHandler(this.btnCorba1_Click);
            // 
            // btnSalata6
            // 
            this.btnSalata6.BackgroundImage = global::lokanta.Properties.Resources.salata;
            this.btnSalata6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalata6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalata6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalata6.Location = new System.Drawing.Point(257, 182);
            this.btnSalata6.Name = "btnSalata6";
            this.btnSalata6.Size = new System.Drawing.Size(239, 127);
            this.btnSalata6.TabIndex = 0;
            this.btnSalata6.UseVisualStyleBackColor = true;
            this.btnSalata6.Click += new System.EventHandler(this.btnSalata6_Click);
            // 
            // btnMakarna4
            // 
            this.btnMakarna4.BackgroundImage = global::lokanta.Properties.Resources.makarna;
            this.btnMakarna4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMakarna4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakarna4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMakarna4.Location = new System.Drawing.Point(6, 481);
            this.btnMakarna4.Name = "btnMakarna4";
            this.btnMakarna4.Size = new System.Drawing.Size(239, 127);
            this.btnMakarna4.TabIndex = 0;
            this.btnMakarna4.UseVisualStyleBackColor = true;
            this.btnMakarna4.Click += new System.EventHandler(this.btnMakarna4_Click);
            // 
            // btnIcecekler8
            // 
            this.btnIcecekler8.BackgroundImage = global::lokanta.Properties.Resources.içecekler;
            this.btnIcecekler8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIcecekler8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIcecekler8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIcecekler8.Location = new System.Drawing.Point(257, 43);
            this.btnIcecekler8.Name = "btnIcecekler8";
            this.btnIcecekler8.Size = new System.Drawing.Size(239, 123);
            this.btnIcecekler8.TabIndex = 0;
            this.btnIcecekler8.UseVisualStyleBackColor = true;
            this.btnIcecekler8.Click += new System.EventHandler(this.btnIcecekler8_Click);
            // 
            // btnFastfood5
            // 
            this.btnFastfood5.BackgroundImage = global::lokanta.Properties.Resources.fastfood;
            this.btnFastfood5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFastfood5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFastfood5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFastfood5.Location = new System.Drawing.Point(6, 329);
            this.btnFastfood5.Name = "btnFastfood5";
            this.btnFastfood5.Size = new System.Drawing.Size(239, 134);
            this.btnFastfood5.TabIndex = 0;
            this.btnFastfood5.UseVisualStyleBackColor = true;
            this.btnFastfood5.Click += new System.EventHandler(this.btnFastfood5_Click);
            // 
            // btnTatlilar7
            // 
            this.btnTatlilar7.BackgroundImage = global::lokanta.Properties.Resources.tatlılar;
            this.btnTatlilar7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTatlilar7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTatlilar7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTatlilar7.Location = new System.Drawing.Point(6, 182);
            this.btnTatlilar7.Name = "btnTatlilar7";
            this.btnTatlilar7.Size = new System.Drawing.Size(239, 127);
            this.btnTatlilar7.TabIndex = 0;
            this.btnTatlilar7.UseVisualStyleBackColor = true;
            this.btnTatlilar7.Click += new System.EventHandler(this.btnTatlilar7_Click);
            // 
            // btnAnaYemekler
            // 
            this.btnAnaYemekler.BackgroundImage = global::lokanta.Properties.Resources.anayemek;
            this.btnAnaYemekler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnaYemekler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnaYemekler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnaYemekler.Location = new System.Drawing.Point(6, 43);
            this.btnAnaYemekler.Name = "btnAnaYemekler";
            this.btnAnaYemekler.Size = new System.Drawing.Size(239, 123);
            this.btnAnaYemekler.TabIndex = 0;
            this.btnAnaYemekler.UseVisualStyleBackColor = true;
            this.btnAnaYemekler.Click += new System.EventHandler(this.btnAnaYemekler_Click);
            // 
            // gbIstatistik
            // 
            this.gbIstatistik.BackColor = System.Drawing.Color.Transparent;
            this.gbIstatistik.Controls.Add(this.lvIstatistik);
            this.gbIstatistik.Controls.Add(this.chRapor);
            this.gbIstatistik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbIstatistik.ForeColor = System.Drawing.Color.White;
            this.gbIstatistik.Location = new System.Drawing.Point(675, 184);
            this.gbIstatistik.Name = "gbIstatistik";
            this.gbIstatistik.Size = new System.Drawing.Size(848, 554);
            this.gbIstatistik.TabIndex = 3;
            this.gbIstatistik.TabStop = false;
            // 
            // lvIstatistik
            // 
            this.lvIstatistik.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvIstatistik.HideSelection = false;
            this.lvIstatistik.Location = new System.Drawing.Point(21, 73);
            this.lvIstatistik.Name = "lvIstatistik";
            this.lvIstatistik.Size = new System.Drawing.Size(22, 26);
            this.lvIstatistik.TabIndex = 1;
            this.lvIstatistik.UseCompatibleStateImageBehavior = false;
            this.lvIstatistik.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ÜrünAdı";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adedi";
            // 
            // chRapor
            // 
            this.chRapor.BackColor = System.Drawing.Color.Transparent;
            this.chRapor.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chRapor.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chRapor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chRapor.Legends.Add(legend1);
            this.chRapor.Location = new System.Drawing.Point(62, 73);
            this.chRapor.Name = "chRapor";
            this.chRapor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Label = "Satislar";
            series1.Legend = "Legend1";
            series1.Name = "Satislar";
            this.chRapor.Series.Add(series1);
            this.chRapor.Size = new System.Drawing.Size(751, 444);
            this.chRapor.TabIndex = 0;
            this.chRapor.Text = "chart1";
            // 
            // btnZRaporu
            // 
            this.btnZRaporu.BackgroundImage = global::lokanta.Properties.Resources.tümürünlerı;
            this.btnZRaporu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZRaporu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZRaporu.Location = new System.Drawing.Point(22, 715);
            this.btnZRaporu.Name = "btnZRaporu";
            this.btnZRaporu.Size = new System.Drawing.Size(301, 145);
            this.btnZRaporu.TabIndex = 0;
            this.btnZRaporu.UseVisualStyleBackColor = true;
            this.btnZRaporu.Click += new System.EventHandler(this.btnZRaporu_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCikis.BackgroundImage = global::lokanta.Properties.Resources.ıkuıotısı;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(1456, 791);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Padding = new System.Windows.Forms.Padding(5, 0, 0, 20);
            this.btnCikis.Size = new System.Drawing.Size(85, 69);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGeriDon.BackgroundImage = global::lokanta.Properties.Resources.erfdfgsı;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeriDon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeriDon.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeriDon.ForeColor = System.Drawing.Color.White;
            this.btnGeriDon.Location = new System.Drawing.Point(1365, 791);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Padding = new System.Windows.Forms.Padding(5, 0, 0, 20);
            this.btnGeriDon.Size = new System.Drawing.Size(85, 69);
            this.btnGeriDon.TabIndex = 7;
            this.btnGeriDon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGeriDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = lokanta.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lokanta.Properties.Resources.images3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1571, 991);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.gbIstatistik);
            this.Controls.Add(this.grpMenuBasl);
            this.Controls.Add(this.dtBitis);
            this.Controls.Add(this.btnZRaporu);
            this.Controls.Add(this.dtBaslangic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRaporlar";
            this.Text = "frmRaporlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRaporlar_Load);
            this.grpMenuBasl.ResumeLayout(false);
            this.gbIstatistik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtBaslangic;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.GroupBox grpMenuBasl;
        private System.Windows.Forms.Button btnAraSicak2;
        private System.Windows.Forms.Button btnCorba1;
        private System.Windows.Forms.Button btnSalata6;
        private System.Windows.Forms.Button btnMakarna4;
        private System.Windows.Forms.Button btnIcecekler8;
        private System.Windows.Forms.Button btnFastfood5;
        private System.Windows.Forms.Button btnTatlilar7;
        private System.Windows.Forms.Button btnAnaYemekler;
        private System.Windows.Forms.GroupBox gbIstatistik;
        private System.Windows.Forms.ListView lvIstatistik;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chRapor;
        private System.Windows.Forms.Button btnZRaporu;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeriDon;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private DataSet1 dataSet11;
    }
}