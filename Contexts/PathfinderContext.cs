using PathfinderCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PathfinderCore.Contexts
{
    public class PathfinderContext : DbContext
    {
        public PathfinderContext(DbContextOptions<PathfinderContext> options)
            : base(options) { }
        public PathfinderContext() { }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Competence> Competence { get; set; }
        public DbSet<Don> Don { get; set; }
        public DbSet<Ouvrage> Ouvrage { get; set; }
        public DbSet<Statistique> Statistique { get; set; }
        public DbSet<Alignement> Alignement { get; set; }
        public DbSet<DV> DV { get; set; }
        public DbSet<Special> Special { get; set; }
        public DbSet<Courbe> Courbe { get; set; }
        public DbSet<Caracteristique> Caracteristique { get; set; }
        public DbSet<ClasseAlignement> ClasseAlignement { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Personnage> Personnage { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Jointure entre les classes et les alignements
            modelBuilder.Entity<ClasseAlignement>()
                .HasKey(t => new { t.ClasseId, t.AlignementId });

            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(ca => ca.Classe)
                .WithMany("ClasseAlignements");

            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(ca => ca.Alignement)
                .WithMany("ClasseAlignements");
            /*
            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(pt => pt.Classe)
                .WithMany(p => p.ClasseAlignements)
                .HasForeignKey(pt => pt.ClasseId);

            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(pt => pt.Alignement)
                .WithMany(t => t.ClasseAlignements)
                .HasForeignKey(pt => pt.AlignementId);*/
        }


    }
}