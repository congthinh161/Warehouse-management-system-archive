using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.Entities;

namespace WHM.Data.EF.Repositories.Interfaces
{
    public interface IWhmProductOutputDetailsRepository
    {
        public void AddOutputProductDetails(List<WhmProductOutputDetail> whmProductOutputDetails);
    }
}
