using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControllerCenter.Model;
using ControllerCenter.IBLL;
using ControllerCenter.IDAL;
using ControllerCenter.BLL;
using ControllerCenter.DAL;

namespace ControllerCenter.BLL
{
    public class IpModelService : BaseService<IpModel>, InterfaceIpModelService
    {
        public IpModelService() : base(RepositoryFactory.IpModelRepository) { }

    }
}
