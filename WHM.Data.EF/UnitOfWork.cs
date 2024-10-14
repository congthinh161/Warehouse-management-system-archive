using WHM.Data.EF.Repositories;
using WHM.Data.EF.Repositories.Interfaces;

namespace Whm.Data.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;

        private readonly AppDbContext _context;

        private IWhmAccountRepository _whmAccountRepository;
        private IWhmAttributeRepository _whmAttributeRepository;
        private IWhmProductInputRepository _whmProductInputRepository;
        private IWhmProductOutputRepository _whmProductOutputRepository;
        private IWhmProductInputDetailsRepository _whmProductInputDetailsRepository;
        private IWhmProductOutputDetailsRepository _whmProductOutputDetailsRepository;
        private IWhmCategoryRepository _whmCategoryRepository;
        private IWhmSupplierRepository _whmSupplierRepository;
        private IWhmProductRepository _whmProductRepository;
        private IWhmAttributeValueRepository _whmAttributeValueRepository;
        private IWhmProductAttributeValueRepository whmProductAttributeValueRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IWhmAccountRepository WhmAccountRepository
        {
            get
            {
                if (this._whmAccountRepository is null)
                {
                    this._whmAccountRepository = new WhmAccountRepository(_context);
                }
                return _whmAccountRepository;
            }
        }

        public IWhmAttributeRepository WhmAttributeRepository {
            get
            {
                if (this._whmAttributeRepository is null)
                {
                    this._whmAttributeRepository = new WhmAttributeRepository(_context);
                }
                return _whmAttributeRepository;
            }
        }

        public IWhmProductInputRepository WhmProductInputRepository
        {
            get
            {
                if (this._whmProductInputRepository is null)
                {
                    this._whmProductInputRepository = new WhmProductInputRepository(_context);
                }
                return _whmProductInputRepository;
            }
        }
        public IWhmProductInputDetailsRepository WhmProductInputDetailsRepository
        {
            get
            {
                if (this._whmProductInputDetailsRepository is null)
                {
                    this._whmProductInputDetailsRepository = new WhmProductInputDetailsRepository(_context);
                }
                return _whmProductInputDetailsRepository;
            }
        }

        public IWhmProductOutputRepository WhmProductOutputRepository {
            get
            {
                if (this._whmProductOutputRepository is null)
                {
                    this._whmProductOutputRepository = new WhmProductOutputRepository(_context);
                }
                return _whmProductOutputRepository;
            }
        }
        public IWhmProductOutputDetailsRepository WhmProductOutputDetailsRepository {
            get
            {
                if (this._whmProductOutputDetailsRepository is null)
                {
                    this._whmProductOutputDetailsRepository = new WhmProductOutputDetailsRepository(_context);
                }
                return _whmProductOutputDetailsRepository;
            }
        }

        public IWhmCategoryRepository WhmCategoryRepository
        {
            get
            {
                if (this._whmCategoryRepository is null)
                {
                    this._whmCategoryRepository = new WhmCategoryRepository(_context);
                }
                return _whmCategoryRepository;
            }
        }

        public IWhmSupplierRepository WhmSupplierRepository
        {
            get
            {
                if (this._whmSupplierRepository is null)
                {
                    this._whmSupplierRepository = new WhmSupplierRepository(_context);
                }
                return _whmSupplierRepository;
            }
        }

        public IWhmProductRepository WhmProductRepository
        {
            get
            {
                if (this._whmProductRepository is null)
                {
                    this._whmProductRepository = new WhmProductRepository(_context);
                }
                return _whmProductRepository;
            }
        }

        public IWhmAttributeValueRepository WhmAttributeValue
        {
            get
            {
                if (this._whmAttributeValueRepository is null)
                {
                    this._whmAttributeValueRepository = new WhmAttributeValueRepository(_context);
                }
                return _whmAttributeValueRepository;
            }
        }

        public IWhmProductAttributeValueRepository WhmProductAttributeValue
        {
            get
            {
                if (this.whmProductAttributeValueRepository is null)
                {
                    this.whmProductAttributeValueRepository = new WhmProductAttributeValueRepository(_context);
                }
                return whmProductAttributeValueRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
