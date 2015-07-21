using Microsoft.Practices.Prism.Commands;

namespace ControllerCenter.App.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DelegateCommand showChildWindowCommand;
        public DelegateCommand ShowChildWindowCommand
        {
            get { return showChildWindowCommand; }
        }
        public MainViewModel()
        {
            showChildWindowCommand = new DelegateCommand(ShowChildWindow);
        }
        #region Private Methods

        private void ShowChildWindow()
        {
            
            var childWindow = new HomeViewModel();
            childWindow.Closed += (r =>
            {
                FirstName = r.FirstName;
                RaisePropertyChanged("FirstName");

                LastName = r.LastName;
                RaisePropertyChanged("LastName");

                Email = r.Email;
                RaisePropertyChanged("Email");

                Address = r.Address;
                RaisePropertyChanged("Address");
            });
            childWindow.Show(1);
        }

        #endregion   
    }
}
