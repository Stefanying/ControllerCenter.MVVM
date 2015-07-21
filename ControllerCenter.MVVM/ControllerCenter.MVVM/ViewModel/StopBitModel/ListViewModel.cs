using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ControllerCenter.MVVM.View.StopBitModel;
using ControllerCenter.MVVM.Common;
using ControllerCenter.IBLL;
using ControllerCenter.BLL;
using System.Windows;
using System.Windows.Input;

namespace ControllerCenter.MVVM.ViewModel.StopBitModel
{
    public class ListViewModel : BaseViewModel
    {
        private ICommand addCommand;
        private ICommand editCommand;
        private ICommand delCommand;
        private ObservableCollection<ControllerCenter.Model.StopBitModel> _stopBitModelDataList;
        private InterfaceStopBitModelService _stopBitModelService;
        public List View { get; set; }
        public ICommand EditCommand
        {
           get { return editCommand; }
            set { editCommand = value; }
        }
        public ICommand DelCommand
        {
            get { return delCommand; }
            set { delCommand = value; }
        }
        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; }
        }
        public ObservableCollection<ControllerCenter.Model.StopBitModel> StopBitModelDataList
        {
            get { return this._stopBitModelDataList; }
            set
            {
                this._stopBitModelDataList = value;
                OnPropertyChanged("StopBitModelDataList"); 
            }
        }
        public void Refresh() 
        {
            _stopBitModelService = new StopBitModelService();
        }
        public ListViewModel()
        {
            //Refresh();
            BindDate();
            addCommand = new DelegateCommand(ShowAddWindow);

            editCommand = new DelegateCommand<object>(ShowEditWindow, arg => true);
            //editCommand.IsActive = true;
            //editCommand.IsActiveChanged += (s, e) =>
            //{
               // editCommand.RaiseCanExecuteChanged();
            //};

            //editCommand = new DelegateCommand<string>(ShowEditWindow);
            delCommand = new DelegateCommand<object>(ShowDelWindow, arg => true);
        }
        private void ShowEditWindow(object sender)
        {
            string s = sender.ToString();
            var childWindow = new EditViewModel(this,int.Parse(s));
            childWindow.Closed += BindDate;
            childWindow.Show();
        }
        private void ShowDelWindow(object sender)
        {
            string s = sender.ToString();
            ControllerCenter.Model.StopBitModel obj = _stopBitModelService.GetById(int.Parse(s));
            _stopBitModelService.Delete(obj);
            BindDate();

        }

        private void ShowAddWindow()
        {
            var childWindow = new AddViewModel(this);
            childWindow.Closed += BindDate;
            childWindow.Show();
        }
        private void ShoweditWindow(string id)
        {
            var childWindow = new AddViewModel(this);
            childWindow.Closed += BindDate;
            childWindow.Show();
        }
        public void BindDate()
        {
            Refresh();
            IList<ControllerCenter.Model.StopBitModel> gbList = _stopBitModelService.GetAll();
            this.StopBitModelDataList = ConvertIListToList<ControllerCenter.Model.StopBitModel>(gbList);
        }
        public void ShowList(MainWindow mw)
        {
            mw.ChildrenWinContent.Children.Add ( new List());
        }
        // **//// <summary>
        /// 转换IList<T>为List<T>      //将IList接口泛型转为List泛型类型
        /// </summary>
        /// <typeparam name="T">指定的集合中泛型的类型</typeparam>
        /// <param name="gbList">需要转换的IList</param>
        /// <returns></returns>
        private  ObservableCollection<T> ConvertIListToList<T>(IList<T> gbList) where T : class   //静态方法，泛型转换，
        {
            if (gbList != null && gbList.Count >= 1)
            {
                ObservableCollection<T> list = new ObservableCollection<T>();
                for (int i = 0; i < gbList.Count; i++)  //将IList中的元素复制到List中
                {
                    T temp = gbList[i] as T;
                    if (temp != null)
                        list.Add(temp);
                }
                return list;
            }
            return null;
        }
    }
}
