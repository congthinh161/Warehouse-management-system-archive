using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Whm.Data.Entities;
using Whm.Data.Entities.Interfaces;

namespace Whm.Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=14.225.210.49;Port=5432;Database=EFilmApplication;UserId=Efilm_Api;Password=Efilm_Dev_Postgres_2023@;Pooling=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }


        #region DbSet
        public DbSet<WhmAccount> WhmAccounts { get; set; }
        public DbSet<WhmClient> WhmClients { get; set; }
        public DbSet<WhmSuplier> WhmSupliers { get; set; }
        public DbSet<WhmProduct> WhmProducts { get; set; }
        public DbSet<WhmProductOutputDetail> WhmProductOutputDetails { get; set; }
        public DbSet<WhmProductInputDetail> WhmProductInputDetails { get; set; }
        public DbSet<WhmCategory> WhmCategories { get; set; }
        public DbSet<WhmCategoryAttribute> WhmCategoryAttributes { get; set; }
        public DbSet<WhmProductAttributeValue> WhmProductAttributeValues { get; set; }
        public DbSet<WhmProductOuput> WhmProductOuputs { get; set; }
        public DbSet<WhmProductInput> WhmProductInputs { get; set; }
        public DbSet<WhmAttribute> WhmAttributes { get; set; }
        public DbSet<WhmAttributeValue> WhmAttributeValues { get; set; }
        public DbSet<WhmServiceType> WhmServiceTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Whm_Account
            modelBuilder.Entity<WhmAccount>(cfg =>
            {
                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.Property(f => f.RoleId)
                    .HasDefaultValue(2);

            });
            #endregion

            #region Whm_Client
            modelBuilder.Entity<WhmClient>(cfg =>
            {
                cfg.Property(f => f.ClientId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmProductOutputs)
                    .WithOne(f => f.WhmClient)
                    .HasForeignKey(f => f.ClientId)
                    .HasPrincipalKey(f => f.ClientId);
            });
            #endregion

            #region Whm_Suplier
            modelBuilder.Entity<WhmSuplier>(cfg =>
            {
                cfg.Property(f => f.SuplierId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmProductInputs)
                    .WithOne(f => f.WhmSuplier)
                    .HasForeignKey(f => f.SuplierId)
                    .HasPrincipalKey(f => f.SuplierId);
            });
            #endregion

            #region Whm_Product
            modelBuilder.Entity<WhmProduct>(cfg =>
            {
                cfg.Property(f => f.ProductId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.HasMany(f => f.WhmProductAttributeValues)
                    .WithOne(f => f.WhmProductNav)
                    .HasForeignKey(f => f.ProductId)
                    .HasPrincipalKey(f => f.ProductId);

                cfg.HasMany(f => f.WhmProductOutputDetails)
                    .WithOne(f => f.WhmProduct)
                    .HasForeignKey(f => f.ProductId)
                    .HasPrincipalKey(f => f.ProductId);

                cfg.HasMany(f => f.WhmProductInputDetails)
                    .WithOne(f => f.WhmProduct)
                    .HasForeignKey(f => f.ProductId)
                    .HasPrincipalKey(f => f.ProductId);

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_ProductOutputDetails
            modelBuilder.Entity<WhmProductOutputDetail>(cfg =>
            {
                cfg.Property(f => f.ProdOutputDetailId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_ProductInputDetails
            modelBuilder.Entity<WhmProductInputDetail>(cfg =>
            {
                cfg.Property(f => f.ProdInputDetailId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_Category
            modelBuilder.Entity<WhmCategory>(cfg =>
            {
                cfg.Property(f => f.CategoryId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.HasMany(f => f.WhmProducts)
                    .WithOne(f => f.CategoryIdNavigation)
                    .HasForeignKey(f => f.CategoryId)
                    .HasPrincipalKey(f => f.CategoryId);

                cfg.HasMany(f => f.WhmCategoryAttributes)
                    .WithOne(f => f.WhmCategory)
                    .HasForeignKey(f => f.CategoryId)
                    .HasPrincipalKey(f => f.CategoryId);

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_CategoryAttribute
            modelBuilder.Entity<WhmCategoryAttribute>(cfg =>
            {
                cfg.Property(f => f.CategoryAttributeId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.HasKey(f => new { f.CategoryId, f.AttributeId });

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_ProductAttributeValue
            modelBuilder.Entity<WhmProductAttributeValue>(cfg =>
            {
                cfg.HasKey(f => new { f.ProductId, f.AttributeValueId });

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            #region Whm_ProductOuput
            modelBuilder.Entity<WhmProductOuput>(cfg =>
            {
                cfg.Property(f => f.ProdOuputId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmProductOutputDetails)
                    .WithOne(f => f.WhmProductOuput)
                    .HasForeignKey(f => f.ProdOutputDetailId)
                    .HasPrincipalKey(f => f.ProdOuputId);

            });
            #endregion

            #region Whm_ProductInput
            modelBuilder.Entity<WhmProductInput>(cfg =>
            {
                cfg.Property(f => f.ProdInputId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmProductInputDetails)
                    .WithOne(f => f.WhmProductInput)
                    .HasForeignKey(f => f.ProdInputId)
                    .HasPrincipalKey(f => f.ProdInputId);
            });
            #endregion

            #region Whm_ProductOutput
            modelBuilder.Entity<WhmProductOuput>(cfg =>
            {
                cfg.Property(f => f.ProdOuputId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmProductOutputDetails)
                    .WithOne(f => f.WhmProductOuput)
                    .HasForeignKey(f => f.ProdOutputId)
                    .HasPrincipalKey(f => f.ProdOuputId);

                cfg.HasOne(f => f.WhmServiceType)
                    .WithMany(f => f.WhmProductOuput)
                    .HasPrincipalKey(f => f.TypeId)
                    .HasForeignKey(f => f.ServiceTypeId);
            });
            #endregion

            #region Whm_Attribute
            modelBuilder.Entity<WhmAttribute>(cfg =>
            {
                cfg.Property(f => f.AttributeId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);

                cfg.HasMany(f => f.WhmCategoryAttributes)
                    .WithOne(f => f.WhmAttribute)
                    .HasForeignKey(f => f.AttributeId)
                    .HasPrincipalKey(f => f.AttributeId);

                cfg.HasMany(f => f.WhmAttributeValues)
                    .WithOne(f => f.WhmAttribute)
                    .HasForeignKey(f => f.AttributeId)
                    .HasPrincipalKey(f => f.AttributeId);
            });
            #endregion

            #region Whm_AttributeValue
            modelBuilder.Entity<WhmAttributeValue>(cfg =>
            {
                cfg.Property(f => f.AttributeValueId)
                    .HasValueGenerator<GuidValueGenerator>();

                cfg.HasMany(f => f.WhmProductAttributeValues)
                    .WithOne(f => f.WhmAttributeValueNav)
                    .HasForeignKey(f => f.AttributeValueId)
                    .HasPrincipalKey(f => f.AttributeValueId);

                cfg.Property(f => f.IsDelete)
                    .HasDefaultValue(false);
            });
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreateDate = DateTime.UtcNow;
                        changedOrAddedItem.CreateUser = "EFlim-System";
                    }
                    changedOrAddedItem.UpdateDate = DateTime.UtcNow;
                    changedOrAddedItem.UpdateUser = "EFlim-System";
                }
            }
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);
            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreateDate = DateTime.UtcNow;
                        changedOrAddedItem.CreateUser = "EFlim-System";
                    }
                    changedOrAddedItem.UpdateDate = DateTime.UtcNow;
                    changedOrAddedItem.UpdateUser = "EFlim-System";
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
