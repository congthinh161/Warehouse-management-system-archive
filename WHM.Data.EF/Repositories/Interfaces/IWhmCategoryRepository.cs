using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.EF.Repositories.Interfaces;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmCategoryRepository : IBaseRepository<WhmCategory>
    {
        public IQueryable<WhmCategory> GetCategorys();
        public void AddCategory(WhmCategory whmCategory);
        public void AddCategoryAttribute(WhmCategoryAttribute whmCategoryAttribute);
        public void UpdateCategory(WhmCategory stmCategory);
        public WhmCategory GetCategoryById(Guid categoryId);
        public IQueryable<WhmCategory> SearchCategoryByName(string categoryName);
    }
}
