namespace wfStokTakibi
{
    partial class frmKasa
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKasaTuru = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.txtTarih = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDevirGiren = new System.Windows.Forms.TextBox();
            this.txtDevirCikan = new System.Windows.Forms.TextBox();
            this.txtDevirBakiye = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnDegistir = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.lvHareketler = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtIslemTarihi = new System.Windows.Forms.TextBox();
            this.txtIslemTuru = new System.Windows.Forms.TextBox();
            this.cbIslemTurleri = new System.Windows.Forms.ComboBox();
            this.txtCariNo = new System.Windows.Forms.TextBox();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.txtBelge = new System.Windows.Forms.TextBox();
            this.txtGiren = new System.Windows.Forms.TextBox();
            this.txtCikan = new System.Windows.Forms.TextBox();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.txtBakiye = new System.Windows.Forms.TextBox();
            this.txtCikanToplam = new System.Windows.Forms.TextBox();
            this.txtGirenToplam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kasa Türü";
            // 
            // txtKasaTuru
            // 
            this.txtKasaTuru.Location = new System.Drawing.Point(145, 42);
            this.txtKasaTuru.Name = "txtKasaTuru";
            this.txtKasaTuru.ReadOnly = true;
            this.txtKasaTuru.Size = new System.Drawing.Size(111, 23);
            this.txtKasaTuru.TabIndex = 1;
            this.txtKasaTuru.Text = "Merkez Kasa";
            this.txtKasaTuru.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(257, 72);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(29, 23);
            this.dtpTarih.TabIndex = 30;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.dtpTarih_ValueChanged);
            // 
            // txtTarih
            // 
            this.txtTarih.Location = new System.Drawing.Point(145, 72);
            this.txtTarih.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.ReadOnly = true;
            this.txtTarih.Size = new System.Drawing.Size(111, 23);
            this.txtTarih.TabIndex = 29;
            this.txtTarih.TextChanged += new System.EventHandler(this.txtTarih_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 72);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "İşlem Tarihi";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(111, 23);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "TL";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Para Birimi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Devirler";
            // 
            // txtDevirGiren
            // 
            this.txtDevirGiren.Location = new System.Drawing.Point(424, 74);
            this.txtDevirGiren.Margin = new System.Windows.Forms.Padding(4);
            this.txtDevirGiren.Name = "txtDevirGiren";
            this.txtDevirGiren.ReadOnly = true;
            this.txtDevirGiren.Size = new System.Drawing.Size(93, 23);
            this.txtDevirGiren.TabIndex = 34;
            this.txtDevirGiren.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDevirCikan
            // 
            this.txtDevirCikan.Location = new System.Drawing.Point(525, 74);
            this.txtDevirCikan.Margin = new System.Windows.Forms.Padding(4);
            this.txtDevirCikan.Name = "txtDevirCikan";
            this.txtDevirCikan.ReadOnly = true;
            this.txtDevirCikan.Size = new System.Drawing.Size(93, 23);
            this.txtDevirCikan.TabIndex = 35;
            this.txtDevirCikan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDevirBakiye
            // 
            this.txtDevirBakiye.Location = new System.Drawing.Point(626, 74);
            this.txtDevirBakiye.Margin = new System.Windows.Forms.Padding(4);
            this.txtDevirBakiye.Name = "txtDevirBakiye";
            this.txtDevirBakiye.ReadOnly = true;
            this.txtDevirBakiye.Size = new System.Drawing.Size(93, 23);
            this.txtDevirBakiye.TabIndex = 36;
            this.txtDevirBakiye.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSil
            // 
            this.btnSil.Enabled = false;
            this.btnSil.Location = new System.Drawing.Point(654, 139);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(53, 27);
            this.btnSil.TabIndex = 54;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDegistir
            // 
            this.btnDegistir.Enabled = false;
            this.btnDegistir.Location = new System.Drawing.Point(571, 139);
            this.btnDegistir.Name = "btnDegistir";
            this.btnDegistir.Size = new System.Drawing.Size(77, 27);
            this.btnDegistir.TabIndex = 53;
            this.btnDegistir.Text = "Değiştir";
            this.btnDegistir.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(492, 139);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(73, 27);
            this.btnKaydet.TabIndex = 52;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.Location = new System.Drawing.Point(438, 139);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(48, 27);
            this.btnYeni.TabIndex = 37;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.UseVisualStyleBackColor = true;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // lvHareketler
            // 
            this.lvHareketler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvHareketler.FullRowSelect = true;
            this.lvHareketler.GridLines = true;
            this.lvHareketler.Location = new System.Drawing.Point(60, 240);
            this.lvHareketler.Name = "lvHareketler";
            this.lvHareketler.Size = new System.Drawing.Size(703, 201);
            this.lvHareketler.TabIndex = 41;
            this.lvHareketler.UseCompatibleStateImageBehavior = false;
            this.lvHareketler.View = System.Windows.Forms.View.Details;
            this.lvHareketler.DoubleClick += new System.EventHandler(this.lvHareketler_DoubleClick);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "ID";
            this.columnHeader12.Width = 45;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "İşlemTarihi";
            this.columnHeader13.Width = 85;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "İşlemTürü";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "CariÜnvan";
            this.columnHeader15.Width = 120;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Belge";
            this.columnHeader16.Width = 160;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Giren";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader17.Width = 70;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Çıkan";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader18.Width = 70;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "P.Birimi";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "CariNo";
            this.columnHeader20.Width = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(60, 210);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(51, 23);
            this.txtID.TabIndex = 42;
            // 
            // txtIslemTarihi
            // 
            this.txtIslemTarihi.Location = new System.Drawing.Point(111, 210);
            this.txtIslemTarihi.Margin = new System.Windows.Forms.Padding(4);
            this.txtIslemTarihi.Name = "txtIslemTarihi";
            this.txtIslemTarihi.ReadOnly = true;
            this.txtIslemTarihi.Size = new System.Drawing.Size(80, 23);
            this.txtIslemTarihi.TabIndex = 43;
            // 
            // txtIslemTuru
            // 
            this.txtIslemTuru.Location = new System.Drawing.Point(191, 210);
            this.txtIslemTuru.Margin = new System.Windows.Forms.Padding(4);
            this.txtIslemTuru.Name = "txtIslemTuru";
            this.txtIslemTuru.ReadOnly = true;
            this.txtIslemTuru.Size = new System.Drawing.Size(82, 23);
            this.txtIslemTuru.TabIndex = 44;
            // 
            // cbIslemTurleri
            // 
            this.cbIslemTurleri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIslemTurleri.FormattingEnabled = true;
            this.cbIslemTurleri.Items.AddRange(new object[] {
            "Tahsilat",
            "Ödeme"});
            this.cbIslemTurleri.Location = new System.Drawing.Point(191, 182);
            this.cbIslemTurleri.Name = "cbIslemTurleri";
            this.cbIslemTurleri.Size = new System.Drawing.Size(82, 24);
            this.cbIslemTurleri.TabIndex = 45;
            this.cbIslemTurleri.SelectedIndexChanged += new System.EventHandler(this.cbIslemTurleri_SelectedIndexChanged);
            // 
            // txtCariNo
            // 
            this.txtCariNo.Location = new System.Drawing.Point(292, 183);
            this.txtCariNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCariNo.Name = "txtCariNo";
            this.txtCariNo.ReadOnly = true;
            this.txtCariNo.Size = new System.Drawing.Size(13, 23);
            this.txtCariNo.TabIndex = 46;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(273, 210);
            this.txtUnvan.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.ReadOnly = true;
            this.txtUnvan.Size = new System.Drawing.Size(118, 23);
            this.txtUnvan.TabIndex = 47;
            // 
            // txtBelge
            // 
            this.txtBelge.Location = new System.Drawing.Point(391, 210);
            this.txtBelge.Margin = new System.Windows.Forms.Padding(4);
            this.txtBelge.Name = "txtBelge";
            this.txtBelge.Size = new System.Drawing.Size(159, 23);
            this.txtBelge.TabIndex = 48;
            // 
            // txtGiren
            // 
            this.txtGiren.Location = new System.Drawing.Point(550, 210);
            this.txtGiren.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiren.Name = "txtGiren";
            this.txtGiren.Size = new System.Drawing.Size(70, 23);
            this.txtGiren.TabIndex = 49;
            // 
            // txtCikan
            // 
            this.txtCikan.Location = new System.Drawing.Point(620, 210);
            this.txtCikan.Margin = new System.Windows.Forms.Padding(4);
            this.txtCikan.Name = "txtCikan";
            this.txtCikan.Size = new System.Drawing.Size(70, 23);
            this.txtCikan.TabIndex = 50;
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(690, 210);
            this.txtPara.Margin = new System.Windows.Forms.Padding(4);
            this.txtPara.Name = "txtPara";
            this.txtPara.ReadOnly = true;
            this.txtPara.Size = new System.Drawing.Size(68, 23);
            this.txtPara.TabIndex = 51;
            this.txtPara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBakiye
            // 
            this.txtBakiye.Location = new System.Drawing.Point(691, 448);
            this.txtBakiye.Margin = new System.Windows.Forms.Padding(4);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(71, 23);
            this.txtBakiye.TabIndex = 54;
            this.txtBakiye.TabStop = false;
            // 
            // txtCikanToplam
            // 
            this.txtCikanToplam.Location = new System.Drawing.Point(621, 448);
            this.txtCikanToplam.Margin = new System.Windows.Forms.Padding(4);
            this.txtCikanToplam.Name = "txtCikanToplam";
            this.txtCikanToplam.ReadOnly = true;
            this.txtCikanToplam.Size = new System.Drawing.Size(71, 23);
            this.txtCikanToplam.TabIndex = 53;
            this.txtCikanToplam.TabStop = false;
            // 
            // txtGirenToplam
            // 
            this.txtGirenToplam.Location = new System.Drawing.Point(550, 448);
            this.txtGirenToplam.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirenToplam.Name = "txtGirenToplam";
            this.txtGirenToplam.ReadOnly = true;
            this.txtGirenToplam.Size = new System.Drawing.Size(71, 23);
            this.txtGirenToplam.TabIndex = 52;
            this.txtGirenToplam.TabStop = false;
            // 
            // frmKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(863, 512);
            this.Controls.Add(this.txtBakiye);
            this.Controls.Add(this.txtCikanToplam);
            this.Controls.Add(this.txtGirenToplam);
            this.Controls.Add(this.txtPara);
            this.Controls.Add(this.txtCikan);
            this.Controls.Add(this.txtGiren);
            this.Controls.Add(this.txtBelge);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.txtCariNo);
            this.Controls.Add(this.cbIslemTurleri);
            this.Controls.Add(this.txtIslemTuru);
            this.Controls.Add(this.txtIslemTarihi);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lvHareketler);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDegistir);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.txtDevirBakiye);
            this.Controls.Add(this.txtDevirCikan);
            this.Controls.Add(this.txtDevirGiren);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtKasaTuru);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKasa";
            this.Text = "Günlük Kasa İşlemleri";
            this.Load += new System.EventHandler(this.frmKasa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKasaTuru;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.TextBox txtTarih;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDevirGiren;
        private System.Windows.Forms.TextBox txtDevirCikan;
        private System.Windows.Forms.TextBox txtDevirBakiye;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnDegistir;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.ListView lvHareketler;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtIslemTarihi;
        private System.Windows.Forms.TextBox txtIslemTuru;
        private System.Windows.Forms.ComboBox cbIslemTurleri;
        private System.Windows.Forms.TextBox txtCariNo;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.TextBox txtBelge;
        private System.Windows.Forms.TextBox txtGiren;
        private System.Windows.Forms.TextBox txtCikan;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.TextBox txtBakiye;
        private System.Windows.Forms.TextBox txtCikanToplam;
        private System.Windows.Forms.TextBox txtGirenToplam;
    }
}