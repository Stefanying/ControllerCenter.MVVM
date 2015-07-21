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
    public static class IpModelStore
    {
        private static IList<ControllerCenter.Model.IpModel> _list;
        private static InterfaceIpModelService _ipModelService = new IpModelService();
        // **//// <summary>
        /// 转换IList<T>为List<T>      //将IList接口泛型转为List泛型类型
        /// </summary>
        /// <typeparam name="T">指定的集合中泛型的类型</typeparam>
        /// <param name="gbList">需要转换的IList</param>
        /// <returns></returns>
        private static ObservableCollection<T> ConvertIListToList<T>(IList<T> gbList) where T : class   //静态方法，泛型转换，
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
        public static ObservableCollection<IpModel> List
        {
            
            get
            {
                ObservableCollection<IpModel> list = new ObservableCollection<IpModel>();
                _list = _ipModelService.GetAll();
                ObservableCollection<ControllerCenter.Model.IpModel> listsource = ConvertIListToList<ControllerCenter.Model.IpModel>(_list);
                foreach (ControllerCenter.Model.IpModel i in listsource)
                {
                    list.Add(toModel(i));
                }
                return list;
            }
        }
        private static IpModel toModel(ControllerCenter.Model.IpModel obj)
        {
            return new IpModel() { Id = obj.Id, IpName = obj.IpName };
        }
        public static void AddIpModel(IpModel p)
        {
            _ipModelService.Add(new ControllerCenter.Model.IpModel() { IpName = p.IpName });
        }

        public static void DelIpModel(IpModel p)
        {
            _ipModelService.Delete(new ControllerCenter.Model.IpModel() { IpName = p.IpName });
        }

        public static void ModifyIpModel(IpModel p)
        {
            _ipModelService.Update(new ControllerCenter.Model.IpModel() { IpName = p.IpName });
        }
    }
}
