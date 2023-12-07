using Microsoft.EntityFrameworkCore;
using ProductList.Mvc.Models;

namespace ProductList.Mvc.Data;

public partial class ProductContext : DbContext
{
    public ProductContext()
    {
    }

    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;
    public virtual DbSet<BuildVersion> BuildVersions { get; set; } = null!;
    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
    public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; } = null!;
    public virtual DbSet<ProductModel> ProductModels { get; set; } = null!;
    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; } = null!;
    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;
    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; } = null!;
    public virtual DbSet<vGetAllCategory> vGetAllCategories { get; set; } = null!;
    public virtual DbSet<vProductAndDescription> vProductAndDescriptions { get; set; } = null!;
    public virtual DbSet<vProductModelCatalogDescription> vProductModelCatalogDescriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.HasKey(e => e.SystemInformationID)
                .HasName("PK__BuildVer__35E58ECA5DB1EB83");

            entity.Property(e => e.SystemInformationID).ValueGeneratedOnAdd();

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerID, e.AddressID })
                .HasName("PK_CustomerAddress_CustomerID_AddressID");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Address)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.Property(e => e.ErrorTime).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ParentProductCategory)
                .WithMany(p => p.InverseParentProductCategory)
                .HasForeignKey(d => d.ParentProductCategoryID)
                .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelID, e.ProductDescriptionID, e.Culture })
                .HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

            entity.Property(e => e.Culture).IsFixedLength();

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ProductDescription)
                .WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductDescriptionID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel)
                .WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductModelID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderID, e.SalesOrderDetailID })
                .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.Property(e => e.SalesOrderDetailID).ValueGeneratedOnAdd();

            entity.Property(e => e.LineTotal).HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false);

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderID)
                .HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.Property(e => e.SalesOrderID).HasDefaultValueSql("(NEXT VALUE FOR [SalesLT].[SalesOrderNumber])");

            entity.Property(e => e.Freight).HasDefaultValueSql("((0.00))");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.OnlineOrderFlag).HasDefaultValueSql("((1))");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SalesOrderNumber).HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***'))", false);

            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.Property(e => e.SubTotal).HasDefaultValueSql("((0.00))");

            entity.Property(e => e.TaxAmt).HasDefaultValueSql("((0.00))");

            entity.Property(e => e.TotalDue).HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false);

            entity.Property(e => e.rowguid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.BillToAddress)
                .WithMany(p => p.SalesOrderHeaderBillToAddresses)
                .HasForeignKey(d => d.BillToAddressID)
                .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress)
                .WithMany(p => p.SalesOrderHeaderShipToAddresses)
                .HasForeignKey(d => d.ShipToAddressID)
                .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
        });

        modelBuilder.Entity<vGetAllCategory>(entity =>
        {
            entity.ToView("vGetAllCategories", "SalesLT");
        });

        modelBuilder.Entity<vProductAndDescription>(entity =>
        {
            entity.ToView("vProductAndDescription", "SalesLT");

            entity.Property(e => e.Culture).IsFixedLength();
        });

        modelBuilder.Entity<vProductModelCatalogDescription>(entity =>
        {
            entity.ToView("vProductModelCatalogDescription", "SalesLT");

            entity.Property(e => e.ProductModelID).ValueGeneratedOnAdd();
        });

        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}