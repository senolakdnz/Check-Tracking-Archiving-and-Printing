using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace çek
{
   public class DB
    {
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbCommand komut;
        DataSet verikumesi;

        public void VeriDoldur(DataGridView dgw)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cek.accdb");
            adaptor = new OleDbDataAdapter("Select * From cc", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikumesi, "cc");
            dgw.DataSource = verikumesi.Tables["cc"];
            dgw.Refresh();
            baglanti.Close();
        }

        public void Kaydet(string pkesidetarihi, string pkesideyeri, string pcekno, string pcektutar, string pparabirimi, string palacakli, string pkesideci, string pbankaadi, string pbankasubesi, string pbankahesapno, string pdurum)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into cc(kesidetarihi,kesideyeri,cekno,cektutar,parabirimi,alacakli,kesideci,bankaadi,bankasubesi,bankahesapno,durum)values(@qkesidetarihi,@qkesideyeri,@qcekno,@qcektutar,@qparabirimi,@qalacakli,@qkesideci,@qbankaadi,@qbankasubesi,@qbankahesapno,@qdurum)";
            komut.Parameters.AddWithValue("@qkesidetarihi", pkesidetarihi);
            komut.Parameters.AddWithValue("@qkesideyeri", pkesideyeri);
            komut.Parameters.AddWithValue("@qcekno", pcekno);
            komut.Parameters.AddWithValue("@qcektutar", pcektutar);
            komut.Parameters.AddWithValue("@qparabirimi", pparabirimi);
            komut.Parameters.AddWithValue("@qalacakli", palacakli);
            komut.Parameters.AddWithValue("@qkesideci", pkesideci);
            komut.Parameters.AddWithValue("@qbankaadi", pbankaadi);
            komut.Parameters.AddWithValue("@qbankasubesi", pbankasubesi);
            komut.Parameters.AddWithValue("@qbankahesapno", pbankahesapno);
            komut.Parameters.AddWithValue("@qdurum", pdurum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }

        public void Sil(string pcekno)
        {
            komut = new OleDbCommand();
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(c==DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete from cc where cekno=@qcekno";
                komut.Parameters.AddWithValue("@qcekno", pcekno);
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
            }
        }

        public void Guncelle(string pkesidetarihi, string pkesideyeri, string pcektutar, string pparabirimi, string palacakli, string pkesideci, string pbankaadi, string pbankasubesi, string pbankahesapno, string pdurum, string pguncelle)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE cc SET kesidetarihi=@qkesidetarihi, kesideyeri=@qkesideyeri, cektutar=@qcektutar, parabirimi=@qparabirimi, alacakli=@qalacakli, kesideci=@qkesideci, bankaadi=@qbankaadi, bankasubesi=@qbankasubesi, bankahesapno=@qbankahesapno, durum=@qdurum WHERE cekno=@qcekno";
            komut.Parameters.AddWithValue("@qkesidetarihi", pkesidetarihi);
            komut.Parameters.AddWithValue("@qkesideyeri", pkesideyeri);
            komut.Parameters.AddWithValue("@qcektutar", pcektutar);
            komut.Parameters.AddWithValue("@qparabirimi", pparabirimi);
            komut.Parameters.AddWithValue("@qalacakli", palacakli);
            komut.Parameters.AddWithValue("@qkesideci", pkesideci);
            komut.Parameters.AddWithValue("@qbankaadi", pbankaadi);
            komut.Parameters.AddWithValue("@qbankasubesi", pbankasubesi);
            komut.Parameters.AddWithValue("@qbankahesapno", pbankahesapno);
            komut.Parameters.AddWithValue("@qdurum", pdurum);
            komut.Parameters.AddWithValue("qcekno", pguncelle);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
        }

        public void Arama(string pcekno, DataGridView dgw)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=cek.accdb");
            adaptor = new OleDbDataAdapter("SELECT * From cc WHERE cekno LIKE'" + pcekno + "%'", baglanti);
            verikumesi = new DataSet();
            baglanti.Open();
            adaptor.Fill(verikumesi, "cc");
            dgw.DataSource = verikumesi.Tables["cc"];
            dgw.Refresh();
            baglanti.Close();
        }

        

    }
}
