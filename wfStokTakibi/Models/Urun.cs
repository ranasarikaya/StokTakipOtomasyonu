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
    class Urun
    {
        private int _urunID;
        private string _urunKodu;
        private string _urunAd;
        private int _kategoriNo;
        private int _miktar;
        private int _kritikSeviye;
        private double _birimFiyat;

        #region Properties
        public int UrunID
        {
            get
            {
                return _urunID;
            }

            set
            {
                _urunID = value;
            }
        }

        public string UrunKodu
        {
            get
            {
                return _urunKodu;
            }

            set
            {
                _urunKodu = value;
            }
        }

        public string UrunAd
        {
            get
            {
                return _urunAd;
            }

            set
            {
                _urunAd = value;
            }
        }

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

        public int Miktar
        {
            get
            {
                return _miktar;
            }

            set
            {
                _miktar = value;
            }
        }

        public int KritikSeviye
        {
            get
            {
                return _kritikSeviye;
            }

            set
            {
                _kritikSeviye = value;
            }
        }

        public double BirimFiyat
        {
            get
            {
                return _birimFiyat;
            }

            set
            {
                _birimFiyat = value;
            }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


        public DataSet UrunleriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select UrunKodu,UrunAd,KategoriAd,Miktar,birimfiyat,kritikseviye,Kategoriler.kategoriNo,UrunID from Urunler  inner join Kategoriler on Urunler.KategoriNo =Kategoriler.kategoriNo where urunler.silindi=0 ", conn);
            try
            {
                da.Fill(ds, "Urunler");

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;

        }
        public void UrunleriGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu,UrunAd,KategoriAd,Miktar,birimfiyat,kritikseviye,Kategoriler.kategoriNo,UrunID from Urunler  inner join Kategoriler on Urunler.KategoriNo =Kategoriler.kategoriNo where urunler.silindi=0 ", conn);
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
        }

        public void UrunleriGetirByAdaGore(string ad, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu,UrunAd,KategoriAd,Miktar,birimfiyat,kritikseviye,Kategoriler.kategoriNo,UrunID from Urunler  inner join Kategoriler on Urunler.KategoriNo =Kategoriler.kategoriNo where urunler.silindi=0 and UrunAd like @UrunAd ", conn);
            comm.Parameters.Add("UrunAd", SqlDbType.VarChar).Value = ad + "%";
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
        }
        public  bool UrunKontrol(string Kod, string Adi)
        { bool sonuc = false;
            SqlCommand comm = new SqlCommand("Select count(*) from Urunler where UrunAd=@urunadi and UrunKodu=@urunKod and silindi=0",conn );
            comm.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = Adi;
            comm.Parameters.Add("@urunkod", SqlDbType.VarChar).Value = Kod;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                int sayisi = Convert.ToInt32(comm.ExecuteScalar());
                if (sayisi >0)
                {
                    sonuc = true;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }finally
            {
                conn.Close();
            }
            return sonuc;
        }

        public bool UrunKontrol(string Kod, string Adi, int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Select count(*) from Urunler where UrunAd=@urunadi and UrunKodu=@urunKod and urunID != @urunID and silindi=0", conn);
            comm.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = Adi;
            comm.Parameters.Add("@urunkod", SqlDbType.VarChar).Value = Kod;
            comm.Parameters.Add("@urunID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                int sayisi = Convert.ToInt32(comm.ExecuteScalar());
                if (sayisi > 0)
                {
                    sonuc = true;
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
            return sonuc;
        }
        public int KacinciUrun(int ID)
        {
            int kacinci = 0;
            SqlCommand comm = new SqlCommand("select count(*) from Urunler where silindi=0 and urunID < @urunID", conn);
            comm.Parameters.Add("@urunID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                kacinci = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }finally
            {
                conn.Close();
            }
            return kacinci;
        }

        public void UrunleriGetirByKodaGore(string Kod, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu,UrunAd,KategoriAd,Miktar,birimfiyat,kritikseviye,Kategoriler.kategoriNo,UrunID from Urunler  inner join Kategoriler on Urunler.KategoriNo =Kategoriler.kategoriNo where urunler.silindi=0 and UrunKodu like @UrunAd ", conn);
            comm.Parameters.Add("UrunAd", SqlDbType.VarChar).Value = Kod + "%";
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
        }
        public bool UrunEkle(Urun u)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Insert Into Urunler (urunkodu,urunad,kategorino,kritikseviye,birimfiyat) values(@urunkodu,@urunad,@kategorino,@kritikseviye,@birimfiyat)", conn);
            comm.Parameters.Add("@urunKodu", SqlDbType.VarChar ).Value = u._urunKodu;
            comm.Parameters.Add("@urunAd", SqlDbType.VarChar ).Value = u._urunAd ;
            comm.Parameters.Add("@kategorino", SqlDbType.Int).Value = u._kategoriNo;
            comm.Parameters.Add("@kritikSeviye", SqlDbType.Int).Value = u._kritikSeviye ;
            comm.Parameters.Add("@birimFiyat", SqlDbType.Money).Value = u._birimFiyat;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }finally { conn.Close(); }
            return sonuc;
        }
        public bool UrunGuncelle(Urun u)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler set urunkodu=@urunkodu,urunad=@urunad,kategorino=@kategorino,kritikseviye=@kritikseviye,birimfiyat=@birimfiyat where urunID=@urunID", conn);
            comm.Parameters.Add("@urunKodu", SqlDbType.VarChar).Value = u._urunKodu;
            comm.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunAd;
            comm.Parameters.Add("@kategorino", SqlDbType.Int).Value = u._kategoriNo;
            comm.Parameters.Add("@kritikSeviye", SqlDbType.Int).Value = u._kritikSeviye;
            comm.Parameters.Add("@birimFiyat", SqlDbType.Money).Value = u._birimFiyat;
            comm.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;
        }
        public bool UrunSil(int ID)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler set silindi=1 where urunID=@urunID", conn);
            comm.Parameters.Add("@urunID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;
        }
        public bool UrunStokGuncelle(int urunID, int Adet, string islemTuru)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler set Miktar = Miktar + @Adet where urunID=@urunID", conn);
            if (islemTuru == "Stok Çıkış") Adet = (-1) * Adet;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = Adet;
            comm.Parameters.Add("@urunID", SqlDbType.Int).Value = urunID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonuc;
        }
    }
}
