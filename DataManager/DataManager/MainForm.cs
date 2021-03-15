using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace DataManager
{
    public partial class MainForm : Form
    {
        string label1 = "Среднее значение: ";
        string label2 = "Медиана: ";
        string label3 = "Среднеквадратичное отклонение: ";
        string label4 = "Дисперсия: ";


        // Отслеживать зажатие шифта.
        bool shiftPress = false;
        // Список выбранных столбцов.
        List<int> selectColumns;
        public MainForm()
        {
            InitializeComponent();
            dataBaseView.CellMouseLeave += (sender, e) => dataBaseView.Cursor = Cursors.Default;
            loadDataBase.Click += LoadDataBaseClickHandle;
            selectColumns = new List<int>();
            this.KeyPreview = true;
            // Добавление обработчиков событий.
            this.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    shiftPress = true;
            };

            this.KeyUp += delegate (object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    shiftPress = false;
            };
            drawHist.Click += DrawHistogram;
            drawFunc.Click += DrawChart;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку загрузки нового датасета.
        /// Если в dataGridView уже был загружен датасент, то он сотрется.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDataBaseClickHandle(object sender, EventArgs e)
        {
            DataBaseSettings dataBaseSettings = new DataBaseSettings();
            dataBaseSettings.ShowDialog();
            // Если форма создания датасета была закрыта.
            if (dataBaseSettings.filename == null) return;
            try
            {
                dataBaseView.Columns.Clear();
                // Считывание csv файла.
                var dataTable = CsvImport.NewDataTable(dataBaseSettings.filename, dataBaseSettings.separator,
                    dataBaseSettings.firstRowContainesColumnsName);
                dataBaseView.DataSource = dataTable;
                // Настройка столбцов.
                for (var column = 0; column < dataBaseView.Columns.Count; column++)
                {
                    dataBaseView.Columns[column].HeaderCell.ContextMenuStrip = contextMenuStrip1;
                    dataBaseView.Columns[column].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataBaseView.Columns[column].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                    dataBaseView.Columns[column].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            catch (SystemException exception)
            {
                MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataBaseSettings.Dispose();
        }

        /// <summary>
        /// Обработчик нажатия на заголовок столбца.
        /// При нажатии на заголовок столбца выделяется столбец целиком.
        /// Также, если столбец содержит числовые данные, будут показаны нужные характеристики (среднее, дисперсия и т.д).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBaseViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlsUpdate.BeginControlUpdate(this);
            // Если столбец выделен не через шифт.
            if (!shiftPress)
            {
                dataBaseView.ClearSelection();
                selectColumns.Clear();
            }
            // Если столбец содержит числовые данные.
            bool flag = true;
            for (var row = 0; row < dataBaseView.RowCount; row++)
            {
                dataBaseView[e.ColumnIndex, row].Selected = true;
                if (!double.TryParse(dataBaseView[e.ColumnIndex, row].Value.ToString().Replace(".", ","), out double number))
                    flag = false;

            }
            toolStripLabel1.Visible = false;
            toolStripLabel2.Visible = false;
            toolStripLabel3.Visible = false;
            toolStripLabel4.Visible = false;
            if (flag)
                ShowStats(e.ColumnIndex);
            dataBaseView.Columns[e.ColumnIndex].Selected = true;
            selectColumns.Add(e.ColumnIndex);
            ControlsUpdate.EndControlUpdate(this);
        }

        /// <summary>
        /// Отображает на форме характеристики числового столбца.
        /// </summary>
        /// <param name="columnIndex"></param>
        private void ShowStats(int columnIndex)
        {
            toolStripLabel1.Visible = true;
            toolStripLabel2.Visible = true;
            toolStripLabel3.Visible = true;
            toolStripLabel4.Visible = true;
            List<double> numbers = new List<double>();
            for (var row = 0; row < dataBaseView.RowCount; row++)
                numbers.Add(double.Parse(dataBaseView[columnIndex, row].Value.ToString().Replace(".", ",")));
            numbers.Sort();
            double avg = 1.0 * numbers.Sum() / numbers.Count;
            toolStripLabel1.Text = label1 + avg.ToString("f2");
            toolStripLabel2.Text = label2 + numbers[numbers.Count / 2].ToString("f2");
            double disp = numbers.Sum(x => (x - avg) * (x - avg)) / numbers.Count;
            toolStripLabel4.Text = label3 + disp.ToString("f2");
            toolStripLabel3.Text = label4 + Math.Sqrt(disp).ToString("f2");
            
        }

        /// <summary>
        /// Изменяет курсор при наведении на конкретный участок формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBaseViewCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
                dataBaseView.Cursor = Cursors.PanSouth;
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
                dataBaseView.Cursor = Cursors.PanEast;
        }

        /// <summary>
        /// Метод вызывает форму с отрисовкой графиков и гистограмм.
        /// Выполняются все необходимые проверки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawHistogram(object sender, EventArgs e)
        {
            try
            {
                int currentColumn = dataBaseView.SelectedCells[0].ColumnIndex;
                List<string> data = new List<string>();
                for (var item = 0; item < dataBaseView.SelectedCells.Count; item++)
                {
                    if (dataBaseView.SelectedCells[item].ColumnIndex != currentColumn)
                        throw new ArgumentException("Используйте только один столбец для постоения гистограммы");
                    data.Add(dataBaseView.SelectedCells[item].Value.ToString());
                }
                if (data.Count < dataBaseView.Rows.Count - 1)
                    throw new ArgumentException("Выделите столбец целиком");
                var grForm = new GraphicsForm(data);
                grForm.Show();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Метод вызывает форму с отрисовкой графиков и гистограмм.
        /// Выполняются все необходимые проверки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawChart(object sender, EventArgs e)
        {
            try
            {
                int currentColumn = dataBaseView.SelectedCells[0].ColumnIndex;
                HashSet<int> indexes = new HashSet<int>();
                List<double> xValues = new List<double>();
                List<double> yValues = new List<double>();
                for (var item = 0; item < dataBaseView.SelectedCells.Count; item++)
                {
                    if (!double.TryParse(dataBaseView.SelectedCells[item].Value.ToString().Replace(".", ","), 
                        out double number))
                        throw new ArgumentException("Используйте столбцы с числовыми значениями");
                    if (dataBaseView.SelectedCells[item].ColumnIndex == currentColumn)
                        xValues.Add(number);
                    else
                        yValues.Add(number);
                    indexes.Add(dataBaseView.SelectedCells[item].ColumnIndex);
                    if (indexes.Count > 2)
                        throw new ArgumentException("Нужно выделить только два столбца для создания графика");
                }
                if (xValues.Count != yValues.Count)
                    throw new ArgumentException("Количество значений в столбцах должно быть одинаковым");
                var grForm = new GraphicsForm(xValues, yValues);
                grForm.Show();
            } catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }


}
