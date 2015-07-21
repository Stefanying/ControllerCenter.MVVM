using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.ParityCheckBitModel;


namespace ControllerCenter.MVVM.ViewModel.ParityCheckBitModel
{
    public class AddViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceParityCheckBitModelService _parityCheckBitModelService = new ParityCheckBitModelService();

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
        private string _parityCheckBitName;
        public string ParityCheckBitName
        {
            get { return _parityCheckBitName; }
            set
            {
                _parityCheckBitName = value;
                OnPropertyChanged("ParityCheckBitName"); 
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
                var obj = new ControllerCenter.Model.ParityCheckBitModel()
                {
                    ParityCheckBitName = _parityCheckBitName
                };
                _parityCheckBitModelService.Add(obj);
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
