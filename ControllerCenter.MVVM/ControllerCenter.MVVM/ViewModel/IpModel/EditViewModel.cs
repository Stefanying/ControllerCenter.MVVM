using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.IpModel;

namespace ControllerCenter.MVVM.ViewModel.IpModel
{
    public class EditViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceIpModelService _ipModelService = new IpModelService();

        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand
        {
            get { return _editCommand; }
        }
        private ListViewModel _myListViewModel;
        public ListViewModel MyListViewModel
        {
            get { return _myListViewModel; }
            set { _myListViewModel = value; }
        }
        private ControllerCenter.Model.IpModel _model;
        public ControllerCenter.Model.IpModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        public EditViewModel(ListViewModel lvm,int id)
        {
            _myListViewModel = lvm;
            _model = new Model.IpModel() { Id=id };
            _editCommand = new DelegateCommand(SaveModel);
        }
        private void SaveModel()
        {
            if (Closed != null)
            {
                _ipModelService.Update(_model);
                Closed();
            }
        }
        public void Show()
        {
            _model = _ipModelService.GetById(_model.Id);
            this.Closed += ChildWindow_Closed;
            ChildWindowManager.Instance.ShowChildWindow(new Edit() { DataContext = this });
        }

        public void ChildWindow_Closed()
        {
            ChildWindowManager.Instance.CloseChildWindow();
            _myListViewModel.BindDate();
        }
    }
}