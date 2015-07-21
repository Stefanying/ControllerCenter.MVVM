using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using ControllerCenter.Model;

namespace ControllerCenter.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2014.02.05
    /// </remarks>
    /// </summary>
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static CenterModelContainer GetCurrentContext()
        {
            CenterModelContainer _nContext = CallContext.GetData("CenterModelContainer") as CenterModelContainer;
            if (_nContext == null)
            {
                _nContext = new CenterModelContainer();
                CallContext.SetData("CenterModelContainer", _nContext);
            }
            return _nContext;
        }
    }

}
