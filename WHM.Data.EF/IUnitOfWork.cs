using WHM.Data.EF.Repositories.Interfaces;

namespace Whm.Data.EF
{
    public interface IUnitOfWork
    {
        public IWhmAccountRepository WhmAccountRepository { get; }
        public IWhmAttributeRepository WhmAttributeRepository { get; }
        public IWhmProductInputRepository WhmProductInputRepository { get; }
        public IWhmProductOutputRepository WhmProductOutputRepository { get; }
        public IWhmProductInputDetailsRepository WhmProductInputDetailsRepository { get; }
        public IWhmProductOutputDetailsRepository WhmProductOutputDetailsRepository { get; }
        public IWhmCategoryRepository WhmCategoryRepository { get; }
        public IWhmSupplierRepository WhmSupplierRepository { get; }
        public IWhmProductRepository WhmProductRepository { get; }
        public IWhmAttributeValueRepository WhmAttributeValue { get; }
        public IWhmProductAttributeValueRepository WhmProductAttributeValue { get; }

        public Task CommitAsync();

        public void Commit();
    }
}
