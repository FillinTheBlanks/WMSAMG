using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WMSAMG.Models.PRACTICEDB
{
    public partial class PRACTICEDBContext : DbContext
    {
        public PRACTICEDBContext()
        {
        }

        public PRACTICEDBContext(DbContextOptions<PRACTICEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeView> EmployeeViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PRACTICEDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptCode)
                    .HasName("PK__tmp_ms_x__8985FE74043BF62F");

                entity.Property(e => e.DeptName).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmpCity).IsUnicode(false);

                entity.Property(e => e.EmpName).IsUnicode(false);

                entity.HasOne(d => d.DeptCodeNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptCode)
                    .HasConstraintName("FK_employees_ToDepartment");
            });

            modelBuilder.Entity<EmployeeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("employeesView");

                entity.Property(e => e.DeptName).IsUnicode(false);

                entity.Property(e => e.EmpCity).IsUnicode(false);

                entity.Property(e => e.EmpName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
