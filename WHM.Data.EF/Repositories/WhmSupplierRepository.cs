using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHM.Data.EF.Repositories.Interfaces;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using Whm.Data.EF;

namespace WHM.Data.EF.Repositories
{
    public class WhmSupplierRepository : BaseRepository<WhmSuplier>, IWhmSupplierRepository
    {
        public WhmSupplierRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<WhmSuplier> GetSupliers()
        {
            return _context.Set<WhmSuplier>();
        }

        public void AddSupplier(WhmSuplier whmSuplier)
        {
            _context.Set<WhmSuplier>().Add(whmSuplier);
        }

        public void UpdateSupplier(WhmSuplier whmSuplier)
        {
            _context.Set<WhmSuplier>().Update(whmSuplier);
        }

        public WhmSuplier GetSupplierById(Guid id)
        {
            return _context.Set<WhmSuplier>().FirstOrDefault(x => x.SuplierId == id && !x.IsDelete);
        }

        public IQueryable<WhmSuplier> SearchSupplier(string supplierName)
        {
            return _context.Set<WhmSuplier>().Where(x => x.DisplayName.ToLower().Contains(supplierName.ToLower()) && !x.IsDelete);
        }
    }
}
