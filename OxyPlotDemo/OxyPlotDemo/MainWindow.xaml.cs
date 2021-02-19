using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace OxyPlotDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModels.MainWindowModel viewModel;

        public MainWindow()
        {
            viewModel = new ViewModels.MainWindowModel();
            DataContext = viewModel;

            InitializeComponent();
        }
        

    }
}
