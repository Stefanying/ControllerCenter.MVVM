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
    public class IpModelAddViewModel
    {
        private IpModelAdd _IpModelInfo;
        private ControllerCenter.Model.IpModel _IpModel;

        public ControllerCenter.Model.IpModel IpModel
        {
            get { return this._IpModel; }
            set { this._IpModel = value; }
        }
        public IpModelAddViewModel(IpModelAdd ipModelInfo)
        {
            this._IpModelInfo = ipModelInfo;
            _IpModel = new Model.IpModel();
        }

        public IpModelAddViewModel(IpModelAdd ipModelInfo, ControllerCenter.Model.IpModel ipModel)
        {
            this._IpModelInfo = ipModelInfo;
            this._IpModel = ipModel;
        }

        public void SaveIpModelExecute()
        {
                if (this.IpModel.Id<=0)
                {
                    //新增

                    IpModelStore.AddIpModel(this.IpModel);
                }
                else
                {
                    //修改
                    IpModelStore.ModifyIpModel(this.IpModel);
                    MessageBox.Show("修改成功!");
                }
            //this._IpModelInfo.DialogResult = true;
            this._IpModelInfo.Close();
        }

        public void CloseIpModelExecute(object parameter)
        {
           // this._IpModelInfo.DialogResult = false;
            //this._IpModelInfo.Close();
        }
    }
}
