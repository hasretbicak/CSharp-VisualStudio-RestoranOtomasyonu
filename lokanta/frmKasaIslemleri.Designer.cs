namespace lokanta
{
    partial class frmKasaIslemleri
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new lokanta.DataSet1();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAylıkRapor = new System.Windows.Forms.Button();
            this.btnZraporu = new System.Windows.Forms.Button();
            this.rpAylik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.rpvGunluk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new lokanta.DataSet1TableAdapters.DataTable1TableAdapter();
            this.DataTable2TableAdapter = new lokanta.DataSet1TableAdapters.DataTable2TableAdapter();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.DataSet1;
            // 
            // btnAylıkRapor
            // 
            this.btnAylıkRapor.BackgroundImage = global::lokanta.Properties.Resources.aylıkrapor;
            this.btnAylıkRapor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAylıkRapor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAylıkRapor.Location = new System.Drawing.Point(135, 193);
            this.btnAylıkRapor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAylıkRapor.Name = "btnAylıkRapor";
            this.btnAylıkRapor.Size = new System.Drawing.Size(300, 176);
            this.btnAylıkRapor.TabIndex = 1;
            this.btnAylıkRapor.UseVisualStyleBackColor = true;
            this.btnAylıkRapor.Click += new System.EventHandler(this.btnAylıkRapor_Click);
            // 
            // btnZraporu
            // 
            this.btnZraporu.BackgroundImage = global::lokanta.Properties.Resources.Zrapor;
            this.btnZraporu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZraporu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnZraporu.Location = new System.Drawing.Point(135, 399);
            this.btnZraporu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZraporu.Name = "btnZraporu";
            this.btnZraporu.Size = new System.Drawing.Size(203, 197);
            this.btnZraporu.TabIndex = 1;
            this.btnZraporu.UseVisualStyleBackColor = true;
            this.btnZraporu.Click += new System.EventHandler(this.btnZraporu_Click);
            // 
            // rpAylik
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.rpAylik.LocalReport.DataSources.Add(reportDataSource1);
            this.rpAylik.LocalReport.ReportEmbeddedResource = "lokanta.Report1.rdlc";
            this.rpAylik.Location = new System.Drawing.Point(581, 69);
            this.rpAylik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rpAylik.Name = "rpAylik";
            this.rpAylik.ServerReport.BearerToken = null;
            this.rpAylik.Size = new System.Drawing.Size(1218, 721);
            this.rpAylik.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(988, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "AYLIK RAPOR";
            // 
            // rpvGunluk
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DataTable2BindingSource;
            this.rpvGunluk.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGunluk.LocalReport.ReportEmbeddedResource = "lokanta.Report2.rdlc";
            this.rpvGunluk.Location = new System.Drawing.Point(542, 69);
            this.rpvGunluk.Name = "rpvGunluk";
            this.rpvGunluk.ServerReport.BearerToken = null;
            this.rpvGunluk.Size = new System.Drawing.Size(1292, 718);
            this.rpvGunluk.TabIndex = 4;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCikis.BackgroundImage = global::lokanta.Properties.Resources.ıkuıotısı;
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(252, 701);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Padding = new System.Windows.Forms.Padding(5, 0, 0, 20);
            this.btnCikis.Size = new System.Drawing.Size(105, 88);
            this.btnCikis.TabIndex = 9;
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
            this.btnGeriDon.Location = new System.Drawing.Point(135, 701);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Padding = new System.Windows.Forms.Padding(5, 0, 0, 20);
            this.btnGeriDon.Size = new System.Drawing.Size(111, 88);
            this.btnGeriDon.TabIndex = 8;
            this.btnGeriDon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGeriDon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // frmKasaIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lokanta.Properties.Resources.images3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1832, 801);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.rpvGunluk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rpAylik);
            this.Controls.Add(this.btnZraporu);
            this.Controls.Add(this.btnAylıkRapor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmKasaIslemleri";
            this.Text = "frmKasaIslemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKasaIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAylıkRapor;
        private System.Windows.Forms.Button btnZraporu;
        private Microsoft.Reporting.WinForms.ReportViewer rpAylik;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rpvGunluk;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private DataSet1TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGeriDon;
    }
}