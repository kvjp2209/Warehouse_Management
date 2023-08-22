using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Web_Api.Models;

namespace Web_Api.Data
{
    public partial class Project_Prn231Context : DbContext
    {
        public Project_Prn231Context()
        {
        }

        public Project_Prn231Context(DbContextOptions<Project_Prn231Context> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Auditable && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Auditable)entityEntry.Entity).ModifiedBy = "System";
                ((Auditable)entityEntry.Entity).ModifiedOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Auditable)entityEntry.Entity).CreatedBy = "System";
                    ((Auditable)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("CreatedBy").IsModified = false;
                    entityEntry.Property("CreatedOn").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<InventoryCheck> InventoryChecks { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string constr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().
                                    GetConnectionString("MyStoreDB").ToString();
                optionsBuilder.UseSqlServer(constr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.Property(e => e.BatchId).HasColumnName("batch_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.ExportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("export_date");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("import_date");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuantityIn).HasColumnName("quantity_in");

                entity.Property(e => e.QuantityOut).HasColumnName("quantity_out");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batch_Product");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batch_Supplier");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batch_Warehouse");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasColumnName("employee_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<InventoryCheck>(entity =>
            {
                entity.ToTable("InventoryCheck");

                entity.Property(e => e.InventoryCheckId).HasColumnName("inventory_check_id");

                entity.Property(e => e.CheckDate)
                    .HasColumnType("datetime")
                    .HasColumnName("check_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.InventoryChecks)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryCheck_Warehouse");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Employee");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Warehouse");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .HasColumnName("supplier_name");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phone_number");

                entity.Property(e => e.WarehouseName)
                    .HasMaxLength(50)
                    .HasColumnName("warehouse_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
