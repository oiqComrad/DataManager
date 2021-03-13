using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

namespace DataManager
{
    public partial class MainForm : Form
    {
        bool shiftPress = false;
        List<int> selectColumns;
        public MainForm()
        {
            InitializeComponent();
            dataBaseView.CellMouseLeave += (sender, e) => dataBaseView.Cursor = Cursors.Default;
            loadDataBase.Click += LoadDataBaseClickHandle;
            selectColumns = new List<int>();
            this.KeyPreview = true;
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

        private void LoadDataBaseClickHandle(object sender, EventArgs e)
        {
            DataBaseSettings dataBaseSettings = new DataBaseSettings();
            dataBaseSettings.ShowDialog();
            if (dataBaseSettings.filename == null) return;
            try
            {
                dataBaseView.Columns.Clear();
                var dataTable = CsvImport.NewDataTable(dataBaseSettings.filename, dataBaseSettings.separator,
                    dataBaseSettings.firstRowContainesColumnsName);
                dataBaseView.DataSource = dataTable;
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


        private void DataBaseViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlsUpdate.BeginControlUpdate(this);
            if (!shiftPress)
            {
                dataBaseView.ClearSelection();
                selectColumns.Clear();
            }
            for (var row = 0; row < dataBaseView.RowCount; row++)
                dataBaseView[e.ColumnIndex, row].Selected = true;
            dataBaseView.Columns[e.ColumnIndex].Selected = true;
            selectColumns.Add(e.ColumnIndex);
            ControlsUpdate.EndControlUpdate(this);
        }

        private void DataBaseViewCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
                dataBaseView.Cursor = Cursors.PanSouth;
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
                dataBaseView.Cursor = Cursors.PanEast;
        }

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
