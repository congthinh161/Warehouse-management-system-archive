using Whm.Data.EF.Repositories.Interfaces;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmProductOutputRepository : IBaseRepository<WhmProductOuput>
    {
        public void AddProductOutput(WhmProductOuput whmProductOuput);
    }
}
