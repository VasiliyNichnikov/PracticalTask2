using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticalTask2;
using PracticalTask2.Utils;
using ZedGraph;

namespace WinGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var annealingMethod = new Algorithm(0.01d, 10d);
            var cities = DeserializeCities.Cities;
            annealingMethod.SetCity(cities, 20);
            var readyRoute = annealingMethod.Run();

            InitializeComponent();

            DrawChart(zedGraphControl1, readyRoute);
            DrawHistogram(zedGraphControl2, annealingMethod.CollectedResponses);
        }

        private void DrawChart(ZedGraphControl zgc, City[] route)
        {
            GraphPane pane = zgc.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            foreach (var selectedCity in route)
            {
                list.Add(selectedCity.PosX, selectedCity.PosY);
            }
            LineItem curve = pane.AddCurve("Дорога", list, Color.Violet, SymbolType.Diamond);

            zgc.AxisChange();
            
            zgc.Invalidate();
        }

        private void DrawHistogram(ZedGraphControl zgc, float[] distances)
        {
            GraphPane pane = zgc.GraphPane;

            pane.CurveList.Clear();

            var distancesDouble = new double[distances.Length];
            for (int i = 0; i < distances.Length; i++)
            {
                distancesDouble[i] = distances[i];
            }
            BarItem curve = pane.AddBar("Расстояния", null, distancesDouble, Color.Blue);
            
            curve.Bar.Fill.Color = Color.YellowGreen;
            curve.Bar.Fill.Type = FillType.Solid;
            curve.Bar.Border.IsVisible = false;

            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}