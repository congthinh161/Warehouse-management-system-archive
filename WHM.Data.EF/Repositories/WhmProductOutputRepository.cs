using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmProductOutputRepository : BaseRepository<WhmProductOuput>, IWhmProductOutputRepository
    {
        public WhmProductOutputRepository(AppDbContext context) : base(context)
        {
        }
        public void AddProductOutput(WhmProductOuput whmProductOuput)
        {
            _context.Set<WhmProductOuput>().Add(whmProductOuput);
            _context.SaveChanges();
        }
    }
}
