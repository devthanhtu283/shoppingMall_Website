using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ABCDMall_API.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Newsgallery> Newsgalleries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatStatus> SeatStatuses { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TimeSlot> TimeSlots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9KFA5D6\\SQLEXPRESS;Database=ABCDMall;user id=sa;password=123456;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACCOUNT__3213E83FB663E5BB");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("date")
                .HasColumnName("created");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORY__3213E83F7EF68A7B");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FEEDBACK__3213E83F74EDD143");

            entity.ToTable("FEEDBACK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("date")
                .HasColumnName("created");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(e => e.DateExpect).HasColumnType("date");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Genre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Newsgallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NEWSGALL__3213E83F218D430E");

            entity.ToTable("NEWSGALLERY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cover_img");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3213E83F913BB497");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Idcategory).HasColumnName("idcategory");
            entity.Property(e => e.Idsale).HasColumnName("idsale");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idcategory)
                .HasConstraintName("FK__PRODUCT__idcateg__2E1BDC42");

            entity.HasOne(d => d.IdsaleNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idsale)
                .HasConstraintName("FK__PRODUCT__idcateg__2D27B809");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SALE__3213E83F655177AC");

            entity.ToTable("SALE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.SaleNumber).HasColumnName("saleNumber");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("startDate");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.ToTable("Seat");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Room).WithMany(p => p.Seats)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seat_Room");
        });

        modelBuilder.Entity<SeatStatus>(entity =>
        {
            entity.ToTable("SeatStatus");

            entity.HasOne(d => d.Seat).WithMany(p => p.SeatStatuses)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeatStatus_Seat");

            entity.HasOne(d => d.Show).WithMany(p => p.SeatStatuses)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeatStatus_Show");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SHOP__3213E83FB9DADFEB");

            entity.ToTable("SHOP");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CoverImg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cover_img");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Shops)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__SHOP__categoryId__286302EC");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.ToTable("Show");

            entity.Property(e => e.DateRelease).HasColumnType("date");

            entity.HasOne(d => d.Movie).WithMany(p => p.Shows)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Movie");

            entity.HasOne(d => d.Room).WithMany(p => p.Shows)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Room");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.Shows)
                .HasForeignKey(d => d.TimeSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_TimeSlot");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("Ticket");

            entity.Property(e => e.NameCustomer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PhoneCustomer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TimeBooked).HasColumnType("datetime");

            entity.HasOne(d => d.SeatStatus).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_SeatStatus");
        });

        modelBuilder.Entity<TimeSlot>(entity =>
        {
            entity.ToTable("TimeSlot");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
