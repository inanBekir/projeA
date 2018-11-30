using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                pBox_urunler.Image = Image.FromFile("D:\\Downloads\\eia-tia-561-db25.jpg");
            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void pBox_urunler_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g;

            g = pBox_urunler.CreateGraphics();

            Pen pencil=new Pen(Color.Red,2);
           
            g.DrawEllipse(pencil,e.X-5,e.Y-5,10,16);
        }
    }
}