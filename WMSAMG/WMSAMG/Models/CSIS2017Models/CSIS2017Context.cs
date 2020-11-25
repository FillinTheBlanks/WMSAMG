using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class CSIS2017Context : DbContext
    {
        public CSIS2017Context()
        {
        }

        public CSIS2017Context(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public CSIS2017Context(DbContextOptions<CSIS2017Context> options)
            : base(options)
        {
        }

        public virtual DbSet<HrAttGroup> HrAttGroup { get; set; }
        public virtual DbSet<HrGeneralLog> HrGeneralLog { get; set; }
        public virtual DbSet<HrGeneralLogTemp> HrGeneralLogTemp { get; set; }
        public virtual DbSet<HrGeneralLogTempTest> HrGeneralLogTempTest { get; set; }
        public virtual DbSet<Stccsd1c89366020456> Stccsd1c89366020456 { get; set; }
        public virtual DbSet<Strdmfgkevinc89366020456> Strdmfgkevinc89366020456 { get; set; }
        public virtual DbSet<Strdmfgkevinc99842642670> Strdmfgkevinc99842642670 { get; set; }
        public virtual DbSet<Swccsd1c26915609778> Swccsd1c26915609778 { get; set; }
        public virtual DbSet<Swccsd1c89366020456> Swccsd1c89366020456 { get; set; }
        public virtual DbSet<Swrdmfgkevinc26915609778> Swrdmfgkevinc26915609778 { get; set; }
        public virtual DbSet<Swrdmfgkevinc61206934883> Swrdmfgkevinc61206934883 { get; set; }
        public virtual DbSet<Swrdmfgkevinc89366020456> Swrdmfgkevinc89366020456 { get; set; }
        public virtual DbSet<Swrdmfgkevinc99842642670> Swrdmfgkevinc99842642670 { get; set; }
        public virtual DbSet<TblBeginningBalanceDetail> TblBeginningBalanceDetail { get; set; }
        public virtual DbSet<TblBillingStatementRecord> TblBillingStatementRecord { get; set; }
        public virtual DbSet<TblBmiplist> TblBmiplist { get; set; }
        public virtual DbSet<TblChargingLogs> TblChargingLogs { get; set; }
        public virtual DbSet<TblDashboardDefault> TblDashboardDefault { get; set; }
        public virtual DbSet<TblDtrreport> TblDtrreport { get; set; }
        public virtual DbSet<TblEquipmentCharges> TblEquipmentCharges { get; set; }
        public virtual DbSet<TblLogs> TblLogs { get; set; }
        public virtual DbSet<TblManpowerCharges> TblManpowerCharges { get; set; }
        public virtual DbSet<TblMasterTransaction> TblMasterTransaction { get; set; }
        public virtual DbSet<TblPaymentRecord> TblPaymentRecord { get; set; }
        public virtual DbSet<TblReceivingDetail> TblReceivingDetail { get; set; }
        public virtual DbSet<TblReceivingDetailDeleted> TblReceivingDetailDeleted { get; set; }
        public virtual DbSet<TblScheduleCarrier> TblScheduleCarrier { get; set; }
        public virtual DbSet<TblStockReturnDetail> TblStockReturnDetail { get; set; }
        public virtual DbSet<TblStockTransferDetail> TblStockTransferDetail { get; set; }
        public virtual DbSet<TblStockWithdrawalDetail> TblStockWithdrawalDetail { get; set; }
        public virtual DbSet<TblStorageTimeFrame> TblStorageTimeFrame { get; set; }
        public virtual DbSet<TblTempUserFp> TblTempUserFp { get; set; }
        public virtual DbSet<TblTempUserFp08262019> TblTempUserFp08262019 { get; set; }
        public virtual DbSet<TblTempUserFpTest> TblTempUserFpTest { get; set; }
        public virtual DbSet<TblTempUserInfo> TblTempUserInfo { get; set; }
        public virtual DbSet<TblTruckDetails> TblTruckDetails { get; set; }
        public virtual DbSet<TempPallet> TempPallet { get; set; }
        public virtual DbSet<VwActualInventory> VwActualInventory { get; set; }
        public virtual DbSet<VwBeginningBalanceDetailnoSl> VwBeginningBalanceDetailnoSl { get; set; }
        public virtual DbSet<VwBillingDetail> VwBillingDetail { get; set; }
        public virtual DbSet<VwEquipmentCharges> VwEquipmentCharges { get; set; }
        public virtual DbSet<VwGllog> VwGllog { get; set; }
        public virtual DbSet<VwGllogTemp> VwGllogTemp { get; set; }
        public virtual DbSet<VwInventory> VwInventory { get; set; }
        public virtual DbSet<VwManpowerCharges> VwManpowerCharges { get; set; }
        public virtual DbSet<VwMasterTransactions> VwMasterTransactions { get; set; }
        public virtual DbSet<VwReceivingDetail> VwReceivingDetail { get; set; }
        public virtual DbSet<VwReceivingDetailnoSl> VwReceivingDetailnoSl { get; set; }
        public virtual DbSet<VwScheduleCarrier> VwScheduleCarrier { get; set; }
        public virtual DbSet<VwStockReturnDetail> VwStockReturnDetail { get; set; }
        public virtual DbSet<VwStockTransferDetail> VwStockTransferDetail { get; set; }
        public virtual DbSet<VwStockWithdrawalDetail> VwStockWithdrawalDetail { get; set; }
        public virtual DbSet<VwStockWithdrawalDetailwithAmount> VwStockWithdrawalDetailwithAmount { get; set; }
        public virtual DbSet<VwStorageTimeFrameDetail> VwStorageTimeFrameDetail { get; set; }

        private readonly IConfiguration _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=(local);Database=CSIS2017;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DataContextConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrGeneralLog>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.EnrollNo, e.Glcount, e.VerifyMode, e.InOutMode, e.DateTimeLog })
                    .HasName("_dta_index_HR.GeneralLog_c_5_820197972__K2_K1_K3_K4_K5")
                    .IsClustered();

                entity.Property(e => e.EnrollNo).IsFixedLength();

                entity.Property(e => e.Glcount).IsFixedLength();

                entity.Property(e => e.InOutMode).IsFixedLength();

                entity.Property(e => e.VerifyMode).IsFixedLength();
            });

            modelBuilder.Entity<HrGeneralLogTemp>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.EnrollNo, e.Glcount, e.VerifyMode, e.InOutMode, e.DateTimeLog })
                    .HasName("_dta_index_HR.GeneralLogTemp_c_5_820197972__K2_K1_K3_K4_K5")
                    .IsClustered();

                entity.Property(e => e.EnrollNo).IsFixedLength();

                entity.Property(e => e.Glcount).IsFixedLength();

                entity.Property(e => e.InOutMode).IsFixedLength();

                entity.Property(e => e.VerifyMode).IsFixedLength();
            });

            modelBuilder.Entity<HrGeneralLogTempTest>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EnrollNo).IsFixedLength();

                entity.Property(e => e.Glcount).IsFixedLength();

                entity.Property(e => e.InOutMode).IsFixedLength();

                entity.Property(e => e.VerifyMode).IsFixedLength();
            });

            modelBuilder.Entity<Stccsd1c89366020456>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Strdmfgkevinc89366020456>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Strdmfgkevinc99842642670>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swccsd1c26915609778>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swccsd1c89366020456>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swrdmfgkevinc26915609778>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swrdmfgkevinc61206934883>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swrdmfgkevinc89366020456>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Swrdmfgkevinc99842642670>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblBeginningBalanceDetail>(entity =>
            {
                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblBillingStatementRecord>(entity =>
            {
                entity.Property(e => e.No).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblBmiplist>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Ipaddress).IsFixedLength();

                entity.Property(e => e.Ipport).IsFixedLength();
            });

            modelBuilder.Entity<TblChargingLogs>(entity =>
            {
                entity.Property(e => e.RefNum).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ReferenceNo).IsUnicode(false);

                entity.Property(e => e.Rrnumber).IsUnicode(false);
            });

            modelBuilder.Entity<TblDashboardDefault>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TblDtrreport>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.FullName, e.DateYear, e.DateMonth, e.DateDay })
                    .HasName("_dta_index_tblDTRReport_c_5_480720765__K2_K3_K4_K5")
                    .IsClustered();

                entity.Property(e => e.DateMonth).IsFixedLength();

                entity.Property(e => e.FullName).IsFixedLength();
            });

            modelBuilder.Entity<TblEquipmentCharges>(entity =>
            {
                entity.Property(e => e.RefNum).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblLogs>(entity =>
            {
                entity.Property(e => e.LogId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblManpowerCharges>(entity =>
            {
                entity.Property(e => e.RefNum).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblMasterTransaction>(entity =>
            {
                entity.HasKey(e => e.RefCode)
                    .HasName("PK_tblStockCardDetail");

                entity.Property(e => e.RefCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblPaymentRecord>(entity =>
            {
                entity.Property(e => e.PaymentNo).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblReceivingDetail>(entity =>
            {
                entity.HasKey(e => e.ReferenceCode)
                    .HasName("PK_tblReceivingProcess");

                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblReceivingDetailDeleted>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblScheduleCarrier>(entity =>
            {
                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStockReturnDetail>(entity =>
            {
                entity.HasKey(e => e.ReferenceCode)
                    .HasName("PK_tblStockReturnDetails");

                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStockTransferDetail>(entity =>
            {
                entity.HasKey(e => e.ReferenceCode)
                    .HasName("PK_tblStockTransferDetails");

                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStockWithdrawalDetail>(entity =>
            {
                entity.HasKey(e => e.ReferenceCode)
                    .HasName("PK_tblStockWithdrawalDetails");

                entity.Property(e => e.ReferenceCode).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblStorageTimeFrame>(entity =>
            {
                entity.Property(e => e.StorageTimeFrameId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblTempUserFp>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BioType).IsFixedLength();

                entity.Property(e => e.Fpindex).IsFixedLength();

                entity.Property(e => e.IsDuress).IsFixedLength();

                entity.Property(e => e.IsValid).IsFixedLength();

                entity.Property(e => e.Tmp).IsFixedLength();

                entity.Property(e => e.TmpFormat).IsFixedLength();

                entity.Property(e => e.TmpNo).IsFixedLength();

                entity.Property(e => e.TmpVersion).IsFixedLength();

                entity.Property(e => e.UserId).IsFixedLength();
            });

            modelBuilder.Entity<TblTempUserFp08262019>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CardNo).IsFixedLength();

                entity.Property(e => e.FingerIndex).IsFixedLength();

                entity.Property(e => e.Flag).IsFixedLength();

                entity.Property(e => e.Fp).IsFixedLength();

                entity.Property(e => e.FullName).IsFixedLength();

                entity.Property(e => e.Passcode).IsFixedLength();

                entity.Property(e => e.Privilege).IsFixedLength();

                entity.Property(e => e.StatusMsg).IsFixedLength();

                entity.Property(e => e.UserId).IsFixedLength();
            });

            modelBuilder.Entity<TblTempUserFpTest>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CardNo).IsFixedLength();

                entity.Property(e => e.FingerIndex).IsFixedLength();

                entity.Property(e => e.Flag).IsFixedLength();

                entity.Property(e => e.Fp).IsFixedLength();

                entity.Property(e => e.FullName).IsFixedLength();

                entity.Property(e => e.Passcode).IsFixedLength();

                entity.Property(e => e.StatusMsg).IsFixedLength();

                entity.Property(e => e.UserId).IsFixedLength();
            });

            modelBuilder.Entity<TblTempUserInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CardNo).IsFixedLength();

                entity.Property(e => e.Passcode).IsFixedLength();

                entity.Property(e => e.UserId).IsFixedLength();
            });

            modelBuilder.Entity<TblTruckDetails>(entity =>
            {
                entity.Property(e => e.RefId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TempPallet>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PalletType).IsUnicode(false);
            });

            modelBuilder.Entity<VwActualInventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ActualInventory");
            });

            modelBuilder.Entity<VwBeginningBalanceDetailnoSl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_BeginningBalanceDetailnoSL");
            });

            modelBuilder.Entity<VwBillingDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_BillingDetail");
            });

            modelBuilder.Entity<VwEquipmentCharges>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EquipmentCharges");
            });

            modelBuilder.Entity<VwGllog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GLLog");

                entity.Property(e => e.EnrollNo).IsFixedLength();

                entity.Property(e => e.Glcount).IsFixedLength();

                entity.Property(e => e.InOutMode).IsFixedLength();

                entity.Property(e => e.VerifyMode).IsFixedLength();
            });

            modelBuilder.Entity<VwGllogTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GLLogTemp");

                entity.Property(e => e.EnrollNo).IsFixedLength();

                entity.Property(e => e.Glcount).IsFixedLength();

                entity.Property(e => e.VerifyMode).IsFixedLength();
            });

            modelBuilder.Entity<VwInventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Inventory");
            });

            modelBuilder.Entity<VwManpowerCharges>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ManpowerCharges");
            });

            modelBuilder.Entity<VwMasterTransactions>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_MasterTransactions");
            });

            modelBuilder.Entity<VwReceivingDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ReceivingDetail");
            });

            modelBuilder.Entity<VwReceivingDetailnoSl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ReceivingDetailnoSL");
            });

            modelBuilder.Entity<VwScheduleCarrier>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ScheduleCarrier");
            });

            modelBuilder.Entity<VwStockReturnDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StockReturnDetail");
            });

            modelBuilder.Entity<VwStockTransferDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StockTransferDetail");
            });

            modelBuilder.Entity<VwStockWithdrawalDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StockWithdrawalDetail");
            });

            modelBuilder.Entity<VwStockWithdrawalDetailwithAmount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StockWithdrawalDetailwithAmount");
            });

            modelBuilder.Entity<VwStorageTimeFrameDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_StorageTimeFrameDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
