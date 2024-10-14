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
    public class WhmProductInputDetailsRepository : BaseRepository<WhmProductInputDetail>, IWhmProductInputDetailsRepository
    {
        public WhmProductInputDetailsRepository(AppDbContext context) : base(context)
        {
        }
        public void AddProductInputDetails(WhmProductInputDetail whmProductInputDetail)
        {
            _context.Set<WhmProductInputDetail>().Add(whmProductInputDetail);
            _context.SaveChanges();
        }
    }
}
