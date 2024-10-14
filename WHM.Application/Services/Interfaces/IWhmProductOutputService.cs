using WHM.Data.Dtos.Requests;
using Whm.Data.Entities;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmProductOutputService
    {
        public bool OutputProduct(List<WhmOutputProduct> WhmOutputProductsDetails, WhmProductOuput whmProductOuput);
    }
}
