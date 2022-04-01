using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dataannotation_demo.Models.EF.Shopping
{
    public partial class shoppingAPPMVCContext : DbContext
    {
        public shoppingAPPMVCContext()
        {
        }

        public shoppingAPPMVCContext(DbContextOptions<shoppingAPPMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeptInfo> DeptInfos { get; set; }
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-H5HFUEB\\TRAINERINSTANCE; database=shoppingAPPMVC; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__customer__D830D4778FDB10A9");

                entity.ToTable("customers");

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("cId");

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity");

                entity.Property(e => e.CCustomerType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCustomerType");

                entity.Property(e => e.CIsActive).HasColumnName("cIsActive");

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName");

                entity.Property(e => e.CWalletBalance).HasColumnName("cWalletBalance");
            });

            modelBuilder.Entity<DeptInfo>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK__deptInfo__BE2D3F5595C2AAEC");

                entity.ToTable("deptInfo");

                entity.Property(e => e.DeptNo)
                    .ValueGeneratedNever()
                    .HasColumnName("deptNo");

                entity.Property(e => e.DeptHead)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deptHead");

                entity.Property(e => e.DeptLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deptLocation");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK__Employee__AFB335929184FE80");

                entity.ToTable("EmployeeInfo");

                entity.Property(e => e.EmpNo)
                    .ValueGeneratedNever()
                    .HasColumnName("empNo");

                entity.Property(e => e.EmpDept).HasColumnName("empDept");

                entity.Property(e => e.EmpDesignation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empDesignation");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empName");

                entity.Property(e => e.EmpSalary).HasColumnName("empSalary");

                entity.HasOne(d => d.EmpDeptNavigation)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.EmpDept)
                    .HasConstraintName("fk_empDept");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__products__DD36D562FDDBA402");

                entity.ToTable("products");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("pId");

                entity.Property(e => e.PCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pCategory");

                entity.Property(e => e.PDiscount).HasColumnName("pDiscount");

                entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");

                entity.Property(e => e.PName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pName");

                entity.Property(e => e.PPrice).HasColumnName("pPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
