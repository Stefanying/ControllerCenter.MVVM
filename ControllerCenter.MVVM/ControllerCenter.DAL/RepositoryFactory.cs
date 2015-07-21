using ControllerCenter.IDAL;

namespace ControllerCenter.DAL
{
    /// <summary>
    /// 简单工厂？
    /// <remarks>创建：2014.02.03</remarks>
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// IP字典
        /// </summary>
        public static InterfaceIpModelRepository IpModelRepository { get { return new IpModelRepository(); } }
        /// <summary>
        /// 波特率
        /// </summary>
        public static InterfaceBaudRateModelRepository BaudRateModelRepository { get { return new BaudRateModelRepository(); } }
        /// <summary>
        /// 端口号
        /// </summary>
        public static InterfaceCommPortModelRepository CommPortModelRepository { get { return new CommPortModelRepository(); } }
        /// <summary>
        /// 数据位
        /// </summary>
        public static InterfaceDataBitModelRepository DataBitModelRepository { get { return new DataBitModelRepository(); } }
        /// <summary>
        /// 停止位
        /// </summary>
        public static InterfaceStopBitModelRepository StopBitModelRepository { get { return new StopBitModelRepository(); } }
        /// <summary>
        /// 校验位
        /// </summary>
        public static InterfaceParityCheckBitModelRepository ParityCheckBitModelRepository { get { return new ParityCheckBitModelRepository(); } }
       
    }
}
