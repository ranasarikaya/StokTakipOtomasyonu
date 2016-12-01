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
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        private void frmKasa_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            txtTarih.Text = DateTime.Now.ToShortDateString();

        }
        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString();
        }
        private void txtTarih_TextChanged(object sender, EventArgs e)
        {
            //İşlem tarihine kadar olan devirler getirilmeli.
            Kasa k = new Kasa();
            k.KasaDevirleriGetir(txtTarih.Text, txtDevirGiren, txtDevirCikan, txtDevirBakiye);
            //İşlem tarihindeki kasa hareketleri listelenmeli.
            k.KasaHareketleriGetir(txtTarih.Text, lvHareketler, txtGirenToplam, txtCikanToplam, txtBakiye);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }
        private void Temizle()
        {
            txtID.Clear();
            txtIslemTarihi.Text = txtTarih.Text;
            txtUnvan.Clear();
            txtCariNo.Clear();
            txtBelge.Clear();
            txtGiren.Text = "0";
            txtCikan.Text = "0";
            txtPara.Text = "TL";
            txtIslemTuru.Focus();
        }

        private void cbIslemTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIslemTuru.Text = cbIslemTurleri.SelectedItem.ToString();
            if(txtIslemTuru.Text == "Tahsilat")
            {
                Genel.caritipi = "Alıcı";
                txtGiren.ReadOnly = false;
                txtCikan.ReadOnly = true;
            }
            else if (txtIslemTuru.Text == "Ödeme")
            {
                Genel.caritipi = "Satıcı";
                txtGiren.ReadOnly = true;
                txtCikan.ReadOnly = false;
            }
            frmCariSorgulama frm = new frmCariSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            txtCariNo.Text = Genel.carino.ToString();
            txtUnvan.Text = Genel.unvan;
            txtBelge.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtGiren.Text == "0" && txtCikan.Text == "0")
            {
                MessageBox.Show("Tutar bilgisi girmelisiniz!", "Dikkat! Eksik Bilgi");
                txtGiren.Focus();
            }else
            {
                Kasa k = new Kasa();
                k.IslemTuru = txtIslemTuru.Text;
                k.Tarih = Convert.ToDateTime(txtIslemTarihi.Text);
                k.CariNo = Convert.ToInt32(txtCariNo.Text);
                k.Belge = txtBelge.Text;
                k.Giren = Convert.ToDouble(txtGiren.Text);
                k.Cikan = Convert.ToDouble(txtCikan.Text);
                int kayitno = k.KasaHareketEkle(k);
                if(kayitno > 0)
                {
                    MessageBox.Show("Kasa hareketi eklendi.");
                    btnKaydet.Enabled = false;
                    k.KasaHareketleriGetir(txtTarih.Text, lvHareketler, txtGirenToplam, txtCikanToplam, txtBakiye);
                    //Cari hareket eklenecek.
                    CariHareket ch = new CariHareket();
                    ch.Tarih = Convert.ToDateTime(txtTarih.Text);
                    ch.IslemTuru = txtIslemTuru.Text;
                    ch.CariNo = Convert.ToInt32(txtCariNo.Text);
                    ch.Belge = txtBelge.Text;
                    if (txtIslemTuru.Text == "Tahsilat")
                    {
                        ch.Borc = 0;
                        ch.Alacak = Convert.ToDouble(txtGiren.Text);
                    }
                    else if (txtIslemTuru.Text == "Ödeme")
                    {
                        ch.Borc = Convert.ToDouble(txtCikan.Text);
                        ch.Alacak = 0;
                    }
                    ch.UrunHareketID = 0;
                    ch.KasaHareketID = kayitno;
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
                        Temizle();
                    }
                    else MessageBox.Show("Cari hareketler eklenemedi.", "Dikkat!");
                }
                else MessageBox.Show("Kasa hareketi eklenemedi.", "Dikkat!");
            }
        }

        private void lvHareketler_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = lvHareketler.SelectedItems[0].SubItems[0].Text;
            txtIslemTarihi.Text = lvHareketler.SelectedItems[0].SubItems[1].Text;
            txtIslemTuru.Text = lvHareketler.SelectedItems[0].SubItems[2].Text;
            txtUnvan.Text = lvHareketler.SelectedItems[0].SubItems[3].Text;
            txtCariNo.Text = lvHareketler.SelectedItems[0].SubItems[8].Text;
            txtBelge.Text = lvHareketler.SelectedItems[0].SubItems[4].Text;
            txtGiren.Text = lvHareketler.SelectedItems[0].SubItems[5].Text;
            txtCikan.Text = lvHareketler.SelectedItems[0].SubItems[6].Text;
            txtPara.Text = lvHareketler.SelectedItems[0].SubItems[7].Text;
            //btnDegistir.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtBelge.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Kasa k = new Kasa();
                bool Sonuc = k.KasaHareketSil(Convert.ToInt32(txtID.Text));
                if(Sonuc)
                {
                    MessageBox.Show("Kasa hareketi iptal edildi.", "Silindi!");
                    k.KasaHareketleriGetir(txtTarih.Text, lvHareketler, txtGirenToplam, txtCikanToplam, txtBakiye);
                    CariHareket ch = new CariHareket();
                    Sonuc = ch.CariHareketIptalByKasaHareket(Convert.ToInt32(txtID.Text));
                    if(Sonuc)
                    {
                        MessageBox.Show("Cari Hareket İptal edildi!");
                        //Cariler tablosunda toplam bakiyeler güncellenecek.
                        Cari c = new Cari();
                        if (txtIslemTuru.Text == "Tahsilat")
                        {
                            ch.Borc = 0;
                            ch.Alacak = Convert.ToDouble(txtGiren.Text);
                        }
                        else if (txtIslemTuru.Text == "Ödeme")
                        {
                            ch.Borc = Convert.ToDouble(txtCikan.Text);
                            ch.Alacak = 0;
                        }
                        Sonuc = c.CariToplamlariGuncelleFromKasaIptal(Convert.ToInt32(txtCariNo.Text), ch.Borc, ch.Alacak);
                        if (Sonuc)
                        {
                            MessageBox.Show("Cari toplamlar güncellendi.");
                        }
                        else MessageBox.Show("Cari toplamlar güncellenemedi.", "Dikkat!");
                        btnSil.Enabled = false;
                        Temizle();
                    }
                }
            }
        }
    }
}
