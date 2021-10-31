using Chess.Shared.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Chess.Server.Models
{
    public partial class ChessDbContext : DbContext
    {
        public ChessDbContext()
        {
        }

        public ChessDbContext(DbContextOptions<ChessDbContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Name=BlazingChat");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AboutMe).HasColumnName("about_me");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("created_date");

                entity.Property(e => e.DarkTheme)
                    .HasColumnType("BIT")
                    .HasColumnName("dark_theme");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATETIME")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Notifications)
                    .HasColumnType("BIT")
                    .HasColumnName("notifications");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePictureUrl).HasColumnName("profile_picture_url");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}