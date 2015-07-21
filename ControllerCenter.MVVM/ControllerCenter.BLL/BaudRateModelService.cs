using ControllerCenter.Model;
using ControllerCenter.IBLL;
using ControllerCenter.IDAL;
using ControllerCenter.BLL;
using ControllerCenter.DAL;

namespace ControllerCenter.BLL
{
    public class BaudRateModelService : BaseService<BaudRateModel>, InterfaceBaudRateModelService
    {
        public BaudRateModelService() : base(RepositoryFactory.BaudRateModelRepository) { }

    }
}
