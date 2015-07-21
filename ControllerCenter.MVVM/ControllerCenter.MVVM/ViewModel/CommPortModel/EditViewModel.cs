using Microsoft.Practices.Prism.Commands;
using System;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using ControllerCenter.MVVM.Common;
using ControllerCenter.MVVM.View.CommPortModel;

namespace ControllerCenter.MVVM.ViewModel.CommPortModel
{
    public class EditViewModel : BaseViewModel
    {
        public event Action Closed;
        private static InterfaceCommPortModelService _commPortModelService = new CommPortModelService();

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
        private ControllerCenter.Model.CommPortModel _model;
        public ControllerCenter.Model.CommPortModel Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        public EditViewModel(ListViewModel lvm, int id)
        {
            _myListViewModel = lvm;
            _model = new Model.CommPortModel() { Id = id };
            _editCommand = new DelegateCommand(SaveModel);
        }
        private void SaveModel()
        {
            if (Closed != null)
            {
                _commPortModelService.Update(_model);
                Closed();
            }
        }
        public void Show()
        {
            _model = _commPortModelService.GetById(_model.Id);
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