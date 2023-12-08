namespace OrdenarImagem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            qsPivotSel1 = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(640, 360);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // qsPivotSel1
            // 
            qsPivotSel1.BackColor = Color.DarkGray;
            qsPivotSel1.DropDownStyle = ComboBoxStyle.DropDownList;
            qsPivotSel1.FormattingEnabled = true;
            qsPivotSel1.Items.AddRange(new object[] { "Primeiro", "Último", "Médio", "Aleatório", "Mediana" });
            qsPivotSel1.Location = new Point(11, 403);
            qsPivotSel1.Margin = new Padding(3, 2, 3, 2);
            qsPivotSel1.Name = "qsPivotSel1";
            qsPivotSel1.Size = new Size(133, 23);
            qsPivotSel1.TabIndex = 34;
            qsPivotSel1.Visible = false;
            // 
            // button2
            // 
            button2.ImeMode = ImeMode.NoControl;
            button2.Location = new Point(238, 377);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 33;
            button2.Text = "Resetar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(150, 377);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 32;
            button1.Text = "Iniciar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.DarkGray;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "BinaryInsertionSort", "BitonicSort", "BubbleSort", "BubbleSort2", "BubbleSort3", "CocktailShakerSort", "CombSort", "CountingSort", "CycleSort", "FlashSort", "GnomeSort", "GravitySort", "HeapSort", "InsertSort", "InsertSort2", "MergeSort", "OddEvenSort", "PancakeSort", "PigeonHoleSort", "QuickSortDualPivot", "QuickSortLL", "QuickSortLR", "QuickSortTernaryLR", "RadixSortLSD", "RadixSortMSD", "SelectionSort", "ShellSort", "SlowSort" });
            comboBox1.Location = new Point(11, 378);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 23);
            comboBox1.Sorted = true;
            comboBox1.TabIndex = 31;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Arquivos jpg|*.jpg";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(11, 431);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(641, 22);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 35;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(664, 462);
            Controls.Add(progressBar1);
            Controls.Add(qsPivotSel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        public ComboBox qsPivotSel1;
        private Button button2;
        private Button button1;
        private ComboBox comboBox1;
        private OpenFileDialog openFileDialog1;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}