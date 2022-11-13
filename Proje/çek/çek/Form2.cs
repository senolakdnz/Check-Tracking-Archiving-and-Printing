using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;

namespace çek
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           

        }
        

        DB DBclass = new DB();
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
            this.Hide();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         //label19.Text = Form1.gon; 
           DBclass.VeriDoldur(dataGridView1);
           string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);
            DateTime tarih = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD'] / ForexSelling").InnerXml;
            label13.Text = string.Format("1 USD ; {1} / TL", tarih.ToShortDateString(), USD);

            string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR'] / ForexSelling").InnerXml;
            label15.Text = string.Format("1 EUR ; {1} / TL", tarih.ToShortDateString(), EURO);

            string STERLİN = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='GBP'] / ForexSelling").InnerXml;
            label16.Text = string.Format("1 GBP ; {1} / TL", tarih.ToShortDateString(), STERLİN);

            string RİYAL = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='SAR'] / ForexSelling").InnerXml;
            label17.Text = string.Format("1 SAR ; {1} / TL", tarih.ToShortDateString(), RİYAL);

            string YEN = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='JPY'] / ForexSelling").InnerXml;
            label18.Text = string.Format("1 JPY ; {1} / TL", tarih.ToShortDateString(), YEN);

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
            DBclass.Kaydet(maskedTextBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text="", textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
            DBclass.VeriDoldur(dataGridView1);
            maskedTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.DataSource = null;
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
           }
                private void button3_Click(object sender, EventArgs e)
           {
            DBclass.Sil(textBox3.Text);
            DBclass.VeriDoldur(dataGridView1);
            maskedTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = " ";
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

                 private void button4_Click(object sender, EventArgs e)
        {
            DBclass.Guncelle(maskedTextBox1.Text, textBox2.Text, textBox4.Text, comboBox1.Text="", textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox3.Text);
            DBclass.VeriDoldur(dataGridView1);
            maskedTextBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = " ";
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            int kayitsayisi,k;
            k = dataGridView1.RowCount;
            kayitsayisi = dataGridView1.RowCount;
          
            if(kayitsayisi==k)
            {
                kayitsayisi=kayitsayisi-1 ;
           
            }
            MessageBox.Show(+kayitsayisi + " adet kayıt sayısı bulunmaktadır.");
            
          
        }   
        
          private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DBclass.Arama(textBox12.Text, dataGridView1);
        }



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

          Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0,0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

          //  e.Graphics.(dataGridView1.Rows, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100);

            //Font yenifont = new Font("Times New Roman", 14, FontStyle.Regular);
          //  e.Graphics.DrawString(textBox1.Text, yenifont, Brushes.Black, 100, 100);

          

        }

        private void button8_Click(object sender, EventArgs e)
        {
          if (printPreviewDialog1.ShowDialog()== DialogResult.OK)
                    printDocument1.Print(); 
          

          
            //printDialog1.Document = printDocument1;
           // printDialog1.ShowDialog();

            

          /*/  printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();/*/

        }

        
        private void button6_Click(object sender, EventArgs e)
        {

            Form3 frm2 = new Form3();
            frm2.Show();
            this.Hide();
            

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {
                MessageBox.Show("Sayı Giriniz");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {
                MessageBox.Show("Sayı Giriniz");
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {
                MessageBox.Show("Sayı Giriniz");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            {

                DialogResult Cikis;
                Cikis = MessageBox.Show("Program Kapatılacak Emin siniz?", "Kapatma Uyarısı!", MessageBoxButtons.YesNo);
                if (Cikis == DialogResult.Yes)
                {
                    Application.Exit();
                }
                if (Cikis == DialogResult.No)
                {
                    Application.Run();
                }

            }
        }

       
    }
}

