using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmAttributeRepository : BaseRepository<WhmAttribute>, IWhmAttributeRepository
    {
        public WhmAttributeRepository(AppDbContext context) : base(context)
        {
        }

    }
}
