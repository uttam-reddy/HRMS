using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public partial class HRMSDbContext : DbContext
    {
       
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
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Department)
                .WithMany(d => d.Employees).HasForeignKey(d => d.DeptId);

            }
            );

            modelBuilder.Entity<Activities>(entity =>
            {
                entity.ToTable("Activities");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();

                entity.Property(c => c.ActivityName).HasColumnName("ActivityName").HasMaxLength(255).IsRequired();
               

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                

            }
            );

            modelBuilder.Entity<EmployeeActivites>(entity =>
            {
                entity.ToTable("EmployeeActivites");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();


                entity.HasKey(bc => new { bc.EmployeeId, bc.ActivityId });

                entity.HasOne(bc => bc.Employee)
                    .WithMany(b => b.employeeActivites)
                    .HasForeignKey(bc => bc.EmployeeId);

                entity.HasOne(bc => bc.Activity)
                    .WithMany(c => c.employeeActivites)
                    .HasForeignKey(bc => bc.ActivityId);

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");



            }
            );

            modelBuilder.Entity<Department>(entity =>
            {


                entity.ToTable("Department");

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedNever();

                entity.Property(c => c.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");


            }
            );


            modelBuilder.Entity<Role>(entity =>
            {


                entity.ToTable("Role");

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedNever();

                entity.Property(c => c.RoleName).HasColumnName("RoleName").HasMaxLength(255).IsRequired();

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");


            }
           );


            modelBuilder.Entity<Users>(entity =>
            {


                entity.ToTable("Users");

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedNever();

                entity.Property(c => c.UserName).HasColumnName("UserName").HasMaxLength(255).IsRequired();
                entity.Property(c => c.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
                entity.Property(c => c.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");
                entity.Property(e => e.DateUpdated).HasColumnType("datetime");
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.HasOne(d => d.roles)
                .WithMany(d => d.Users).HasForeignKey(d => d.RoleId);


            }
          );


        }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Activities> Activities { get; set; }

        public virtual DbSet<EmployeeActivites> EmployeeActivites { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Users> Users { get; set; }


    }
}
