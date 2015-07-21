using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.StopBitModel;


namespace ControllerCenter.MVVM.ViewModel.StopBitModel
{
    public class AddViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceStopBitModelService _stopBitModelService = new StopBitModelService();

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
        private string _stopBitName;
        public string StopBitName
        {
            get { return _stopBitName; }
            set
            {
                _stopBitName = value;
                OnPropertyChanged("StopBitName"); 
            }
        }
        public AddViewModel()
        {
            _addCommand = new DelegateCommand(SaveModel);
        }
        public AddViewModel(ListViewModel lvm)
        {
            _myListViewModel = lvm;
            _addCommand = new DelegateCommand(SaveModel);
        }
        private void SaveModel()
        {
            if (Closed != null)
            {
                var obj = new ControllerCenter.Model.StopBitModel()
                {
                    StopBitName = _stopBitName
                };
                _stopBitModelService.Add(obj);
                Closed();
            }
        }
        public void Show()
        {

            this.Closed += ChildWindow_Closed;
            ChildWindowManager.Instance.ShowChildWindow(new Add() { DataContext = this });
        }

        public void ChildWindow_Closed()
        {
            ChildWindowManager.Instance.CloseChildWindow();
            _myListViewModel.BindDate();
        }
    }
}
