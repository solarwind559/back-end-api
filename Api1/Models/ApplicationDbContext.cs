using Microsoft.EntityFrameworkCore;

namespace Api1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Maja> Majas { get; set; }
        public DbSet<Dzivoklis> Dzivokli { get; set; }
        public DbSet<Iedzivotajs> Iedzivotaji { get; set; }
        public DbSet<Iedzivotaja_Dzivoklis> Iedzivotaju_Dzivokli { get; set; }
        public DbSet<Majas_Dzivoklis> Majas_Dzivokli { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationships
            modelBuilder.Entity<Iedzivotaja_Dzivoklis>()
                .HasKey(id => new { id.Iedzivotajs_Id, id.Dzivoklis_Id });

            modelBuilder.Entity<Iedzivotaja_Dzivoklis>()
                .HasOne(id => id.Iedzivotajs)
                .WithMany(i => i.Iedzivotaja_Dzivokli)
                .HasForeignKey(id => id.Iedzivotajs_Id);

            modelBuilder.Entity<Iedzivotaja_Dzivoklis>()
                .HasOne(id => id.Dzivoklis)
                .WithMany(d => d.Iedzivotaja_Dzivokli)
                .HasForeignKey(id => id.Dzivoklis_Id);

            modelBuilder.Entity<Majas_Dzivoklis>()
                .HasKey(md => new { md.Maja_Id, md.Dzivoklis_Id });

            modelBuilder.Entity<Majas_Dzivoklis>()
                .HasOne(md => md.Maja)
                .WithMany(m => m.Majas_Dzivokli)
                .HasForeignKey(md => md.Maja_Id);

            modelBuilder.Entity<Majas_Dzivoklis>()
                .HasOne(md => md.Dzivoklis)
                .WithMany(d => d.Majas_Dzivokli)
                .HasForeignKey(md => md.Dzivoklis_Id);
        }
    }
}
