using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Drawing.Printing;
namespace çek
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
       //     button1.Text = "yazdır";
         //   button1.Click += new EventHandler(button1.Text);
         //   printDocument2.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
           // this.Controls.Add(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            ff.Show();
            this.Hide();

         
        }
        

    
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.groupBox1.Width, this.groupBox1.Height);
            groupBox1.DrawToBitmap(bm, new Rectangle(0, 0, this.groupBox1.Width, this.groupBox1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            printDialog1.Document = printDocument2;
            
                printDialog1.ShowDialog();

                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    printDocument2.Print();
           
           
        }

        /*/   Bitmap memoryImage;

       private void CaptureScreen()
       {
           Graphics myGraphics = this.CreateGraphics();
           Size s = this.Size; 
           memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
           Graphics memoryGraphics = Graphics.FromImage(memoryImage);
           memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0,0, s);
       }

       private void printDocument2_PrintPage(System.Object sender,
              System.Drawing.Printing.PrintPageEventArgs e)
       {
           e.Graphics.DrawImage(memoryImage, 0, 0);
       }
    /*/

    }
}

