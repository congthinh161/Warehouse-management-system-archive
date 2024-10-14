using Microsoft.EntityFrameworkCore;
using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmProductRepository : BaseRepository<WhmProduct>, IWhmProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public WhmProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public IQueryable<WhmProduct> GetProductWithCate()
        {
            return _appDbContext.WhmProducts
                .Include(x => x.CategoryIdNavigation);
        }

        public IQueryable<WhmProduct> GetProductAttribute(Guid productId)
        {
            return _appDbContext.WhmProducts
                .Include(x => x.CategoryIdNavigation)
                .ThenInclude(x => x.WhmCategoryAttributes)
                .ThenInclude(x => x.WhmAttribute)
                .Where(x => x.ProductId.Equals(productId));
        }
        public void UpdateProduct(WhmProduct whmProduct)
        {
            _context.Set<WhmProduct>().Update(whmProduct);
            _context.SaveChanges();
        }
    }
}
