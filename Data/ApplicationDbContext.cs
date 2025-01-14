using GestionTicketP6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionTicketP6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<ProductVersion> Versions { get; set; }
        public DbSet<SystemeExploitation> SystemesExploitation { get; set; }
        public DbSet<Compatibilite> Compatibilites { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Définir la clé composite pour Compatibilité
            //modelBuilder.Entity<Compatibilite>()
            //    .HasKey(c => new { c.IdVersion, c.IdOs });

            // Relation Produit -> ProductVersion (1-N)
            //modelBuilder.Entity<ProductVersion>()
            //    .HasOne(v => v.Produit)
            //    .WithMany(p => p.Versions)
            //    .HasForeignKey(v => v.Id);

            // Relation ProductVersion -> Compatibilité (1-N)
            //modelBuilder.Entity<Compatibilite>()
            //    .HasOne(c => c.Version)
            //    .WithMany(v => v.Compatibilites)
            //    .HasForeignKey(c => c.IdVersion);

            // Relation Système_Exploitation -> Compatibilité (1-N)
            //modelBuilder.Entity<Compatibilite>()
            //    .HasOne(c => c.SystemeExploitation)
            //    .WithMany(os => os.Compatibilites)
            //    .HasForeignKey(c => c.IdOs);

            // Relation ProductVersion -> Ticket (1-N)
            //modelBuilder.Entity<Ticket>()
            //    .HasOne(t => t.Version)
            //    .WithMany(v => v.Tickets)
            //    .HasForeignKey(t => t.IdVersion);

            // Relation Système_Exploitation -> Ticket (1-N)
            //modelBuilder.Entity<Ticket>()
            //    .HasOne(t => t.SystemeExploitation)
            //    .WithMany()
            //    .HasForeignKey(t => t.IdOs);
        }
    }
}
