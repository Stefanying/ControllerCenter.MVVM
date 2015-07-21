using ControllerCenter.Model;
using ControllerCenter.IBLL;
using ControllerCenter.IDAL;
using ControllerCenter.BLL;
using ControllerCenter.DAL;

namespace ControllerCenter.BLL
{
    public class CommPortModelService : BaseService<CommPortModel>, InterfaceCommPortModelService
    {
        public CommPortModelService() : base(RepositoryFactory.CommPortModelRepository) { }

    }
}
