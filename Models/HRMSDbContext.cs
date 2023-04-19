using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext()
        {

        }
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();

                entity.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
                entity.Property(c => c.Address).HasColumnName("Address").HasMaxLength(255).IsRequired();

                

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                //entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Department)
                .WithMany(d => d.Employees).HasForeignKey(d => d.DeptId);

            }
            );
            

        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
