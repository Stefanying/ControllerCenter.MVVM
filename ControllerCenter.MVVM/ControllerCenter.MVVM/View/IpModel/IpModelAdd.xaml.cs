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
using ControllerCenter.Model;
using ControllerCenter.BLL;
using ControllerCenter.MVVM.Store;

namespace ControllerCenter.MVVM.View.IpModel
{
    /// <summary>
    /// AddIpModel.xaml 的交互逻辑
    /// </summary>
    public partial class IpModelAdd :Window
    {
        private ControllerCenter.MVVM.ViewModel.IpModel.IpModelAddViewModel _IpModelAddViewModel ;
        private ControllerCenter.MVVM.ViewModel.IpModel.IpModelInfoViewModel _IpModelInfoViewModel;
        public IpModelAdd()
        {
            InitializeComponent();
            InitUI();
            
        }
        private void InitUI()
        {

            this.idLbl.Visibility = System.Windows.Visibility.Hidden;
            this.newIDNameTextBox.Visibility = System.Windows.Visibility.Hidden;
            this.iPLbl.Margin = new Thickness(0, 30, 0, 0);
            this.newIPNameTextBox.Margin = new Thickness(75, 30, 10, 0);
            _IpModelAddViewModel = new ViewModel.IpModel.IpModelAddViewModel(this);
        }
        private void InitUI(ControllerCenter.Model.IpModel ipModel)
        {
            this._IpModelInfoViewModel = new ControllerCenter.MVVM.ViewModel.IpModel.IpModelInfoViewModel(this);
            this.DataContext = this._IpModelAddViewModel;
        }
        public IpModelAdd(ControllerCenter.Model.IpModel ipModel)
        {
            InitializeComponent();
            InitUI(ipModel);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ControllerCenter.Model.IpModel obj = new Model.IpModel();
            obj = this.DataContext as ControllerCenter.Model.IpModel;
            IpModelStore.ModifyIpModel(obj);
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _IpModelAddViewModel.IpModel.IpName = newIPNameTextBox.Text.ToString();
            _IpModelAddViewModel.SaveIpModelExecute();

        }
    }
}

