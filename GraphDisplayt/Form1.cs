using GraphDisplayt.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDisplayt
{
    public partial class Form1 : Form
    {
        public List<BenchmarkPoint> Points { get; set; }
        public int Step = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Points = new List<BenchmarkPoint>();

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Iteracija",
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Laikas",
            });

            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Bottom;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series.Clear();
            var itterations = int.Parse(textBox1.Text);
            Points = new List<BenchmarkPoint>();

            var config = Mappers.Xy<LiveChartDataPoint>()
               .X(model => model.Itteration)
               .Y(model => (double)model.time.Ticks);

            var series = new SeriesCollection(config);
            cartesianChart1.Series = series;
            var values = new ChartValues<LiveChartDataPoint>();

            if (checkBox0.Checked)
            {
                values = new ChartValues<LiveChartDataPoint>();
                series.Add(new LineSeries
                {
                    Title = "Linijinis",
                    Values = values,
                });
                AddItterativeValues(itterations, values);
            }

            if (checkBox1.Checked)
            {
                values = new ChartValues<LiveChartDataPoint>();
                series.Add(new LineSeries
                {
                    Title = "Rekursinis",
                    Values = values
                });
                AddRecursiveValues(itterations, values);
            }
            

            if(checkBox2.Checked)
            {
                values = new ChartValues<LiveChartDataPoint>();
                series.Add(new LineSeries
                {
                    Title = "Matricinis",
                    Values = values,
                });
                AddMatrixValues(itterations, values);
            }
            
            dataGridView1.DataSource = Points;
        }

        private void AddItterativeValues(int itterations, ChartValues<LiveChartDataPoint> values)
        {         
            var stopwatch = new Stopwatch();
            for (int i = 1; i <= itterations; i += Step)
            {
                GC.Collect();
                stopwatch.Restart();
                var result = FibonacciCalculator.GetFibonacciLinearValue(i);
                stopwatch.Stop();
                var record = new BenchmarkPoint
                {
                    Duration = stopwatch.Elapsed,
                    Itteration = i,
                    Result = result,
                    Type = CalculationType.Itterative
                };
                Points.Add(record);
                values.Add(new LiveChartDataPoint
                {
                    time = stopwatch.Elapsed,
                    Itteration = i
                });
            }
        }

        private void AddRecursiveValues(int itterations, ChartValues<LiveChartDataPoint> values)
        {
            for (int i = 1; i <= itterations; i += Step)
            {
                GC.Collect();
                var timespan = Stopwatch.StartNew();
                var result = FibonacciCalculator.GetFibonacciRecursiveValue(i);
                timespan.Stop();
                var record = new BenchmarkPoint
                {
                    Duration = timespan.Elapsed,
                    Itteration = i,
                    Result = result,
                    Type = CalculationType.Recursive
                };
                Points.Add(record);
                values.Add(new LiveChartDataPoint
                {
                    time = timespan.Elapsed,
                    Itteration = i
                });
            }
        }

        private void AddMatrixValues(int itterations, ChartValues<LiveChartDataPoint> values)
        {
            var stopwatch = new Stopwatch();
            for (int i = 1; i <= itterations; i+= Step)
            {
                GC.Collect();
                stopwatch.Restart();
                var result = FibonacciCalculator.GetFibonacciMatrixValue(i);
                stopwatch.Stop();
                var record = new BenchmarkPoint
                {
                    Duration = stopwatch.Elapsed,
                    Itteration = i,
                    Result = result,
                    Type = CalculationType.Matrix
                };
                Points.Add(record);
                values.Add(new LiveChartDataPoint
                {
                    time = stopwatch.Elapsed,
                    Itteration = i
                });
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Step = int.Parse(textBox2.Text);
        }
    }
}
