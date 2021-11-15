using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class MovieRatesDBContext : DbContext
    {
        public MovieRatesDBContext()
        {
        }

        public MovieRatesDBContext(DbContextOptions<MovieRatesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<FollowingUser> FollowingUsers { get; set; }
        public virtual DbSet<LikedMovie> LikedMovies { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewComment> ReviewComments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersReview> UsersReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=MovieRatesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.EntryTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entries_Users");
            });

            modelBuilder.Entity<FollowingUser>(entity =>
            {
                entity.HasKey(e => new { e.FollowerUserId, e.FollowingUserId });

                entity.HasOne(d => d.FollowerUser)
                    .WithMany(p => p.FollowingUserFollowerUsers)
                    .HasForeignKey(d => d.FollowerUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FollowingUsers_Users_Follower");

                entity.HasOne(d => d.FollowingUserNavigation)
                    .WithMany(p => p.FollowingUserFollowingUserNavigations)
                    .HasForeignKey(d => d.FollowingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FollowingUsers_Users_Following");
            });

            modelBuilder.Entity<LikedMovie>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikedMovies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikedMovies_Users");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MovieId });

                entity.Property(e => e.Rating1).HasColumnName("Rating");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_Users");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewContent)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ReviewTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<ReviewComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CommentTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewComments)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewComments_Reviews");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewComments_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "Uniqe_Users_Email")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SignUpDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UsersReview>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ReviewId });

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.UsersReviews)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersReviews_Reviews");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersReviews_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
