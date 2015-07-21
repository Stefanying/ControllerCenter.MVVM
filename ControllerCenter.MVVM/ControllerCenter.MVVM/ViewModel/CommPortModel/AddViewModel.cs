using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.CommPortModel;


namespace ControllerCenter.MVVM.ViewModel.CommPortModel
{
    public class AddViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceCommPortModelService _commPortModellService = new CommPortModelService();

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get { return _addCommand; }
        }
        private ListViewModel _myListViewModel;
        public ListViewModel MyListViewModel
        {
            get { return _myListViewModel; }
            set { _myListViewModel = value; }
        }
        private string _commPortName;
        public string CommPortName
        {
            get { return _commPortName; }
            set
            {
                _commPortName = value;
                OnPropertyChanged("CommPortName");
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
                var obj = new ControllerCenter.Model.CommPortModel()
                {
                    CommPortName = _commPortName
                };
                _commPortModellService.Add(obj);
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
