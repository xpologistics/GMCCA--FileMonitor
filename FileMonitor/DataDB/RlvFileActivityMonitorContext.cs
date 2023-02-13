using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileMonitor.DataDB;

public partial class RlvFileActivityMonitorContext : DbContext
{
    public RlvFileActivityMonitorContext()
    {
    }

    public RlvFileActivityMonitorContext(DbContextOptions<RlvFileActivityMonitorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmailDistributionList> EmailDistributionLists { get; set; }

    public virtual DbSet<model2> Services { get; set; }

    public virtual DbSet<model1> ServicePathToMonitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.30.0.20;Database=RLV_File_Activity_Monitor;User Id=RLV_Interfaces;Password=RLV@Interface;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailDistributionList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmailDistributionList");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<model2>(entity =>
        {
            entity.HasKey(e => e.ServiceSysId);

            entity.ToTable("Services");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<model1>(entity =>
        {
            entity.HasKey(e => e.ServicePathSysId);

            entity.ToTable("ServicePathToMonitor");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FileNamePattern)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.LastFileReceived)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PathToMonitor).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
