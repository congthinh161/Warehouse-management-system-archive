using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using Whm.Infrastructure.Constants;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmCategoryRepository : BaseRepository<WhmCategory>, IWhmCategoryRepository
    {
        public WhmCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<WhmCategory> GetCategorys()
        {
            return _context.Set<WhmCategory>().Where(a => a.IsDelete.Equals(Common.IsNotDelete));
        }
        public void AddCategory(WhmCategory whmCategory)
        {
            _context.Set<WhmCategory>().Add(whmCategory);
            _context.SaveChanges();
        }

        public WhmCategory GetCategoryById(Guid categoryId)
        {
            return _context.Set<WhmCategory>().FirstOrDefault(c => c.CategoryId.Equals(categoryId)
                                && c.IsDelete.Equals(Common.IsNotDelete));
        }

        public IQueryable<WhmCategory> SearchCategoryByName(string categoryName)
        {
            return _context.Set<WhmCategory>().Where(c => c.CategoryName.ToLower().Contains(categoryName.ToLower()))
                                              .Where(a => a.IsDelete.Equals(Common.IsNotDelete));
        }

        public void UpdateCategory(WhmCategory whmCategory)
        {
            _context.Set<WhmCategory>().Update(whmCategory);
            _context.SaveChanges();
        }

        public void AddCategoryAttribute(WhmCategoryAttribute whmCategoryAttribute)
        {
            _context.Set<WhmCategoryAttribute>().Add(whmCategoryAttribute);
            _context.SaveChanges();
        }
    }
}
