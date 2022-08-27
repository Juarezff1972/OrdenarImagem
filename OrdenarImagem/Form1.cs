using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenarImagem
{
    public partial class Form1 : Form
    {
        private Image img;
        private Bitmap bmp;
        private Graphics graph;
        private float ratio;

        public Form1()
        {
            InitializeComponent();
            ratio = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //bmp = new Bitmap(openFileDialog1.FileName);

                Bitmap orig = new Bitmap(openFileDialog1.FileName);
                bmp = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }

                ratio = (float)bmp.Width / (float)bmp.Height;

                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Width = (int)(pictureBox1.Height * ratio);
                button2.Enabled = true;
                orig.Dispose();
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            pictureBox1.Width = (int)(pictureBox1.Height * ratio);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c;
            List<Ponto>[] clr;
            Ponto p;
            int x, y;
            int idx, j;
            int maxidx = 0;

            /*long l1, l2, l3;
            int x1, y1, z1;
            int x2, y2, z2;
            long perim;*/
            clr = new List<Ponto>[16777216];
            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    Cores c1 = new Cores();
                    c = bmp.GetPixel(x, y);
                    p = new Ponto(x, y, c);
                    //idx = c.B + c.G * 256 + c.R * 256 * 256;
                    c1.setCor(c);
                    idx = (int)c1.cinza;
                    if (idx > maxidx) maxidx = idx;
                    // idx = (int)Math.Sqrt(c.B * c.B + c.G * c.G + c.R * c.R);
                    /*x1 = c.B; y1 = 0;   z1 = 0;
                    x2 = 0;   y2 = c.G; z2 = 0;
                    l1 = (long)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (x2 - z1));
                    x1 = 0; y1 = c.G; z1 = 0;
                    x2 = 0; y2 = 0;   z2 = c.R;
                    l2 = (long)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (x2 - z1));
                    x1 = 0;   y1 = 0; z1 = c.R;
                    x2 = c.B; y2 = 0; z2 = 0;
                    l3 = (long)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (x2 - z1));

                    perim = (l1 + l2 + l3);
                    idx = (int)Math.Sqrt(perim * (perim - l1) * (perim - l2) * (perim - l3));*/


                    //idx = ( c.R + c.G + c.B ) / 3;
                    if (clr[idx] == null)
                    {
                        clr[idx] = new List<Ponto>();
                    }
                    clr[idx].Add(p);
                    c = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    bmp.SetPixel( x, y, c );
                }
                Application.DoEvents();
                pictureBox1.Refresh();
            }
            //pictureBox1.Image = bmp;
            x = 0;
            y = 0;
            progressBar1.Maximum = maxidx+1;
            progressBar1.Value = 0;
            for (idx = 0; idx < maxidx+1; idx++)
            {
                if (clr[idx] != null)
                {
                    //c = Color.FromArgb(idx);
                    for (j = 0; j < clr[idx].Count; j++)
                    {
                        c = clr[idx][j].C;
                        bmp.SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B));
                        x++;
                        if (x >= bmp.Width)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
                Application.DoEvents();

                if (idx % 2048 == 0)
                {
                    pictureBox1.Image = bmp;
                    pictureBox1.Refresh();
                }

                //pictureBox1.Refresh();
                progressBar1.Value = idx;
            }
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private Color aplicaFiltro(int x, int y, sbyte[,] filtro1, sbyte[,] filtro2, Bitmap bmp1)
        {
            int i, j;
            int k, l;
            int r1, g1, b1;
            int r2, g2, b2;
            double r, g, b;

            sbyte f1;
            sbyte f2;

            Color c1;
            r1 = 0;
            g1 = 0;
            b1 = 0;
            r2 = 0;
            g2 = 0;
            b2 = 0;

            //t = 0;
            for (i = -1; i < 2; i++)
            {
                for (j = -1; j < 2; j++)
                {
                    k = x + i;
                    l = y + j;
                    if ((k < 0) || (l < 0) || (k >= bmp.Width) || (l >= bmp.Height))
                    {
                        c1 = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        c1 = bmp1.GetPixel(k, l);
                    }
                    f1 = filtro1[i + 1, j + 1];
                    f2 = filtro2[i + 1, j + 1];

                    r1 += (c1.R * f1);// / 4;
                    g1 += (c1.G * f1);// / 4;
                    b1 += (c1.B * f1);// / 4;
                    r2 += (c1.R * f2);// / 4;
                    g2 += (c1.G * f2);// / 4;
                    b2 += (c1.B * f2);// / 4;

                }
            }

            r = Math.Sqrt(r1 * r1 + r2 * r2);
            g = Math.Sqrt(g1 * g1 + g2 * g2);
            b = Math.Sqrt(b1 * b1 + b2 * b2);


            if (r > 255)
                r = 255;
            if (r < 0)
                r = 0;
            if (g > 255)
                g = 255;
            if (g < 0)
                g = 0;
            if (b > 255)
                b = 255;
            if (b < 0)
                b = 0;

            c1 = Color.FromArgb((int)r, (int)g, (int)b);

            return c1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sbyte[,] filtro1;
            sbyte[,] filtro2;
            int x, y;
            Color c;
            Bitmap bmp1;
            filtro1 = new sbyte[3, 3];
            filtro1[0, 0] = 1;
            filtro1[0, 1] = 0;
            filtro1[0, 2] = -1;
            filtro1[1, 0] = 2;
            filtro1[1, 1] = 0;
            filtro1[1, 2] = -2;
            filtro1[2, 0] = 1;
            filtro1[2, 1] = 0;
            filtro1[2, 2] = -1;
            filtro2 = new sbyte[3, 3];
            filtro2[0, 0] = -1;
            filtro2[0, 1] = -2;
            filtro2[0, 2] = -1;
            filtro2[1, 0] = 0;
            filtro2[1, 1] = 0;
            filtro2[1, 2] = 0;
            filtro2[2, 0] = 1;
            filtro2[2, 1] = 2;
            filtro2[2, 2] = 1;
            progressBar1.Maximum = bmp.Width;
            progressBar1.Value = 0;
            bmp1 = new Bitmap(bmp.Width, bmp.Height);

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    bmp1.SetPixel(x, y, bmp.GetPixel(x, y));
                }
            }

            for (x = 0; x < bmp.Width; x++)
            {
                for (y = 0; y < bmp.Height; y++)
                {
                    //c = bmp.GetPixel( x, y );
                    c = aplicaFiltro(x, y, filtro1, filtro2, bmp1);
                    bmp.SetPixel(x, y, c);

                }
                pictureBox1.Image = bmp;
                progressBar1.Value = x;
                pictureBox1.Refresh();
                //pictureBox1.Refresh();
            }
            pictureBox1.Refresh();
        }
    }
}
