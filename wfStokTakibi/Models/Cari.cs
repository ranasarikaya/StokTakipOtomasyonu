using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfStokTakibi.Models
{
    class Cari
    {
        private int _cariNo;
        private string _cariTipi;
        private string _unvan;
        private string _yetkili;
        private string _telefon;
        private string _adres;
        private string _ilce;
        private string _il;
        private string _vergiNo;
        private string _vergiDairesi;
        private double _toplamBorc;
        private double _toplamAlacak;
        private double _bakiye;

        #region Properties
        public int CariNo
        {
            get
            {
                return _cariNo;
            }

            set
            {
                _cariNo = value;
            }
        }

        public string CariTipi
        {
            get
            {
                return _cariTipi;
            }

            set
            {
                _cariTipi = value;
            }
        }

        public string Unvan
        {
            get
            {
                return _unvan;
            }

            set
            {
                _unvan = value;
            }
        }

        public string Yetkili
        {
            get
            {
                return _yetkili;
            }

            set
            {
                _yetkili = value;
            }
        }

        public string Telefon
        {
            get
            {
                return _telefon;
            }

            set
            {
                _telefon = value;
            }
        }

        public string Adres
        {
            get
            {
                return _adres;
            }

            set
            {
                _adres = value;
            }
        }

        public string Ilce
        {
            get
            {
                return _ilce;
            }

            set
            {
                _ilce = value;
            }
        }

        public string Il
        {
            get
            {
                return _il;
            }

            set
            {
                _il = value;
            }
        }

        public string VergiNo
        {
            get
            {
                return _vergiNo;
            }

            set
            {
                _vergiNo = value;
            }
        }

        public string VergiDairesi
        {
            get
            {
                return _vergiDairesi;
            }

            set
            {
                _vergiDairesi = value;
            }
        }

        public double ToplamBorc
        {
            get
            {
                return _toplamBorc;
            }

            set
            {
                _toplamBorc = value;
            }
        }

        public double ToplamAlacak
        {
            get
            {
                return _toplamAlacak;
            }

            set
            {
                _toplamAlacak = value;
            }
        }

        public double Bakiye
        {
            get
            {
                return _bakiye;
            }

            set
            {
                _bakiye = value;
            }
        }
        #endregion

        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(Genel.connStr);
        public DataTable CarileriGetirByCariTipi(string CariTipi)
        {
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cariler where cariTipi=@cariTipi and silindi=0", conn);
            da.SelectCommand.Parameters.Add("@cariTipi", SqlDbType.VarChar).Value = CariTipi;
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex) 
            {
                string hata = ex.Message;
            }
            return dt;
        }
        public DataTable CarileriGetirByTumu()
        {
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cariler where silindi=0", conn);
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return dt;
        }
        public DataTable CarileriGetirByUnvanaGore(string UnvanaGore)
        {
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cariler where Unvan like @UnvanaGore + '%' and silindi=0", conn);
            da.SelectCommand.Parameters.Add("@UnvanaGore", SqlDbType.VarChar).Value = UnvanaGore;
            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return dt;
        }
        public bool CariToplamlariGuncelleFromUrunHareket(int CariNo, double Borc, double Alacak)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Cariler set toplamBorc=toplamBorc + @Borc, toplamAlacak=toplamAlacak + @Alacak where cariNo=@cariNo", conn);
            comm.Parameters.Add("@Borc", SqlDbType.Money).Value = Borc;
            comm.Parameters.Add("@Alacak", SqlDbType.Money).Value = Alacak;
            comm.Parameters.Add("@cariNo", SqlDbType.Int).Value = CariNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
        public bool CariToplamlariGuncelleFromKasaIptal(int CariNo, double Borc, double Alacak)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Cariler set toplamBorc=toplamBorc - @Borc, toplamAlacak=toplamAlacak - @Alacak where cariNo=@cariNo", conn);
            comm.Parameters.Add("@Borc", SqlDbType.Money).Value = Borc;
            comm.Parameters.Add("@Alacak", SqlDbType.Money).Value = Alacak;
            comm.Parameters.Add("@cariNo", SqlDbType.Int).Value = CariNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
    }
}
