﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Upmeet_Event_System.Models;

public partial class EventDbContext : DbContext
{
    public EventDbContext()
    {
    }

    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=EventDb; User ID=SA; Password=EnterPasswordHere123; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3213E83F6EC44847");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
