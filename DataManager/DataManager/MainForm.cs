using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DataManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataBaseView.CellMouseLeave += (sender, e) => dataBaseView.Cursor = Cursors.Default;
            loadDataBase.Click += LoadDataBaseClickHandle;
        }

        private void LoadDataBaseClickHandle(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataBaseView.Rows.Clear();
                    var dataTable = CsvImport.NewDataTable(openFileDialog1.FileName);
                    dataBaseView.DataSource = dataTable;
                    dataBaseView.Width = this.Width + 100;
                    for (var column = 0; column < dataBaseView.Columns.Count; column++)
                    {
                        dataBaseView.Columns[column].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataBaseView.Columns[column].HeaderCell.Style.Font = new Font(this.Font, FontStyle.Bold);
                        dataBaseView.Columns[column].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
                catch (ArgumentException exception)
                {
                    MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataBaseClickHandle(sender, e);
                }
            }
        }

        private void DataBaseViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Text = e.ColumnIndex.ToString();
        }

        private void DataBaseViewCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
                dataBaseView.Cursor = Cursors.PanSouth;
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
                dataBaseView.Cursor = Cursors.PanEast;
        }

    }
}
