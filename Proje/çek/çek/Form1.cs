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


namespace çek
{
    public partial class Form1 : Form

    {
        
        public Form1()
        {
            InitializeComponent();
 }


        

  private void Form1_Load(object sender, EventArgs e)
        {
          
        }
      

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Parola" && textBox2.ForeColor == Color.Gray)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.DarkRed;
            }
            textBox1.SelectionLength = 0;
            textBox2.SelectionLength = 0;

        }
        public static string gonderilecekveri;

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Fırat University" && textBox2.Text == "2022")
            {

                Form2 frm1 = new Form2();
                this.Hide();
                frm1.Show();
     }
            else


            {
                MessageBox.Show("Hatalı Giriş");
            }

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.DarkSlateGray;
            Font myfont = new Font("Times Roman", 15);
            textBox2.Font = myfont;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
        }

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.DarkSlateGray;
            Font myfont = new Font("Times Roman", 13);
            textBox1.Font = myfont;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
        }
    }
}           
