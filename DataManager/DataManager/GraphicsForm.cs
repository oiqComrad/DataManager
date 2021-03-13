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
        Dictionary<string, int> histogramData = new Dictionary<string, int>();
        public GraphicsForm()
        {
            InitializeComponent();
        }

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

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
