using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfStokTakibi.Models;

namespace wfStokTakibi
{
    class Kasa
    {
        private int _ID;
        private string _kasaTuru;
        private DateTime _tarih;
        private string _islemTuru;
        private int _cariNo;
        private string _belge;
        private double _giren;
        private double _cikan;
        private string _paraBirimi;

        #region Properties
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string KasaTuru
        {
            get
            {
                return _kasaTuru;
            }

            set
            {
                _kasaTuru = value;
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

        public double Giren
        {
            get
            {
                return _giren;
            }

            set
            {
                _giren = value;
            }
        }

        public double Cikan
        {
            get
            {
                return _cikan;
            }

            set
            {
                _cikan = value;
            }
        }

        public string ParaBirimi
        {
            get
            {
                return _paraBirimi;
            }

            set
            {
                _paraBirimi = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        public void KasaDevirleriGetir(string Tarih, TextBox DevirGiren, TextBox DevirCikan, TextBox DevirBakiye)
        {
            SqlCommand comm = new SqlCommand("select sum(giren) as DevirGiren, sum(cikan) as DevirCikan, sum(giren - cikan) as DevirBakiye from KasaHareketler where tarih < @tarih and silindi=0", conn);
            comm.Parameters.Add("@tarih", SqlDbType.DateTime).Value = Convert.ToDateTime(Tarih);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["DevirGiren"] == null || dr["DevirGiren"].ToString() == "")
                            DevirGiren.Text = "0";
                        else
                            DevirGiren.Text = string.Format("{0:c}", Convert.ToDouble(dr["DevirGiren"]));
                        if (dr["DevirCikan"] == null || dr["DevirCikan"].ToString() == "")
                            DevirCikan.Text = "0";
                        else
                            DevirCikan.Text = string.Format("{0:c}", Convert.ToDouble(dr["DevirCikan"]));
                        if (dr["DevirBakiye"] == null || dr["DevirBakiye"].ToString() == "")
                            DevirBakiye.Text = "0";
                        else
                            DevirBakiye.Text = string.Format("{0:c}", Convert.ToDouble(dr["DevirBakiye"]));
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }
        public void KasaHareketleriGetir(string Tarih, ListView liste, TextBox ToplamGiren, TextBox ToplamCikan, TextBox Bakiye)
        {
            liste.Items.Clear();
            double TGiren = 0;
            double TCikan = 0;
            SqlCommand comm = new SqlCommand("select ID, tarih, islemTuru, unvan, belge, giren, cikan, parabrm, kh.cariNo from KasaHareketler kh inner join Cariler c on kh.CariNo=c.CariNo where Convert(varchar(20), tarih, 104) = Convert(varchar(20), @tarih, 104) and kh.silindi=0", conn);
            comm.Parameters.Add("@tarih", SqlDbType.DateTime).Value = Convert.ToDateTime(Tarih);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        TGiren += Convert.ToDouble(dr[5]);
                        TCikan += Convert.ToDouble(dr[6]);
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            ToplamGiren.Text = string.Format("{0:c}", TGiren);
            ToplamCikan.Text = string.Format("{0:c}", TCikan);
            Bakiye.Text = string.Format("{0:c}", TGiren - TCikan);
        }
        public int KasaHareketEkle(Kasa k)
        {
            int sonkayitno = 0;
            SqlCommand comm = new SqlCommand("insert into KasaHareketler (tarih, islemTuru, cariNo, belge, giren, cikan) values(@tarih, @islemTuru, @cariNo, @belge, @giren, @cikan); select Scope_Identity()", conn);
            comm.Parameters.Add("@tarih", SqlDbType.DateTime).Value = k._tarih;
            comm.Parameters.Add("@islemTuru", SqlDbType.VarChar).Value = k._islemTuru;
            comm.Parameters.Add("@cariNo", SqlDbType.Int).Value = k._cariNo;
            comm.Parameters.Add("@belge", SqlDbType.VarChar).Value = k._belge;
            comm.Parameters.Add("@giren", SqlDbType.Money).Value = k._giren;
            comm.Parameters.Add("@cikan", SqlDbType.Money).Value = k._cikan;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonkayitno = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonkayitno;
        }
        public bool KasaHareketSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update KasaHareketler set silindi=1 where ID = @ID", conn);
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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
