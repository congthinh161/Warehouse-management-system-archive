using Whm.Data.EF.Repositories.Interfaces;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmProductRepository : IBaseRepository<WhmProduct>
    {
        public IQueryable<WhmProduct> GetProductWithCate();
        public IQueryable<WhmProduct> GetProductAttribute(Guid productId);
        public void UpdateProduct(WhmProduct whmProduct);

    }
}
