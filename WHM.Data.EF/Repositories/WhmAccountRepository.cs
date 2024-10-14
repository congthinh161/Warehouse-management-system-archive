using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmAccountRepository : BaseRepository<WhmAccount>, IWhmAccountRepository
    {
        public WhmAccountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
