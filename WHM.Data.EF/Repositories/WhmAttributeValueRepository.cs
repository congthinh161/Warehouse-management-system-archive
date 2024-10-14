using Whm.Data.EF;
using Whm.Data.EF.Repositories;
using Whm.Data.Entities;
using WHM.Data.EF.Repositories.Interfaces;

namespace WHM.Data.EF.Repositories
{
    public class WhmAttributeValueRepository : BaseRepository<WhmAttributeValue>, IWhmAttributeValueRepository
    {
        public WhmAttributeValueRepository(AppDbContext context) : base(context)
        {
        }
    }
}
