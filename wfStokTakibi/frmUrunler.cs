using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfStokTakibi.Models;

namespace wfStokTakibi
{
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        BindingSource bs1;

        private void DataBagla()
        {
            Urun u = new Urun();
            u.UrunleriGetir(lvUrunler);
            ds = u.UrunleriGetir();
            bs1 = new BindingSource();
            bs1.DataSource = ds.Tables["Urunler"];

            txtUrunID.DataBindings.Clear();
            txtUrunAdi.DataBindings.Clear();
            txtUrunKodu.DataBindings.Clear();
            txtKategori.DataBindings.Clear();
            txtKategoriNo.DataBindings.Clear();
            txtKritik.DataBindings.Clear();
            txtMiktar.DataBindings.Clear();
            txtFiyat.DataBindings.Clear();

            txtUrunID.DataBindings.Add("Text", bs1, "UrunID");
            txtUrunAdi.DataBindings.Add("Text", bs1, "UrunAd");
            txtUrunKodu.DataBindings.Add("Text", bs1, "UrunKodu");
            txtKategori.DataBindings.Add("Text", bs1, "KategoriAd");
            txtKategoriNo.DataBindings.Add("Text", bs1, "KategoriNo");
            txtKritik.DataBindings.Add("Text", bs1, "KritikSeviye");
            txtMiktar.DataBindings.Add("Text", bs1, "Miktar");
            txtFiyat.DataBindings.Add("Text", bs1, "BirimFiyat");

            txtUrunID2.DataBindings.Clear();
            txtUrunAdi2.DataBindings.Clear();
            txtUrunKodu2.DataBindings.Clear();

            txtUrunID2.DataBindings.Add("Text", bs1, "UrunID");
            txtUrunAdi2.DataBindings.Add("Text", bs1, "UrunAd");
            txtUrunKodu2.DataBindings.Add("Text", bs1, "UrunKodu");
        }
        private void Konum()
        {
            tsKonum.Text = (bs1.Position + 1) + " / " + bs1.Count.ToString();
            UrunHareket uh = new UrunHareket();
            uh.UrunHareketleriGetir(lvHareketler, Convert.ToInt32(txtUrunID.Text));
        }
        private void tsLast_Click(object sender, EventArgs e)
        {
            bs1.MoveLast();
            Konum();
        }
        private void tsNext_Click(object sender, EventArgs e)
        {
            bs1.MoveNext();
            Konum();
        }
        private void tsPrev_Click(object sender, EventArgs e)
        {
            bs1.MovePrevious();
            Konum();
        }
        private void tsFirst_Click(object sender, EventArgs e)
        {
            bs1.MoveFirst();
            Konum();
        }
        private void frmUrunler_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Kategori k = new Kategori();
            k.KategorileriGetir(cbKategoriler);
            Urun u = new Urun();
            DataBagla();
            Konum();

        }
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategori k = (Kategori)cbKategoriler.SelectedItem;
            txtKategori.Text = k.KategoriAd;
            txtKategoriNo.Text = Convert.ToString(k.KategoriNo);
            txtFiyat.Focus();

        }
        private void txtKodaGore_TextChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.UrunleriGetirByKodaGore(txtKodaGore.Text, lvUrunler);
        }
        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.UrunleriGetirByAdaGore(txtAdaGore.Text, lvUrunler);
        }
        private void tsYeni_Click(object sender, EventArgs e)
        {
            tsKaydet.Enabled = true;
            tsDegistir.Enabled = false;
            tsSil.Enabled = false;
            bs1.AddNew();
            txtUrunKodu.Focus();
        }
        private void tsKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunKodu.Text) || string.IsNullOrEmpty(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün Kodu veua Ürün adı boş geçilemez");
                txtUrunKodu.Focus();
            }
            else
            {
                Urun u = new Urun();
                if (u.UrunKontrol(txtUrunKodu.Text, txtUrunAdi.Text))
                {
                    MessageBox.Show("Aynı ürün zaten stokta kayıtlı");
                    txtUrunKodu.Focus();
                }
                else
                {
                    bs1.EndEdit();
                    u.UrunKodu = txtUrunKodu.Text;
                    u.UrunAd = txtUrunAdi.Text;
                    u.KategoriNo = Convert.ToInt32(txtKategoriNo.Text);
                    if (string.IsNullOrEmpty(txtKritik.Text))
                    {
                        txtKritik.Text = "0";
                    }
                    u.KritikSeviye = Convert.ToInt32(txtKritik.Text);
                    try
                    {
                        u.BirimFiyat = Convert.ToDouble(txtFiyat.Text);
                    }
                    catch (Exception)
                    {
                        u.BirimFiyat = 0;
                    }
                    if (u.UrunEkle(u))
                    {
                        MessageBox.Show("Yeni ürün stoğa eklendi");
                        tsKaydet.Enabled = false;
                        tsDegistir.Enabled = true;
                        tsSil.Enabled = true;
                        u.UrunleriGetir(lvUrunler);
                        DataBagla();
                        Konum();
                    }
                    else
                    {
                        MessageBox.Show("Yeni ürün eklenmedi!", "DİKKAT! Kayıt işlemi gerçekleşmedi!");
                    }

                }
            }
        }
        private void tsVazgec_Click(object sender, EventArgs e)
        {
            tsKaydet.Enabled = false;
            tsDegistir.Enabled = true;
            tsSil.Enabled = true;
            bs1.CancelEdit();
            Konum();
        }
        private void lvUrunler_DoubleClick(object sender, EventArgs e)
        {
            Urun u = new Urun();
            int kacinci = u.KacinciUrun(Convert.ToInt32 (lvUrunler.SelectedItems[0].SubItems [7].Text ));
            bs1.Position = kacinci;
            Konum();
        }
        private void tsDegistir_Click(object sender, EventArgs e)
        {
            Urun u = new Urun();
            if (u.UrunKontrol(txtUrunKodu.Text, txtUrunAdi.Text, Convert.ToInt32(txtUrunID.Text)))
            {
                MessageBox.Show("Aynı ürün zaten stokta kayıtlı");
                txtUrunKodu.Focus();
            }
            else
            {
                bs1.EndEdit();
                u.UrunID = Convert.ToInt32(txtUrunID.Text);
                u.UrunKodu = txtUrunKodu.Text;
                u.UrunAd = txtUrunAdi.Text;
                u.KategoriNo = Convert.ToInt32(txtKategoriNo.Text);
                if (string.IsNullOrEmpty(txtKritik.Text))
                {
                    txtKritik.Text = "0";
                }
                u.KritikSeviye = Convert.ToInt32(txtKritik.Text);
                try
                {
                    u.BirimFiyat = Convert.ToDouble(txtFiyat.Text);
                }
                catch (Exception)
                {
                    u.BirimFiyat = 0;
                }
                if (u.UrunGuncelle(u))
                {
                    MessageBox.Show("Ürün bilgileri güncellendi.");
                    u.UrunleriGetir(lvUrunler);
                    DataBagla();
                    Konum();
                }
                else
                {
                    MessageBox.Show("Ürün bilgileri değiştirilemedi!", "DİKKAT!");
                }
            }
        }
        private void tsSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Urun u = new Urun();
                if (u.UrunSil(Convert.ToInt32(txtUrunID.Text)))
                {
                    MessageBox.Show("Ürün bilgileri silindi.");
                    u.UrunleriGetir(lvUrunler);
                    DataBagla();
                    Konum();
                }
                else
                {
                    MessageBox.Show("Ürün bilgileri silinemedi!", "DİKKAT!");
                }
            }
        }

        #region UrunHareketleri
        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString();
        }
        private void cbIslemTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIslemTuru.Text = cbIslemTurleri.SelectedItem.ToString();
            txtFirma.Focus();
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtTarih.Text = DateTime.Now.ToShortDateString();
            cbIslemTurleri.SelectedIndex = 1;
            txtBirim.Text = "Adet";
            txtAdet.Text = "1";
            txtBirimFiyat.Text = txtFiyat.Text;
            txtBelge.Focus();
        }
        private void txtBirimFiyat_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBirimFiyat.Text))
            {
                txtBirimFiyat.Text = "0";
                txtBirimFiyat.Select(0, txtBirimFiyat.Text.Length);
            }
            if (string.IsNullOrEmpty(txtAdet.Text))
            {
                txtAdet.Text = "1";
                txtAdet.Select(0, txtAdet.Text.Length);
            }
            txtTutar.Text = (Convert.ToInt32(txtAdet.Text) * Convert.ToDouble(txtBirimFiyat.Text)).ToString();
        }
        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBirimFiyat.Text))
            {
                txtBirimFiyat.Text = "0";
                txtBirimFiyat.Select(0, txtBirimFiyat.Text.Length);
            }
            if (string.IsNullOrEmpty(txtAdet.Text))
            {
                txtAdet.Text = "1";
                txtAdet.Select(0, txtAdet.Text.Length);
            }
            txtTutar.Text = (Convert.ToInt32(txtAdet.Text) * Convert.ToDouble(txtBirimFiyat.Text)).ToString();
        }
        private void btnFirmaBul_Click(object sender, EventArgs e)
        {
            if (txtIslemTuru.Text == "Stok Giriş")
                Genel.caritipi = "Satıcı";
            else if (txtIslemTuru.Text == "Stok Çıkış")
                Genel.caritipi = "Alıcı";
            frmCariSorgulama frm = new frmCariSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            txtFirma.Text = Genel.unvan;
            txtFirmaID.Text = Genel.carino.ToString();
            txtBelge.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtIslemTuru.Text == "Stok Çıkış" && Convert.ToInt32(txtAdet.Text) > Convert.ToInt32(txtMiktar.Text))
            {
                MessageBox.Show("Stokta yeterli ürün yok!", "Dikkat! Stok Yetersiz!");
                txtAdet.Focus();
            }
            else
            {
                //Ürünhareket bilgileri kayıt edilecek.
                UrunHareket uh = new UrunHareket();
                uh.Tarih = Convert.ToDateTime(txtTarih.Text);
                uh.IslemTuru = txtIslemTuru.Text;
                uh.FirmaID = Convert.ToInt32(txtFirmaID.Text);
                uh.UrunID = Convert.ToInt32(txtUrunID2.Text);
                uh.Belge = txtBelge.Text;
                uh.Birim = txtBirim.Text;
                uh.Adet = Convert.ToInt32(txtAdet.Text);
                uh.BirimFiyat = Convert.ToDouble(txtBirimFiyat.Text);
                int kayitno = uh.UrunHareketEkle(uh);
                if (kayitno > 0)
                {
                    MessageBox.Show("Ürün Hareketi eklendi.");
                    uh.UrunHareketleriGetir(lvHareketler, uh.UrunID);
                    //Ürün stok miktarı güncellenecek.
                    Urun u = new Urun();
                    if (u.UrunStokGuncelle(uh.UrunID, uh.Adet, uh.IslemTuru))
                    {
                        MessageBox.Show("Ürün stok miktarı güncellendi.");
                        //CariHareketlere firmanın borç-alacak durumu işlenecek.
                        CariHareket ch = new CariHareket();
                        ch.Tarih = Convert.ToDateTime(txtTarih.Text);
                        ch.IslemTuru = txtIslemTuru.Text;
                        ch.CariNo = Convert.ToInt32(txtFirmaID.Text);
                        ch.Belge = txtBelge.Text;
                        if (txtIslemTuru.Text == "Stok Giriş")
                        {
                            ch.Borc = 0;
                            ch.Alacak = Convert.ToDouble(txtTutar.Text);
                        }
                        else if (txtIslemTuru.Text == "Stok Çıkış")
                        {
                            ch.Borc = Convert.ToDouble(txtTutar.Text);
                            ch.Alacak = 0;
                        }
                        ch.UrunHareketID = kayitno;
                        ch.KasaHareketID = 0;
                        if (ch.CariHareketEkle(ch))
                        {
                            MessageBox.Show("Cari Hareketi eklendi.");
                            //Cariler tablosunda toplam bakiyeler güncellenecek.
                            Cari c = new Cari();
                            bool Sonuc = c.CariToplamlariGuncelleFromUrunHareket(ch.CariNo, ch.Borc, ch.Alacak);
                            if (Sonuc)
                            {
                                MessageBox.Show("Cari toplamlar güncellendi.");
                            }
                            else MessageBox.Show("Cari toplamlar güncellenemedi.", "Dikkat!");
                        }
                        else MessageBox.Show("Cari hareketler eklenemedi.", "Dikkat!");
                    }
                    else MessageBox.Show("Ürün stok güncellenemedi.", "Dikkat!");
                }
                else MessageBox.Show("Ürün hareket eklenemedi.", "Dikkat!");
            }
        }
        #endregion


    }
}
