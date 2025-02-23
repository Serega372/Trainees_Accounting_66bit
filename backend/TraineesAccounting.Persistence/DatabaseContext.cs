using Microsoft.EntityFrameworkCore;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence
{
    public class DatabaseContext(
        DbContextOptions<DatabaseContext> options
        ) : DbContext(options)
    {
        public DbSet<TraineeEntity> Trainees { get; set; }
        public DbSet<InternshipDirectionEntity> InternshipDirections { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraineeEntity>()
                .HasOne(t => t.InternshipDirection)
                .WithMany(i => i.Trainees)
                .HasForeignKey(t => t.InternshipDirectionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TraineeEntity>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Trainees)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
