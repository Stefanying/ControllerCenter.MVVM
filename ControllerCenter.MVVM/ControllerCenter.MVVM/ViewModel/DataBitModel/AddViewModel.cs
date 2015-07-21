using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.DataBitModel;


namespace ControllerCenter.MVVM.ViewModel.DataBitModel
{
    public class AddViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceDataBitModelService _dataBitModelService = new DataBitModelService();

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
        private string _dataBitName;
        public string DataBitName
        {
            get { return _dataBitName; }
            set
            {
                _dataBitName = value;
                OnPropertyChanged("DataBitName"); 
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
                var obj = new ControllerCenter.Model.DataBitModel()
                {
                    DataBitName = _dataBitName
                };
                _dataBitModelService.Add(obj);
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
