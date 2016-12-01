using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfStokTakibi.Models
{
    class Kategori
    {
        private int _kategoriNo;
        private string _kategoriAd;
        private string _aciklama;

        #region Properties
        public int KategoriNo
        {
            get
            {
                return _kategoriNo;
            }

            set
            {
                _kategoriNo = value;
            }
        }

        public string KategoriAd
        {
            get
            {
                return _kategoriAd;
            }

            set
            {
                _kategoriAd = value;
            }
        }

        public string Aciklama
        {
            get
            {
                return _aciklama;
            }

            set
            {
                _aciklama = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public void KategorileriGetir(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select kategoriNo,kategoriAd from Kategoriler where silindi=0", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
        dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Kategori k = new Kategori();
                        k._kategoriAd = dr[1].ToString();
                        k._kategoriNo = Convert.ToInt32(dr[0]);
                        liste.Items.Add(k);
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
        }
        public override string ToString()
        {
            return _kategoriAd; ;
        }



    }
}

