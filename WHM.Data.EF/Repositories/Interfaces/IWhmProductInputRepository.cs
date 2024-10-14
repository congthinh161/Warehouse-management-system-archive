using Whm.Data.EF.Repositories.Interfaces;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmProductInputRepository : IBaseRepository<WhmProductInput>
    {
        public void AddProductInput(WhmProductInput whmProductInput);
    }
}
