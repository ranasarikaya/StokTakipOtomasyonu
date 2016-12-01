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
    public partial class frmCariSorgulama : Form
    {
        public frmCariSorgulama()
        {
            InitializeComponent();
        }
        Cari c = new Cari();
        DataTable dt = new DataTable();
        private void frmCariSorgulama_Load(object sender, EventArgs e)
        {
            if(Genel.caritipi == "Alıcı")
            {
                rbAlicilar.Checked = true;
            }
            else if(Genel.caritipi == "Satıcı")
            {
                rbSaticilar.Checked = true;
            }else { rbTumFirmalar.Checked = true; }
        }
        private void txtUnvanaGore_TextChanged(object sender, EventArgs e)
        {
            c.CarileriGetirByUnvanaGore(txtUnvanaGore.Text);
        }
        private void rbAlicilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Alıcı";
            dt = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = dt;
        }
        private void rbSaticilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Satıcı";
            dt = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = dt;
        }
        private void rbTumFirmalar_CheckedChanged(object sender, EventArgs e)
        {
            dt = c.CarileriGetirByTumu();
            dgvCariler.DataSource = dt;
        }
        private void dgvCariler_DoubleClick(object sender, EventArgs e)
        {
            Genel.carino = Convert.ToInt32(dgvCariler.SelectedRows[0].Cells[0].Value);
            Genel.unvan = Convert.ToString(dgvCariler.SelectedRows[0].Cells[2].Value);
            this.Close();
        }
    }
}
