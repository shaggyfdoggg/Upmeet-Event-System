using System;
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

    public virtual DbSet<Favorite> Favorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        //Forrest
       // => optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=EventDb; User ID=SA; Password=EnterPasswordHere123; TrustServerCertificate=true;");

        //Tim
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=EventDb; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

        //Zach
        //=> optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=EventDb; User ID=sa; Password=someThingComplicated1234; TrustServerCertificate=true;");
    



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

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3213E83FDB89EEF4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Event).WithMany(p => p.Favorites)//
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Favorites__event__44FF419A");//
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
