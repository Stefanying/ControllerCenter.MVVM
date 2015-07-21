using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControllerCenter.MVVM.ViewModel;
using ControllerCenter.MVVM.View;
using ControllerCenter.MVVM.Common;

namespace ControllerCenter.MVVM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            childWindow.DataContext = ChildWindowManager.Instance;
            //this.myFrame.Source = new Uri("/View/Home.xaml", UriKind.Relative);
            this.ChildrenWinContent.Children.Add (new Home1());
            this.DataContext = new MainViewModel(this);   
            
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void maxSizButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                maxSizeButton.Content = "□";
            }
            else
            {
                WindowState = WindowState.Maximized;
                maxSizeButton.Content = "❐";
            }
        }
        private void miniSizButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
