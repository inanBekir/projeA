using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace projeA
{

    public partial class Form1 : Form
    {
        string resimYolu;
        string resimAdi;
  
        private SerialPort sp = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
       



        private int mx , my;
        private Graphics g;
        private Pen _pencil2 = new Pen(Color.Green, 2);
        private Pen _pencil = new Pen(Color.Red,2);


        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {

                pictureBox1.Image = Image.FromFile("D:\\Downloads\\abc.jpg");
            }

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.Open();
            


            label1.Text = "Port Açık";
            MessageBox.Show("Port Açıldı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
             
                label1.Text = "Port Kapalı";
                MessageBox.Show("Port Kapatıldı");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {

                sp.Write(textBox1.Text);

            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {

            int counter = 0;
            string line,line2;

           // while (true)
           // {




                try
                {

                    string message = sp.ReadLine();
                    textBox2.Text = message;
                    sp.ReadTimeout = 500;


                }
                catch (TimeoutException)
                {

                }

           // }


            StreamReader file = new StreamReader("F:/Visual Studio 2017/Projects/projeA/xKoordinatlar.gsr");
            StreamReader file2 = new StreamReader("F:/Visual Studio 2017/Projects/projeA/yKoordinatlar.gsr");

            
              
           
            while ((line = file.ReadLine()) != null)
            {
                
                if (line.Contains(textBox2.Text))
                {
                    line2 = file2.ReadLine();

                    if (line.Contains("=1"))
                    {
                        line = file.ReadLine();
                        line2 = file2.ReadLine();
                        if (line.Contains("0") || line.Contains("1") || line.Contains("2")
                        || line.Contains("3") || line.Contains("4") || line.Contains("5")
                        || line.Contains("6") || line.Contains("7") || line.Contains("8") || line.Contains("9"))
                        {
                            g = pictureBox1.CreateGraphics();

                            g.DrawRectangle(_pencil2, Convert.ToInt32(line)-40, Convert.ToInt32(line2)-40, 95, 105);
                        }
                    }
                    else if (line.Contains("=0"))
                    {
                        line = file.ReadLine();
                        line2 = file2.ReadLine();
                        if (line.Contains("0") || line.Contains("1") || line.Contains("2")
                        || line.Contains("3") || line.Contains("4") || line.Contains("5")
                        || line.Contains("6") || line.Contains("7") || line.Contains("8") || line.Contains("9"))
                        {
                            g = pictureBox1.CreateGraphics();

                            g.DrawRectangle(_pencil, Convert.ToInt32(line)-40, Convert.ToInt32(line2)-40, 95, 105);
                        }
                    }
                    

               

                counter++;
                }
            }
            file.Close();
            file2.Close();


            //Console.WriteLine(buffer.ToString());


            /*while ((line = file.ReadLine()) != null)
            {
                List<string> deneme = new List<string>();
                deneme.Add(line);

               

                if (line.Contains(textBox2.Text))
                {
                    g = pictureBox1.CreateGraphics();

                    g.DrawRectangle(_pencil, , my - 40, 95, 105);
                }
                else
                {
                    Console.WriteLine(line);
                    Console.WriteLine("Naber Ortak2");
                }
                

                counter++;
            }

            file.Close();

            Console.ReadLine();*/






        }

       

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
            "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                resimYolu = dialog.FileName;
                resimAdi = dialog.SafeFileName;
                resim.ImageLocation = resimYolu;

            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {


            

            g = resim.CreateGraphics();

            g.DrawRectangle(_pencil, mx - 40, my - 40, 95, 105);

            var jpeg = new JpegMetadataAdapter(resimYolu);

            string koordinatBilgisi = "";

            
                koordinatBilgisi = "Pin  X : " + mx + " Y : " + my + "\n";
            
            jpeg.Metadata.Comment = koordinatBilgisi;
            jpeg.Metadata.Title = "Koordinatlar \n";
            // jpeg.Save();            // Resmin kendisine kayıt etme istenirse yapılabilir.

            string gsrYol = @"D:\Downloads\TezOdev" + resimAdi + " GsrDosyası.gsr";     //kaydedeceğimiz GSR Dosyasının yolunu belirle

            jpeg.SaveAs(gsrYol);     // GSR Dosyası olarak kaydet
            
            MessageBox.Show("GSR Dosyası Başarıyla Kaydedildi.");

        }

        public class JpegMetadataAdapter
        {
            private readonly string path;
            private BitmapFrame frame;
            public readonly BitmapMetadata Metadata;

            public JpegMetadataAdapter(string path)
            {
                this.path = path;
                frame = getBitmapFrame(path);
                Metadata = (BitmapMetadata)frame.Metadata.Clone();
            }

            public void Save()
            {
                SaveAs(path);
            }

            public void SaveAs(string path)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(frame, frame.Thumbnail, Metadata, frame.ColorContexts));
                using (Stream stream = File.Open(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    encoder.Save(stream);
                }
            }

            private BitmapFrame getBitmapFrame(string path)
            {
                BitmapDecoder decoder = null;
                using (Stream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
                return decoder.Frames[0];
            }
        }

        private void resim_MouseClick(object sender, MouseEventArgs e)
        {
            mx = e.X - 5;
            my = e.Y - 5;
            
           

            g = resim.CreateGraphics();

            g.DrawRectangle(_pencil, mx - 40, my - 40, 95, 105);

            StreamWriter sw = File.AppendText("F:/Visual Studio 2017/Projects/projeA/abc.jpg");
            StreamWriter sw2 = File.AppendText("F:/Visual Studio 2017/Projects/projeA/xKoordinatlar.gsr");
            StreamWriter sw3 = File.AppendText("F:/Visual Studio 2017/Projects/projeA/yKoordinatlar.gsr");
            sw.WriteLine("x: "+" "+mx+" " +"y: "+" "+my);
            sw2.WriteLine(mx);
            sw3.WriteLine(my);

            sw.Close();
            sw2.Close();
            sw3.Close();
            


        }

    }
}