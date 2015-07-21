using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ControllerCenter.MVVM.Store;
using ControllerCenter.MVVM.View.IpModel;

namespace ControllerCenter.MVVM.ViewModel.IpModel
{
    public class IpModelInfoViewModel : BaseViewModel
     {
        private IpModelAdd _IpModelInfo;
        private ControllerCenter.Model.IpModel _IpModel;
        private string _IpName;

        public ControllerCenter.Model.IpModel IpModel
        {
            get { return this._IpModel; }
            set { this._IpModel = value; }
        }
       
        public string IpName
        {
            get { return this._IpName; }
            set { this._IpName = value; }
        }

        public IpModelInfoViewModel(IpModelAdd ipModelInfo)
        {
            this._IpModelInfo = ipModelInfo;
        }

        public IpModelInfoViewModel(IpModelAdd ipModelInfo, ControllerCenter.Model.IpModel ipModel)
        {
            this._IpModelInfo = ipModelInfo;
            this._IpModel = ipModel;
        }

        public void SaveIpModelExecute(object parameter)
        {
            if (parameter is Button)
            {
                Button button = parameter as Button;
                if (this.IpModel == null)
                {
                    //新增
                    ControllerCenter.Model.IpModel p = new ControllerCenter.Model.IpModel();
                    IpModelStore.AddIpModel(p);
                    MessageBox.Show("新增成功!");
                }
                else
                {
                    //修改
                    this.IpModel.IpName = this.IpName;
                    IpModelStore.ModifyIpModel(this.IpModel);
                    MessageBox.Show("修改成功!");
                }
            }
           // this._IpModelInfo.DialogResult = true;
           // this._IpModelInfo.Close();
        }

        public void CloseIpModelExecute(object parameter)
        {
           // this._IpModelInfo.DialogResult = false;
            //this._IpModelInfo.Close();
        }
    }
}
