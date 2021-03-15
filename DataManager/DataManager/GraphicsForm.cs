using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataManager
{
    public partial class GraphicsForm : Form
    {
        // Словарь для гистограммы.
        Dictionary<string, int> histogramData = new Dictionary<string, int>();
        // Дефолтный конструктор.
        public GraphicsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для построения гистограммы.
        /// </summary>
        /// <param name="data">Список значений.</param>
        public GraphicsForm(List<string> data)
        {
            foreach (var item in data)
                if (histogramData.ContainsKey(item)) histogramData[item]++;
                else histogramData.Add(item, 1);
            if (histogramData.Count > 40)
                throw new ArgumentException("Категориальная переменная принимает слишком много значений");
            InitializeComponent();
            DrawHistogram();
        }
        /// <summary>
        /// Конструктор для построения графика.
        /// </summary>
        /// <param name="xValues">Значения для оси абсцисс.</param>
        /// <param name="yValues">Значения для оси ординат.</param>
        public GraphicsForm(List<double> xValues, List<double> yValues)
        {
            InitializeComponent();
            var dataPointSeries = new Series
            {
                Name = chart.Name,
                Color = Color.FromArgb(255, 129, 189, 79),
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 1,
                BorderColor = Color.White
            };
            dataPointSeries.Points.DataBindXY(xValues, yValues);
            chart.Series.Add(dataPointSeries);
        }

        /// <summary>
        /// Метод отрисовки гистограммы.
        /// Т.к гистограмму отрисовать сложнее, добавил еще один метод, чтобы не нарушать принципы декомпозиции.
        /// </summary>
        private void DrawHistogram()
        {
            var dataPointSeries = new Series
            {
                Name = chart.Name,
                Color = Color.FromArgb(255, 129, 189, 79),
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 1,
                BorderColor = Color.White
            };
            Pen startPen = new Pen(Color.FromArgb(255, 152, 190, 120));
            Pen endPen = new Pen(Color.FromArgb(255, 79, 129, 189));
            int iter = 0;
            // Градиент.
            int rMax = endPen.Color.R;
            int rMin = startPen.Color.R;
            int bMax = endPen.Color.B;
            int bMin = startPen.Color.B;
            int gMax = endPen.Color.G;
            int gMin = startPen.Color.G;
            chart.ChartAreas[0].AxisX.Interval = 1;
            foreach (var key in histogramData.Keys)
            {
                dataPointSeries.Points.Add(histogramData[key]);
                var rAverage = rMin + (int)((rMax - rMin) * iter / histogramData.Count);
                var gAverage = gMin + (int)((gMax - gMin) * iter / histogramData.Count);
                var bAverage = bMin + (int)((bMax - bMin) * iter / histogramData.Count);
                dataPointSeries.Points.Last().Color = Color.FromArgb(rAverage, gAverage, bAverage);
                dataPointSeries.Points.Last().LegendText = key;
                dataPointSeries.Points.Last().AxisLabel = key;
                iter++;
            }
            chart.Series.Add(dataPointSeries);
            chart.Series.Last()["PointWidth"] = "1";
        }

    }
}
