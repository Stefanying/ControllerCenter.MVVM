using Microsoft.Practices.Prism.Commands;
using ControllerCenter.MVVM.ViewModel;
using ControllerCenter.MVVM.ViewModel.IpModel;
using ControllerCenter.Model;
using System.Windows.Controls;
using System;
using ControllerCenter.MVVM.View.IpModel;
using ControllerCenter.MVVM.View.BaudRateModel;
using ControllerCenter.MVVM.ViewModel.BaudRateModel;
using ControllerCenter.MVVM.View;

namespace ControllerCenter.MVVM
{
    public class MainViewModel : BaseViewModel
    {
        private MainWindow _mYMainWindow;

        private UserControl _myContorl;

        private Frame _myFrame;

        public UserControl MyContorl
        {
            get { return _myContorl; }
            set { _myContorl = value; }
        }
        public Frame MyFrame
        {
            get { return _myFrame; }
            set { _myFrame = value; }
        }

        public MainWindow MYMainWindow
        {
            get { return _mYMainWindow; }
            set { _mYMainWindow = value; }
        }
        
        public MainViewModel( MainWindow obj)
        {
            this._mYMainWindow = obj;
            showMyHomeWindowCommand = new DelegateCommand(ShowMyHomeWindow);
            showIPConfigWindowCommand = new DelegateCommand(ShowIPConfigWindow);
            showBaudRateModelWindowCommand = new DelegateCommand(ShowBaudRateModelWindow);
            showCommPortModelWindowCommand = new DelegateCommand(ShowCommPortModelWindow);
            showDataBitModelWindowCommand = new DelegateCommand(ShowDataBitModelWindow);
            showStopBitModelWindowCommand = new DelegateCommand(ShowStopBitModelWindow);
            showParityCheckBitModelWindowCommand = new DelegateCommand(ShowParityCheckBitModelWindow);
        }
        public MainViewModel()
        {
            showMyHomeWindowCommand = new DelegateCommand(ShowMyHomeWindow);
            showIPConfigWindowCommand = new DelegateCommand(ShowIPConfigWindow);
            showBaudRateModelWindowCommand = new DelegateCommand(ShowBaudRateModelWindow);
        }
        private DelegateCommand showMyHomeWindowCommand;
        public DelegateCommand ShowMyHomeWindowCommand
        {
            get { return showMyHomeWindowCommand; }
        }
        private DelegateCommand showBaudRateModelWindowCommand;
        public DelegateCommand ShowBaudRateModelWindowCommand
        {
            get { return showBaudRateModelWindowCommand; }
        }
        
        private DelegateCommand showIPConfigWindowCommand;
        public DelegateCommand ShowIPConfigWindowCommand
        {
            get { return showIPConfigWindowCommand; }
        }
        private DelegateCommand showCommPortModelWindowCommand;
        public DelegateCommand ShowCommPortModelWindowCommand
        {
            get { return showCommPortModelWindowCommand; }
        }
        
        private DelegateCommand showDataBitModelWindowCommand;
        public DelegateCommand ShowDataBitModelWindowCommand
        {
            get { return showDataBitModelWindowCommand; }
        }
        private DelegateCommand showStopBitModelWindowCommand;
        public DelegateCommand ShowStopBitModelWindowCommand
        {
            get { return showStopBitModelWindowCommand; }
        }
        private DelegateCommand showParityCheckBitModelWindowCommand;
        public DelegateCommand ShowParityCheckBitModelWindowCommand
        {
            get { return showParityCheckBitModelWindowCommand; }
        }
        private void ShowMyHomeWindow()
        {
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            this._myContorl = new Home1();
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/Home.xaml", UriKind.Relative));

            var childWindow = new HomeViewModel();
            //childWindow.Show(_mYMainWindow);
        }
        private void ShowIPConfigWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.IpModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.IpModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
        
        private void ShowBaudRateModelWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.BaudRateModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.BaudRateModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
        private void ShowCommPortModelWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.CommPortModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.CommPortModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
        private void ShowDataBitModelWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.DataBitModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.DataBitModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
        private void ShowStopBitModelWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.StopBitModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.StopBitModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
        private void ShowParityCheckBitModelWindow()
        {
            //this.MYMainWindow.myFrame.Navigate(new Uri("/View/IpModel/IpModelList.xaml", UriKind.Relative));
            this._myContorl = new ControllerCenter.MVVM.View.ParityCheckBitModel.List();
            var childWindow = new ControllerCenter.MVVM.ViewModel.ParityCheckBitModel.ListViewModel();
            _mYMainWindow.ChildrenWinContent.Children.Clear();
            childWindow.ShowList(_mYMainWindow);
        }
    }
}
