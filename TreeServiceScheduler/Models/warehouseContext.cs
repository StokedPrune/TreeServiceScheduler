using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TreeServiceScheduler.Models
{
    public partial class warehouseContext : DbContext
    {
        public virtual DbSet<TreeSchedule> TreeSchedule { get; set; }

        public warehouseContext(DbContextOptions<warehouseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeSchedule>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.AgeClass).HasMaxLength(50);

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.Crmid)
                    .HasColumnName("CRMid")
                    .HasMaxLength(30);

                entity.Property(e => e.DataSource).HasMaxLength(50);

                entity.Property(e => e.DrawingNo).HasMaxLength(255);

                entity.Property(e => e.Genus).HasMaxLength(255);

                entity.Property(e => e.Locality).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(250);

                entity.Property(e => e.PlantingDate).HasColumnType("date");

                entity.Property(e => e.ProjectNo).HasMaxLength(255);

                entity.Property(e => e.RecordDate).HasColumnType("date");

                entity.Property(e => e.Service1By).HasMaxLength(50);

                entity.Property(e => e.Service1DateComplete).HasColumnType("date");

                entity.Property(e => e.Service1DateDue).HasColumnType("date");

                entity.Property(e => e.Service2By).HasMaxLength(50);

                entity.Property(e => e.Service2DateComplete).HasColumnType("date");

                entity.Property(e => e.Service2DateDue).HasColumnType("date");

                entity.Property(e => e.Service3By).HasMaxLength(50);

                entity.Property(e => e.Service3DateComplete).HasColumnType("date");

                entity.Property(e => e.Service3DateDue).HasColumnType("date");

                entity.Property(e => e.Service4By).HasMaxLength(50);

                entity.Property(e => e.Service4DateComplete).HasColumnType("date");

                entity.Property(e => e.Service4DateDue).HasColumnType("date");

                entity.Property(e => e.Species).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });
        }
    }
}
