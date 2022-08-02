using Microsoft.EntityFrameworkCore;

namespace KVPFlights.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<UserInfo>? UserInfos { get; set; }
        public virtual DbSet<AirlineInfo>? AirlineInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            modelBuilder.Entity<AirlineInfo>(entity =>
            {
                entity.ToTable("AirlineInfo");
                entity.Property(e => e.AirlineID).HasColumnName("AirlineID");
                entity.Property(e => e.AirlineName).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.ContactNumber).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.ContactAddress).HasMaxLength(1000).IsUnicode(false);
                entity.Property(e => e.IsActive).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
