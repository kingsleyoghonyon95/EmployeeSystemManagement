using EmployeeSystemManagement2.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystemManagement2.Data.Context
{
    public class EmployeeDBContext : DbContext
    {
        protected EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<EmployeeTableModel> EmployeeTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTableModel>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName).HasColumnName("EmployeeFirstName");

                entity.Property(e => e.LastName).HasColumnName("EmployeeLastName");
                entity.Property(e => e.HireDate);
                entity.Property(e => e.Salary);
                entity.Property(e => e.Bonus);
                entity.Property(e => e.Position);
                entity.Property(e => e.CheckInTime).HasColumnName("CheckInTime");
                entity.Property(e => e.CheckOutTime).HasColumnName("CheckOutTime"); 
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50);
            });
        }
    }
}
