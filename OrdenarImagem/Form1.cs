using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;

namespace OrdenarImagem
{
    //public delegate void EscritaEventHandler(object sender, EventArgs e);
    //public delegate void MudarEventHandler(object sender, VetorEventArgs e);

    public partial class Form1 : Form
    {
        const string BINARYINSERTIONSORT = "BinaryInsertionSort";
        const string BITONICSORT = "BitonicSort";
        const string BUBBLESORT = "BubbleSort";
        const string BUBBLESORT2 = "BubbleSort2";
        const string BUBBLESORT3 = "BubbleSort3";
        const string COCKTAILSHAKERSORT = "CocktailShakerSort";
        const string COMBSORT = "CombSort";
        const string COUNTINGSORT = "CountingSort";
        const string CYCLESORT = "CycleSort";
        const string FLASHSORT = "FlashSort";
        const string GNOMESORT = "GnomeSort";
        const string HEAPSORT = "HeapSort";
        const string INSERTSORT = "InsertSort";
        const string INSERTSORT2 = "InsertSort2";
        const string MERGESORT = "MergeSort";
        const string ODDEVENSORT = "OddEvenSort";
        const string PANCAKESORT = "PancakeSort";
        const string PIGEONHOLESORT = "PigeonHoleSort";
        const string QUICKSORTDUALPIVOT = "QuickSortDualPivot";
        const string QUICKSORTLL = "QuickSortLL";
        const string QUICKSORTLR = "QuickSortLR";
        const string QUICKSORTTERNARYLR = "QuickSortTernaryLR";
        const string RADIXSORTLSD = "RadixSortLSD";
        const string RADIXSORTMSD = "RadixSortMSD";
        const string SELECTIONSORT = "SelectionSort";
        const string SHELLSORT = "ShellSort";
        const string SLOWSORT = "SlowSort";
        const string AMERICANSORT = "AmericanFlagSort";
        const string SANDPAPERSORT = "SandpaperSort";
        const string DIAMONDSORT = "DiamondSort";

        private int[]? m_array;
        private ArrayItem[]? vetor;
        private Bitmap bmp2;
        LockBitmap lockBitmap2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add(BINARYINSERTIONSORT);
            this.comboBox1.Items.Add(BITONICSORT);
            this.comboBox1.Items.Add(BUBBLESORT);
            this.comboBox1.Items.Add(BUBBLESORT2);
            this.comboBox1.Items.Add(BUBBLESORT3);
            this.comboBox1.Items.Add(COCKTAILSHAKERSORT);
            this.comboBox1.Items.Add(COMBSORT);
            this.comboBox1.Items.Add(COUNTINGSORT);
            this.comboBox1.Items.Add(CYCLESORT);
            this.comboBox1.Items.Add(FLASHSORT);
            this.comboBox1.Items.Add(GNOMESORT);
            this.comboBox1.Items.Add(HEAPSORT);
            this.comboBox1.Items.Add(INSERTSORT);
            this.comboBox1.Items.Add(INSERTSORT2);
            this.comboBox1.Items.Add(MERGESORT);
            this.comboBox1.Items.Add(ODDEVENSORT);
            this.comboBox1.Items.Add(PANCAKESORT);
            this.comboBox1.Items.Add(PIGEONHOLESORT);
            this.comboBox1.Items.Add(QUICKSORTDUALPIVOT);
            this.comboBox1.Items.Add(QUICKSORTLL);
            this.comboBox1.Items.Add(QUICKSORTLR);
            this.comboBox1.Items.Add(QUICKSORTTERNARYLR);
            this.comboBox1.Items.Add(RADIXSORTLSD);
            this.comboBox1.Items.Add(RADIXSORTMSD);
            this.comboBox1.Items.Add(SELECTIONSORT);
            this.comboBox1.Items.Add(SHELLSORT);
            this.comboBox1.Items.Add(SLOWSORT);
            this.comboBox1.Items.Add(AMERICANSORT);
            this.comboBox1.Items.Add(SANDPAPERSORT);
            this.comboBox1.Items.Add(DIAMONDSORT);
            this.comboBox1.Sorted = true;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            Resetar();

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? x;
            Algoritmos algo;

            x = comboBox1.SelectedItem.ToString();
            algo = new Algoritmos(vetor);
            //algo.SetVetor(vetor);
            algo.SetQuickSortPivot(qsPivotSel1.Text);

            button1.Enabled = false;
            button2.Enabled = false;

            //var watch = new System.Diagnostics.Stopwatch();
            this.UseWaitCursor = true;
            this.Cursor = Cursors.WaitCursor;

            //watch.Start();
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();

            Form1.ActiveForm.Text = x;
            switch (x)
            {
                case INSERTSORT:
                    algo.InsertSort();
                    break;

                case SELECTIONSORT:
                    algo.SelectionSort();
                    break;

                case INSERTSORT2:
                    algo.InsertSort2();
                    break;

                case BINARYINSERTIONSORT:
                    algo.BinaryInsertionSort();
                    break;

                case MERGESORT:
                    algo.MergeSort();
                    break;

                case BUBBLESORT:
                    algo.BubbleSort();
                    break;

                case BUBBLESORT2:
                    algo.BubbleSort2();
                    break;

                case BUBBLESORT3:
                    algo.BubbleSort3();
                    break;

                case COCKTAILSHAKERSORT:
                    algo.CocktailShakerSort();
                    break;

                case GNOMESORT:
                    algo.GnomeSort();
                    break;

                case COMBSORT:
                    algo.CombSort();
                    break;

                case ODDEVENSORT:
                    algo.OddEvenSort();
                    break;

                case SHELLSORT:
                    algo.ShellSort();
                    break;

                case QUICKSORTLR:
                    algo.QuickSortLR();
                    break;

                case QUICKSORTLL:
                    algo.QuickSortLL();
                    break;

                case QUICKSORTTERNARYLR:
                    algo.QuickSortTernaryLR();
                    break;

                case QUICKSORTDUALPIVOT:
                    algo.QuickSortDualPivot();
                    break;

                case HEAPSORT:
                    algo.HeapSort();
                    break;

                case RADIXSORTMSD:
                    algo.RadixSortMSD();
                    break;

                case RADIXSORTLSD:
                    algo.RadixSortLSD();
                    break;

                case COUNTINGSORT:
                    algo.CountingSort();
                    break;

                case BITONICSORT:
                    algo.BitonicSort();
                    break;

                case SLOWSORT:
                    algo.SlowSort();
                    break;

                case CYCLESORT:
                    algo.CycleSort();
                    break;

                case PANCAKESORT:
                    algo.PancakeSort();
                    break;

                case FLASHSORT:
                    algo.FlashSort();
                    break;

                case PIGEONHOLESORT:
                    algo.pigeonholeSort();
                    break;

                case AMERICANSORT:
                    algo.AmericanSort();
                    break;

                case SANDPAPERSORT:
                    algo.SandpaperSort();
                    break;

                case DIAMONDSORT:
                    algo.DiamondSort();
                    break;

                default:
                    break;
            }
            //watch.Stop();

            this.Cursor = Cursors.Default;
            this.UseWaitCursor = false;

            button1.Enabled = true;
            button2.Enabled = true;
            timer1.Stop();
            timer1.Enabled = false;
            timer1_Tick(new object(),new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resetar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? x;
            x = comboBox1.SelectedItem.ToString();
            qsPivotSel1.Visible = false;
            if (x != null)
            {
                if (x.StartsWith("Quick"))
                {
                    qsPivotSel1.Visible = true;
                    qsPivotSel1.SelectedIndex = 0;
                }
            }
        }

        /*public virtual void OnEscreveu(object sender, EventArgs e)
        {
            int i;
            Point p;
            Color c;
            if (vetor != null)
            {
                lockBitmap2.LockBits();
                for (i = 0; i < vetor.Length; i++)
                {
                    if (vetor[i]!=null)
                    {
                        p = idx2pt(vetor[i].Valor);
                        c = vetor[i].Cor;
                        lockBitmap2.SetPixel(p.X, p.Y, c);
                    }
                }
                lockBitmap2.UnlockBits();
                pictureBox1.Image = bmp2;
            }
        }*/

        /*public virtual void OnMudar(object sender, VetorEventArgs e)
        {
            int i;
            Point p;
            Color c;
            if (vetor != null)
            {
                lockBitmap2.LockBits();
                p = idx2pt(e.indice);
                c = e.cor;
                lockBitmap2.SetPixel(p.X, p.Y, c);
                lockBitmap2.UnlockBits();
                pictureBox1.Image = bmp2;
                Application.DoEvents();
            }
        }*/

        private Point idx2pt(int idx)
        {
            Point p;
            p = new Point(0, 0);
            int x = idx % pictureBox1.Width;
            int y = idx / pictureBox1.Width;
            p.X = x;
            p.Y = y;
            return p;
        }

        private void Resetar()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int nums = (int)pictureBox1.Width * pictureBox1.Height;
                int i;
                Bitmap bmp;

                Color c;
                Point p;

                Bitmap orig = new(openFileDialog1.FileName);
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }
                pictureBox1.Image = bmp;

                m_array = Enumerable.Range(1, nums - 1).ToArray();
                Random rnd = new();
                m_array = m_array.OrderBy(c => rnd.Next()).ToArray();
                vetor = new ArrayItem[m_array.Length];
                vetor.Initialize();
                progressBar1.Maximum = vetor.Length - 1;
                progressBar1.Value = 0;
                bmp = (Bitmap)pictureBox1.Image;
                LockBitmap lockBitmap = new LockBitmap(bmp);
                lockBitmap2 = new LockBitmap(bmp2);
                lockBitmap.LockBits();
                lockBitmap2.LockBits();
                for (i = 0; i < vetor.Length; i++)
                {
                    p = idx2pt(m_array[i]);
                    c = lockBitmap.GetPixel(p.X, p.Y);

                    vetor[i] = new ArrayItem
                    {
                        Indice = i
                    };

                    vetor[i].Valor = m_array[i];
                    vetor[i].Cor = c;
                    p = idx2pt(i);
                    lockBitmap2.SetPixel(p.X, p.Y, c);
                    progressBar1.Value = i;
                    //if (p.X >= pictureBox1.Width-1) pictureBox1.Image = bmp2;
                }
                //for (i = 0; i < vetor.Length; i++)
                //{
                    //EscritaEventHandler d1 = new EscritaEventHandler(OnEscreveu);
                    //MudarEventHandler d2 = new MudarEventHandler(OnMudar);
                    //vetor[i].Escreveu += d1;
                    //vetor[i].Mudar += d2;
                //}
                lockBitmap.UnlockBits();
                lockBitmap2.UnlockBits();
                pictureBox1.Image = bmp2;

                ArrayItem? zzz = vetor.Max();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
            int segmentos;
            Color c;
            Point p;

            if (vetor != null)
            {
                segmentos = 0;
                progressBar1.Maximum = vetor.Length;
                lockBitmap2.LockBits();
                for (i = 0; i < vetor.Length; i++)
                {
                    if (i<vetor.Length-1)
                    {
                        if (vetor[i + 1].Valor < vetor[i].Valor)
                        {
                            segmentos++;
                        }
                    }
                    p = idx2pt(vetor[i].Indice);
                    c = vetor[i].Cor;
                    lockBitmap2.SetPixel(p.X, p.Y, c);
                }
                progressBar1.Value = vetor.Length - segmentos - 1;
                pictureBox1.Image = bmp2;
                lockBitmap2.UnlockBits();
            }
            
        }
    }
}