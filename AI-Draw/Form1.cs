using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AI_Draw
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private MLP mlp;
        private double[][] train_input;
        private double[][] train_output;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap image = new Bitmap(open_dialog.FileName);
                    pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            int size1 = pictureBox1.Image.Width, size2 = pictureBox1.Image.Height;
            int[,] matr_results = new int[size2 - 8, size1 - 8];
            pictureBox2.Size = new Size(size1, size2);
            pictureBox2.Image = new Bitmap(size1, size2);

            for (int i = 0; i < size1 - 8; i++)
            {
                for (int j = 0; j < size2 - 8; j++)
                {
                    double[] input = new double[64];
                    for (int i0 = 0; i0 < 8; i0++)
                    {
                        for (int i1 = 0; i1 < 8; i1++)
                        {
                            input[8 * i0 + i1] = (((Bitmap)pictureBox1.Image).GetPixel(i + i0, j + i1).R / 255.0) * 2 - 1;
                        }
                    }

                    double[] output = mlp.Predict(input);
                    matr_results[j, i] = Array.IndexOf(output, output.Max());
                }
            }

            using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            {

                Pen p = new Pen(Color.FromArgb(50, 0, 0, 0), (float)0.1);
                g.Clear(Color.White);
                for (int i = 0; i < matr_results.GetLength(0); i++)
                {
                    for (int j = 0; j < matr_results.GetLength(1); j++)
                    {
                        //if (i == 50) { label3.Text += matr_results[i, j] + " "; }
                        if (matr_results[i, j] == 0 || matr_results[i, j] == 5) { int k = i; i = j; j = k; g.DrawLine(p, i, j + 4, i + 8, j + 4); k = i; i = j; j = k; }
                        if (matr_results[i, j] == 1 || matr_results[i, j] == 6) { int k = i; i = j; j = k; g.DrawLine(p, i + 4, j, i + 4, j + 8); k = i; i = j; j = k; }
                        if (matr_results[i, j] == 2 || matr_results[i, j] == 7) { int k = i; i = j; j = k; g.DrawLine(p, i, j + 8, i + 8, j); k = i; i = j; j = k; }
                        if (matr_results[i, j] == 3 || matr_results[i, j] == 8) { int k = i; i = j; j = k; g.DrawLine(p, i, j, i + 8, j + 8); k = i; i = j; j = k; }
                        if (matr_results[i, j] == 4 || matr_results[i, j] == 9) { }


                    }
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                pictureBox2.Image.Save(dialog.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void ReadDataButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);
                FileInfo[] files = info.GetFiles();
                train_input = new double[files.Length][];
                train_output = new double[files.Length][];

                for (int i = 0; i < files.Length; i++)
                {
                    train_input[i] = new double[64];
                    Image image = Image.FromFile(files[i].FullName);

                    for (int i0 = 0; i0 < 8; i0++)
                    {
                        for (int i1 = 0; i1 < 8; i1++)
                        {
                            train_input[i][i0 * 8 + i1] = (((Bitmap)image).GetPixel(i0, i1).R / 255.0) * 2 - 1;
                        }
                    }

                    train_output[i] = new double[10];
                    string[] splited_name = files[i].Name.Split(' ', '.');

                    for (int j = 0; j < 10; j++)
                    {
                        train_output[i][j] = int.Parse(splited_name[j + 1]);
                    }
                }
                int[] lengths = new int[] { 64, 10 };
                mlp = new MLP(lengths, train_input, train_output);
            }
        }

        private void StartLearningButton_Click(object sender, EventArgs e)
        {
            int count = int.Parse(CountTextBox.Text);
            mlp.Train(count);
        }

        private void GetErrorButton_Click(object sender, EventArgs e)
        {
            ErrorText.Text = mlp.GetErr().ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            mlp.RandomW();
        }
    }
}
