using Microsoft.EntityFrameworkCore;
using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Data
{
    public class K9UnitManagementDbContext : DbContext
    {
        public K9UnitManagementDbContext(DbContextOptions<K9UnitManagementDbContext> Options) : base(Options)
        {

        }

        public DbSet<Dog> Dogs { get; set; } = null!;
        public DbSet<Handler> Handlers { get; set; } = null!;
        public DbSet<TrainingSession> TrainingSessions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dog>()
                .HasOne(d => d.handler)
                .WithOne(d => d.dog)
                .HasForeignKey<Dog>(d => d.HandlerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<TrainingSession>()
                .HasOne(t => t.dog)
                .WithMany(t => t.trainingSessions)
                .HasForeignKey(t => t.DogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Handler>()
                .HasIndex(i => i.PersonalNumber);
        }
    }
}
