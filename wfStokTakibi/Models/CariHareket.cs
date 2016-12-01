using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfStokTakibi.Models
{
    class CariHareket
    {
        private int _hareketID;
        private DateTime _tarih;
        private string _islemTuru;
        private int _cariNo;
        private string _belge;
        private double _borc;
        private double _alacak;
        private int _urunHareketID;
        private int _kasaHareketID;

        #region Properties
        public int HareketID
        {
            get
            {
                return _hareketID;
            }

            set
            {
                _hareketID = value;
            }
        }

        public DateTime Tarih
        {
            get
            {
                return _tarih;
            }

            set
            {
                _tarih = value;
            }
        }

        public string IslemTuru
        {
            get
            {
                return _islemTuru;
            }

            set
            {
                _islemTuru = value;
            }
        }

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

        public string Belge
        {
            get
            {
                return _belge;
            }

            set
            {
                _belge = value;
            }
        }

        public double Borc
        {
            get
            {
                return _borc;
            }

            set
            {
                _borc = value;
            }
        }

        public double Alacak
        {
            get
            {
                return _alacak;
            }

            set
            {
                _alacak = value;
            }
        }

        public int UrunHareketID
        {
            get
            {
                return _urunHareketID;
            }

            set
            {
                _urunHareketID = value;
            }
        }

        public int KasaHareketID
        {
            get
            {
                return _kasaHareketID;
            }

            set
            {
                _kasaHareketID = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public bool CariHareketEkle(CariHareket ch)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into CariHareketler (tarih, islemTuru, cariNo, belge, borc, alacak, urunHareketID, kasaHareketID) values(@tarih, @islemTuru, @cariNo, @belge, @borc, @alacak, @urunHareketID, @kasaHareketID)", conn);
            comm.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ch._tarih;
            comm.Parameters.Add("@islemTuru", SqlDbType.VarChar).Value = ch._islemTuru;
            comm.Parameters.Add("@cariNo", SqlDbType.Int).Value = ch._cariNo;
            comm.Parameters.Add("@belge", SqlDbType.VarChar).Value = ch._belge;
            comm.Parameters.Add("@borc", SqlDbType.Money).Value = ch._borc;
            comm.Parameters.Add("@alacak", SqlDbType.Money).Value = ch._alacak;
            comm.Parameters.Add("@urunHareketID", SqlDbType.Int).Value = ch._urunHareketID;
            comm.Parameters.Add("@kasaHareketID", SqlDbType.Int).Value = ch._kasaHareketID;
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
        public bool CariHareketIptalByKasaHareket(int KasaHareketID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update CariHareketler set silindi=1 where kasaHareketID = @kasaHareketID", conn);
            comm.Parameters.Add("@kasaHareketID", SqlDbType.Int).Value = KasaHareketID;
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
