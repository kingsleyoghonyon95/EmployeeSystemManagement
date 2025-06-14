using EmployeeSystemManagement2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSystemManagement2.Data.Context
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options) { }

        public virtual DbSet<EmployeeTableModel> EmployeeTable { get; set; }
        public virtual DbSet<EmployeeAttendanceModel> EmployeeAttendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee Table config
            modelBuilder.Entity<EmployeeTableModel>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.FirstName).HasColumnName("EmployeeFirstName").IsRequired();
                entity.Property(e => e.LastName).HasColumnName("EmployeeLastName").IsRequired();
                entity.Property(e => e.HireDate).IsRequired();
                entity.Property(e => e.Salary);
                entity.Property(e => e.Bonus);
                entity.Property(e => e.Position);
            });

            // Attendance Table config
            modelBuilder.Entity<EmployeeAttendanceModel>(entity =>
            {
                entity.ToTable("EmployeeAttendanceTable"); 

                entity.HasKey(e => e.Id);

                entity.Property(e => e.ClockIn).IsRequired();
                entity.Property(e => e.ClockOut);

                entity.HasOne(e => e.Employee)
                      .WithMany(emp => emp.AttendanceRecords)
                      .HasForeignKey(e => e.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
