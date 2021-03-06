using AI_Draw.Perceptron;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AI_Draw
{
    public partial class Form1 : Form
    {
        private TrainableMLP mlp;
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
            int sizeX = pictureBox1.Image.Width, sizeY = pictureBox1.Image.Height;

            int[,] matr_results = new int[sizeX - 8, sizeY - 8];

            for (int i = 0; i < sizeX - 8; i++)
            {
                for (int j = 0; j < sizeY - 8; j++)
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
                    matr_results[i, j] = Array.IndexOf(output, output.Max());
                }
                progressBar.Value = (int)Math.Ceiling(100 * i / (sizeX - 8 * 1.0));
            }

            pictureBox2.Size = new Size(sizeX, sizeY);
            pictureBox2.Image = new Bitmap(sizeX, sizeY);

            using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            {
                Pen p = new Pen(Color.FromArgb(50, 0, 0, 0), (float)0.1);
                g.Clear(Color.White);
                for (int i = 0; i < matr_results.GetLength(0); i++)
                {
                    for (int j = 0; j < matr_results.GetLength(1); j++)
                    {
                        if (matr_results[i, j] == 0 || matr_results[i, j] == 5)
                            g.DrawLine(p, i, j + 4, i + 8, j + 4);

                        if (matr_results[i, j] == 1 || matr_results[i, j] == 6)
                            g.DrawLine(p, i + 4, j, i + 4, j + 8);

                        if (matr_results[i, j] == 2 || matr_results[i, j] == 7)
                            g.DrawLine(p, i, j, i + 8, j + 8);

                        if (matr_results[i, j] == 3 || matr_results[i, j] == 8)
                            g.DrawLine(p, i, j + 8, i + 8, j);

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

        private void CreatePerceptronButton_Click(object sender, EventArgs e)
        {
            List<int> lengths = new List<int>();
            lengths.Add(64);
            foreach (var t in LayersTextBox.Text.Split(' ', ','))
            {
                if (string.IsNullOrEmpty(t))
                    continue;
                lengths.Add(int.Parse(t));
            }
            lengths.Add(10);

            mlp = new TrainableMLP(lengths.ToArray());
        }

        private void StartLearningButton_Click(object sender, EventArgs e)
        {
            int count = int.Parse(CountTextBox.Text);
            mlp.Train(train_input, train_output, count, progressBar);
        }

        private void GetErrorButton_Click(object sender, EventArgs e)
        {
            ErrorText.Text = mlp.GetMeanSquaredError(train_input, train_output).ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            mlp.RandomW();
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

                    progressBar.Value = (int)Math.Ceiling(100.0 * i / files.Length);
                }
            }
        }
    }
}
