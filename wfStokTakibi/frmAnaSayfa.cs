using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfStokTakibi
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void mitmUrunKartlari_Click(object sender, EventArgs e)
        {
            frmUrunler frm = new frmUrunler();
            FormAcikmi(frm);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mitmcikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mitmGunlukKasa_Click(object sender, EventArgs e)
        {
            frmKasa frm = new frmKasa();
            FormAcikmi(frm);
        }

        private void FormAcikmi(Form AcilacakForm)
        {
            bool Acikmi = false;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == AcilacakForm.Name)
                {
                    this.MdiChildren[i].Focus();
                    Acikmi = true;
                }
            }
            if (Acikmi == false)
            {
                AcilacakForm.MdiParent = this;
                AcilacakForm.Show();
            }
            else
            {
                AcilacakForm.Dispose();  //Kullanılmayacak form nesnesini hafızadan atar.
                //Bu işlem C#.Net ortamında bir süre sonra Garbage Collector tarafından otomatik olarak zaten yapılacaktır. 
            }
        }
    }
}
