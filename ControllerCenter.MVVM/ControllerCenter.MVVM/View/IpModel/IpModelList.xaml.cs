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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControllerCenter.MVVM.ViewModel;

namespace ControllerCenter.MVVM.View.IpModel
{
    /// <summary>
    /// IpModelListView.xaml 的交互逻辑
    /// </summary>
    public partial class IpModelList : Page
    {
        private ControllerCenter.MVVM.ViewModel.IpModel.IpModelListViewModel _IpModelViewModel = null;
        public IpModelList()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();  
            InitUI();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            IpModelAdd ipModeInfo = new IpModelAdd();
            ipModeInfo.Show();
        }

        private void InitUI()
        {
            this._IpModelViewModel = new ControllerCenter.MVVM.ViewModel.IpModel.IpModelListViewModel(this);
            iPList.DataContext = this._IpModelViewModel;
        }
    }
    
}
