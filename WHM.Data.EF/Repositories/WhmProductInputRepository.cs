using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmProductInputRepository : BaseRepository<WhmProductInput>, IWhmProductInputRepository
    {
        public WhmProductInputRepository(AppDbContext context) : base(context)
        {
        }
        public void AddProductInput(WhmProductInput whmProductInput)
        {
            _context.Set<WhmProductInput>().Add(whmProductInput);
            _context.SaveChanges();
        }
    }
}
