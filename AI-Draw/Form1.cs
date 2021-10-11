using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_Draw
{
    public partial class Form1 : Form
    {
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

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(dialog.FileName+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void ReadDataButton_Click(object sender, EventArgs e)
        {

        }

        private void StartLearningButton_Click(object sender, EventArgs e)
        {

        }

        private void GetErrorButton_Click(object sender, EventArgs e)
        {

        }
    }
}
