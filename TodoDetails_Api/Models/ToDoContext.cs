using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoDetails_Api.Models;

public partial class ToDoContext : DbContext
{
    public ToDoContext()
    {
    }

    public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TitleDetail> TitleDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TodoDetails");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TitleDetail>(entity =>
        {
            entity.HasKey(e => e.Titleid);

            entity.Property(e => e.Titleid).HasColumnName("titleid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TitleDetails)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("titleDetails");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
