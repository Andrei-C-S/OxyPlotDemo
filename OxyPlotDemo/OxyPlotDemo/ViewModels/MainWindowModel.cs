using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlotDemo.Annotations;

namespace OxyPlotDemo.ViewModels
{
    public class MainWindowModel:  INotifyPropertyChanged
    {
        private PlotModel plotModel;

        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { plotModel = value; OnPropertyChanged("PlotModel"); }
        }

        

        public MainWindowModel()
        {
            PlotModel = new PlotModel();

            var s1 = new OxyPlot.Series.LineSeries();
            s1.Points.Add(new DataPoint(0, 4));
            s1.Points.Add(new DataPoint(10, 13));
            s1.Points.Add(new DataPoint(20, 15));
            s1.Points.Add(new DataPoint(30, 16));
            s1.Points.Add(new DataPoint(40, 12));
            s1.Points.Add(new DataPoint(50, 12));

            PlotModel.Series.Add(s1);

            var l1 = new OxyPlot.Annotations.LineAnnotation();
            l1.Type = OxyPlot.Annotations.LineAnnotationType.Horizontal;
            l1.Y = 5;
            l1.MinimumX = 2;
            l1.MaximumX = 15;
            l1.LineStyle = OxyPlot.LineStyle.Solid;
            PlotModel.Annotations.Add(l1);
            double x;

            l1.MouseDown += (s, e) =>
            {
                x = (l1 as OxyPlot.Annotations.LineAnnotation).InverseTransform(e.Position).X;
                l1.MinimumX = x;
                PlotModel.RefreshPlot(true);
                PlotModel.InvalidatePlot(true);
                //OnPropertyChanged("PlotModel");
                e.Handled = true;
                
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
