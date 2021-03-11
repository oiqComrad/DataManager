using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataManager
{
    public partial class DataBaseSettings : Form
    {
        public static string filename = "";
        public DataBaseSettings()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(255, 37, 37, 38);
            textBox1.BackColor = Color.FromArgb(255, 51, 51, 55);
            pictureBox1.BackColor = this.BackColor;
            // pictureBox2.BackColor = Color.FromArgb(255, 63, 63, 70);
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

    }
}
