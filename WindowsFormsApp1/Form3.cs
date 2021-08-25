using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(string filePath)
        {
            InitializeComponent();
            using (var fileRdr = new StreamReader(filePath))
            {
                var columns = fileRdr.ReadLine().Split(", ".ToArray(), StringSplitOptions.RemoveEmptyEntries);


                foreach (var col in columns)
                {
                    var dataColumn = new DataGridViewTextBoxColumn();
                    

                }

                var lineData = fileRdr.ReadLine().Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                DateTime dt1 = Convert.ToDateTime(lineData[0]);
                chart1.Series[0].Points.AddXY(Convert.ToDouble(0), lineData[2]);
                chart2.Series[0].Points.AddXY(Convert.ToDouble(0), lineData[3]);
                chart3.Series[0].Points.AddXY(Convert.ToDouble(0), lineData[4]);
                chart4.Series[0].Points.AddXY(Convert.ToDouble(0), lineData[8]);

                while (!fileRdr.EndOfStream)
                {
                    lineData = fileRdr.ReadLine().Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                  
                    DateTime dt2 = Convert.ToDateTime(lineData[0]);

                    double t = (dt2 - dt1).TotalMilliseconds / 1000000;
                    chart1.Series[0].Points.AddXY(t, lineData[2]);
                    chart2.Series[0].Points.AddXY(t, lineData[3]);
                    chart3.Series[0].Points.AddXY(t, lineData[4]);
                    chart4.Series[0].Points.AddXY(t, lineData[5]);
                    Debug.Write(t+  "\n");
                   
                }

                fileRdr.Close();
                fileRdr.Dispose();
            }
            
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            /*chart1.Series[0].Name = "X";
            chart2.Series[0].Name = "Y";
            chart3.Series[0].Name = "Z";
            chart4.Series[0].Name = "Sound";

            */

            
            chart1.ChartAreas[0].AxisX.Title = "Time(sec)";
            chart1.ChartAreas[0].AxisY.Title = "X(mm/s)";
            chart2.ChartAreas[0].AxisX.Title = "Time(sec)";
            chart2.ChartAreas[0].AxisY.Title = "Y(mm/s)";
            chart3.ChartAreas[0].AxisX.Title = "Time(sec)";
            chart3.ChartAreas[0].AxisY.Title = "Z(mm/s)";
            chart4.ChartAreas[0].AxisX.Title = "Time(sec)";
            chart4.ChartAreas[0].AxisY.Title = "Sound(db(A))";

            chart1.Legends[0].Enabled = false;
            chart2.Legends[0].Enabled = false;
            chart3.Legends[0].Enabled = false;
            chart4.Legends[0].Enabled = false;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 0.25;

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Interval = 0.25;

            chart3.ChartAreas[0].AxisX.Minimum = 0;
            chart3.ChartAreas[0].AxisX.Interval = 0.25;

            chart4.ChartAreas[0].AxisX.Minimum = 0;
            chart4.ChartAreas[0].AxisX.Interval = 0.25;

        }
    }
}
