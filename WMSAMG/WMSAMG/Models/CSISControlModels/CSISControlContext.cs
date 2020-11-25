using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class CSISControlContext : DbContext
    {
        public CSISControlContext()
        {
            
        }
        public CSISControlContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public CSISControlContext(DbContextOptions<CSISControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBankDetail> TblBankDetail { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblCustomerPersonnel> TblCustomerPersonnel { get; set; }
        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblDocumentStub> TblDocumentStub { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEquipment> TblEquipment { get; set; }
        public virtual DbSet<TblEquipmentCategory> TblEquipmentCategory { get; set; }
        public virtual DbSet<TblLocation> TblLocation { get; set; }
        public virtual DbSet<TblManpower> TblManpower { get; set; }
        public virtual DbSet<TblNature> TblNature { get; set; }
        public virtual DbSet<TblNavGroup> TblNavGroup { get; set; }
        public virtual DbSet<TblPallet> TblPallet { get; set; }
        public virtual DbSet<TblPayType> TblPayType { get; set; }
        public virtual DbSet<TblPermissionSet> TblPermissionSet { get; set; }
        public virtual DbSet<TblPostFile> TblPostFile { get; set; }
        public virtual DbSet<TblRack> TblRack { get; set; }
        public virtual DbSet<TblStock> TblStock { get; set; }
        public virtual DbSet<TblStockGroup> TblStockGroup { get; set; }
        public virtual DbSet<TblStorage> TblStorage { get; set; }
        public virtual DbSet<TblStorageDimension> TblStorageDimension { get; set; }
        public virtual DbSet<TblStorageLocation> TblStorageLocation { get; set; }
        public virtual DbSet<TblStorageType> TblStorageType { get; set; }
        public virtual DbSet<TblTempPostFile> TblTempPostFile { get; set; }
        public virtual DbSet<TblTreeControl> TblTreeControl { get; set; }
        public virtual DbSet<TblUserAccount> TblUserAccount { get; set; }
        public virtual DbSet<TblUserGroup> TblUserGroup { get; set; }
        public virtual DbSet<VwCustomerPersonnel> VwCustomerPersonnel { get; set; }
        public virtual DbSet<VwCustomertoCompanyandLocation> VwCustomertoCompanyandLocation { get; set; }
        public virtual DbSet<VwCustomertoPersonnel> VwCustomertoPersonnel { get; set; }
        public virtual DbSet<VwDepartmenttoCompany> VwDepartmenttoCompany { get; set; }
        public virtual DbSet<VwDocumentStub> VwDocumentStub { get; set; }
        public virtual DbSet<VwEmployeetoDepartmentandCompany> VwEmployeetoDepartmentandCompany { get; set; }
        public virtual DbSet<VwEquipmenttoCategory> VwEquipmenttoCategory { get; set; }
        public virtual DbSet<VwLocation> VwLocation { get; set; }
        public virtual DbSet<VwManpower> VwManpower { get; set; }
        public virtual DbSet<VwNavGroup> VwNavGroup { get; set; }
        public virtual DbSet<VwPallet> VwPallet { get; set; }
        public virtual DbSet<VwRequestorApprover> VwRequestorApprover { get; set; }
        public virtual DbSet<VwStocktoStockGrouptoCustomerandCompany> VwStocktoStockGrouptoCustomerandCompany { get; set; }
        public virtual DbSet<VwStorageRack> VwStorageRack { get; set; }
        public virtual DbSet<VwStoragetoLocation> VwStoragetoLocation { get; set; }
        public virtual DbSet<VwStoragetoType> VwStoragetoType { get; set; }
        public virtual DbSet<VwUserAccount> VwUserAccount { get; set; }
        public virtual DbSet<VwUserAccounttoEmployeetoGrouptoTree> VwUserAccounttoEmployeetoGrouptoTree { get; set; }
        public virtual DbSet<VwUserGrouptoTreeControl> VwUserGrouptoTreeControl { get; set; }

        private readonly IConfiguration _configuration;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CSISControl;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=(local);Database=CSISControl;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AuthContextConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBankDetail>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.Property(e => e.CompanyId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblCustomerPersonnel>(entity =>
            {
                entity.Property(e => e.CustomerPersonnelId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.CompanyId });

                entity.Property(e => e.DepartmentId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblDocumentStub>(entity =>
            {
                entity.Property(e => e.DocumentStubNo).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Nature).IsFixedLength();
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasIndex(e => new { e.EmployeeId, e.EmployeeFname, e.EmployeeMname, e.EmployeeLname, e.EnrollNo, e.AttGroup })
                    .HasName("NonClusteredIndex-20191224-120906");

                entity.Property(e => e.EmployeeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AttGroup).IsFixedLength();

                entity.Property(e => e.EmployeeGender).IsFixedLength();

                entity.Property(e => e.EnrollNo).IsFixedLength();
            });

            modelBuilder.Entity<TblEquipment>(entity =>
            {
                entity.Property(e => e.EquipmentId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblEquipmentCategory>(entity =>
            {
                entity.Property(e => e.EquipmentCategoryId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.Property(e => e.LocationId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblManpower>(entity =>
            {
                entity.Property(e => e.ManpowerId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblNature>(entity =>
            {
                entity.Property(e => e.Nature).IsFixedLength();
            });

            modelBuilder.Entity<TblNavGroup>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblPayType>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblPermissionSet>(entity =>
            {
                entity.Property(e => e.No).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblPostFile>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblRack>(entity =>
            {
                entity.Property(e => e.RackId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStock>(entity =>
            {
                entity.Property(e => e.StockId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStockGroup>(entity =>
            {
                entity.Property(e => e.StockGroupId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStorage>(entity =>
            {
                entity.Property(e => e.StorageId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStorageDimension>(entity =>
            {
                entity.HasKey(e => e.StorageDimensionInitial)
                    .HasName("PK_tblStorageLocation_1");
            });

            modelBuilder.Entity<TblStorageLocation>(entity =>
            {
                entity.Property(e => e.StorageLocationId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStorageType>(entity =>
            {
                entity.Property(e => e.StorageTypeId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblTempPostFile>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblTreeControl>(entity =>
            {
                entity.Property(e => e.ParentChild).IsFixedLength();

                entity.Property(e => e.Status).IsFixedLength();
            });

            modelBuilder.Entity<TblUserAccount>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UserGroupId });

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<VwCustomerPersonnel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CustomerPersonnel");
            });

            modelBuilder.Entity<VwCustomertoCompanyandLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CustomertoCompanyandLocation");
            });

            modelBuilder.Entity<VwCustomertoPersonnel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_CustomertoPersonnel");

                entity.Property(e => e.CompanyId).IsFixedLength();

                entity.Property(e => e.CustomerEmail).IsFixedLength();

                entity.Property(e => e.CustomerId).IsFixedLength();

                entity.Property(e => e.Expr1).IsFixedLength();
            });

            modelBuilder.Entity<VwDepartmenttoCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_DepartmenttoCompany");
            });

            modelBuilder.Entity<VwDocumentStub>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_DocumentStub");

                entity.Property(e => e.Nature).IsFixedLength();
            });

            modelBuilder.Entity<VwEmployeetoDepartmentandCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EmployeetoDepartmentandCompany");

                entity.Property(e => e.EmployeeGender).IsFixedLength();

                entity.Property(e => e.EnrollNo).IsFixedLength();
            });

            modelBuilder.Entity<VwEquipmenttoCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EquipmenttoCategory");
            });

            modelBuilder.Entity<VwLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Location");
            });

            modelBuilder.Entity<VwManpower>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Manpower");
            });

            modelBuilder.Entity<VwNavGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_NavGroup");
            });

            modelBuilder.Entity<VwPallet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Pallet");
            });

            modelBuilder.Entity<VwRequestorApprover>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_RequestorApprover");
            });

            modelBuilder.Entity<VwStocktoStockGrouptoCustomerandCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StocktoStockGrouptoCustomerandCompany");
            });

            modelBuilder.Entity<VwStorageRack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StorageRack");

                entity.Property(e => e.RackCapacity).IsUnicode(false);
            });

            modelBuilder.Entity<VwStoragetoLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StoragetoLocation");

                entity.Property(e => e.RackCapacity).IsUnicode(false);
            });

            modelBuilder.Entity<VwStoragetoType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StoragetoType");
            });

            modelBuilder.Entity<VwUserAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_UserAccount");
            });

            modelBuilder.Entity<VwUserAccounttoEmployeetoGrouptoTree>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_UserAccounttoEmployeetoGrouptoTree");

                entity.Property(e => e.CompanyId).IsFixedLength();

                entity.Property(e => e.EmployeeId).IsFixedLength();

                entity.Property(e => e.Expr1).IsFixedLength();

                entity.Property(e => e.Expr2).IsFixedLength();

                entity.Property(e => e.Expr3).IsFixedLength();

                entity.Property(e => e.Expr4).IsFixedLength();

                entity.Property(e => e.TreeId).IsFixedLength();

                entity.Property(e => e.UserGroupId).IsFixedLength();
            });

            modelBuilder.Entity<VwUserGrouptoTreeControl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_UserGrouptoTreeControl");

                entity.Property(e => e.ParentChild).IsFixedLength();

                entity.Property(e => e.Status).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
