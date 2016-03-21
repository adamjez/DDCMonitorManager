﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DDCMonitorManager.Core;
using DDCMonitorManager.ViewModels;

namespace DDCMonitorManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Window window = GetWindow(this);
            if (window != null)
            {
                DataContext = new MainViewModel(window);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if ((SliderViewModel) slider?.DataContext != null)
            {
                var viewModel = (MainViewModel) DataContext;
                viewModel?.ChangeSliderValue((SliderViewModel)slider.DataContext, (short)e.NewValue);
            }
        }

    }
}
