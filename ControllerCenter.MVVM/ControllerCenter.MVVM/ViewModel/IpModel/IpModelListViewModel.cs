using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using ControllerCenter.MVVM.Store;
using ControllerCenter.MVVM.View;
using ControllerCenter.MVVM.View.IpModel;


namespace ControllerCenter.MVVM.ViewModel.IpModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class IpModelListViewModel : BaseViewModel
    {
        #region 变量
        private IpModelList _IpModelList;
        private ObservableCollection<ControllerCenter.Model.IpModel> _IpModelDataList;
        private ControllerCenter.Model.IpModel _IpModel;
        #endregion
        #region 属性
        public ObservableCollection<ControllerCenter.Model.IpModel> IpModelDataList
        {
            get { return this._IpModelDataList; }
            set
            {
                this._IpModelDataList = value;
            }
        }
        public ControllerCenter.Model.IpModel IpModel
        {
            get { return this._IpModel; }
            set { this._IpModel = value; }
        }
        #endregion
         #region 构造函数
        public IpModelListViewModel()
        { 
        }
        public IpModelListViewModel(IpModelList personList)
        {
            this._IpModelList = personList;
            this.QueryIpModelExecute(null);
        }
        #endregion

        #region 方法
        public void QueryIpModelExecute(object parameter)
        {
            this._IpModelDataList = IpModelStore.List;
        }

        public void AddIpModelExecute(object parameter)
        {
            IpModelAdd ipModeInfo = new IpModelAdd();
            ipModeInfo.Show();
        }

        public void DeleteIpModelExecute(object parameter)
        {
            if (this.IpModel != null && this.IpModel.Id != 0)
            {
                IpModelStore.DelIpModel(this.IpModel);
            }
        }

        public void ModifyIpModelExecute(object parameter)
        {
            IpModelAdd ipModeInfo = new IpModelAdd(this.IpModel);
            
            
        }

        #endregion
    }
}
