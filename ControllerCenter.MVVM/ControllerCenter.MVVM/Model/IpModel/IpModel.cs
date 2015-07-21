using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControllerCenter.Model;
using ControllerCenter.BLL;
using ControllerCenter.IBLL;
using System.ComponentModel;


namespace ControllerCenter.MVVM.Model.IpModel
{
    public class IpModel : INotifyPropertyChanged
    {
        private int _id;
        private string _ipName;
        public IpModel()
        {
           
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return _id; }

            set
            {
                this._id = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }

        }
        /// <summary>
        /// 名称
        /// </summary>
        public string IpName
        {
            get { return _ipName; }
            set
            {
                this._ipName = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("IpName"));
            }

        }
        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
