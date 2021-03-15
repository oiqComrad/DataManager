using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataManager
{
    /// <summary>
    /// Класс - форма для настроек нового датасета.
    /// 
    /// </summary>
    public partial class DataBaseSettings : Form
    {
        // Путь файла.
        public string filename;
        // Закрыта ли форма (для избежания StackOverflow ошибки).
        public bool formClosed = false;
        // Знак разделитель.
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

        /// <summary>
        /// Задать путь файла можно вручную, написан текст в textbox,
        /// А можно задать через диалог, нажав на знаком директории.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// Выбор знака разделителя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBaseSettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!formClosed)
            {
                formClosed = true;
                filename = null;
                this.Close();
            }
        }
        /// <summary>
        /// Сохранение настроек и закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик нажатия Enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBaseSettingsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
