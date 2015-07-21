using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.IpModel;


namespace ControllerCenter.MVVM.ViewModel.IpModel
{
    public class AddViewModel : BaseViewModel
    {
        private static InterfaceIpModelService _ipModelService = new IpModelService();

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand
        {
            get { return _closeCommand; }
        }
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get { return _addCommand; }
        }
        private ListViewModel _myListViewModel;
        public ListViewModel MyListViewModel
        {
            get { return _myListViewModel; }
            set { _myListViewModel =value; }
        }
        private string _ipName;
        public string IpName
        {
            get { return _ipName; }
            set
            {
                _ipName = value;
                OnPropertyChanged("IpName"); 
            }
        }
        public AddViewModel()
        {
        }
        public AddViewModel(ListViewModel lvm)
        {
            _myListViewModel = lvm;
            _addCommand = new DelegateCommand(SaveModel);
            _closeCommand = new DelegateCommand(ChildWindow_Closed);
        }
        private void SaveModel()
        {
            if (_closeCommand != null)
            {
                var obj = new ControllerCenter.Model.IpModel()
                {
                    IpName = _ipName
                };
                _ipModelService.Add(obj);
                ChildWindow_Closed();
            }
        }
        public void Show()
        {
            ChildWindowManager.Instance.ShowChildWindow(new Add() { DataContext = this });
        }

        public void ChildWindow_Closed()
        {
            ChildWindowManager.Instance.CloseChildWindow();
            _myListViewModel.BindDate();
        }
    }
}
