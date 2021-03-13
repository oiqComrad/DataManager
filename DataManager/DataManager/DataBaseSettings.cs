using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataManager
{
    public partial class DataBaseSettings : Form
    {
        public string filename;
        public bool formClosed = false;
        public string separator = ",";
        public bool firstRowContainesColumnsName = true;

        public DataBaseSettings()
        {
            InitializeComponent();
            this.MaximumSize = new Size(520, 360);
            this.MinimumSize = this.MaximumSize;
            this.BackColor = Color.FromArgb(255, 37, 37, 38);
            textBox1.BackColor = Color.FromArgb(255, 51, 51, 55);
            button1.BackColor = textBox1.BackColor;
            pictureBox1.BackColor = this.BackColor;
            this.KeyPreview = true;
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            var currentCb = (CheckBox)sender;
            if (currentCb.Name == "checkBox1")
            {
                checkBox2.Checked = checkBox1.Checked == true ? false : true;
                if (checkBox1.Checked == false)
                    separator = ";";
                else
                    separator = ",";
            }
            else {
                checkBox1.Checked = checkBox2.Checked == true ? false : true;
                if (checkBox1.Checked == false)
                    separator = ";";
                else
                    separator = ",";
            }
        }

        private void DataBaseSettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!formClosed)
            {
                formClosed = true;
                filename = null;
                this.Close();
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите путь файла", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            filename = textBox1.Text;
            if (!formClosed)
            {
                formClosed = true;
                this.Close();
            }
        }

        private void DataBaseSettingsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
