using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmProductOutputDetailsRepository :BaseRepository<WhmProductOutputDetail> ,IWhmProductOutputDetailsRepository
    {
        public WhmProductOutputDetailsRepository(AppDbContext context) : base(context)
        {
        }
        public void AddOutputProductDetails(List<WhmProductOutputDetail> whmProductOutputDetails)
        {
            _context.Set<WhmProductOutputDetail>().AddRange(whmProductOutputDetails);
            _context.SaveChanges();
        }
    }
}
