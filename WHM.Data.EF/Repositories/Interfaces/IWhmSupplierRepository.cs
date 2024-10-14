using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.EF.Repositories.Interfaces;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmSupplierRepository : IBaseRepository<WhmSuplier>
    {
        public IQueryable<WhmSuplier> GetSupliers();
        public void AddSupplier(WhmSuplier whmSuplier);
        public void UpdateSupplier(WhmSuplier whmSuplier);
        public WhmSuplier GetSupplierById(Guid id);
        public IQueryable<WhmSuplier> SearchSupplier(string suplierName);
    }
}
