using ChroniqueOublieAPI.Models.Maitrise;
using ChroniqueOublieAPI.Models.Maitrise.MaitriseMaitriseType;
using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Models.Voie;
using ChroniqueOublieAPI.Models.Voie.Profil;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Models.Voie.VoieProfil;
using Microsoft.EntityFrameworkCore;

namespace ChroniqueOublieAPI.Contexts
{
    public class ChroniqueOublieContext : DbContext
    {
        public ChroniqueOublieContext(DbContextOptions<ChroniqueOublieContext> options)
            : base(options) { }

        public ChroniqueOublieContext()
        {
        }

        public DbSet<VoieProfilEntity> VoieProfilTable { get; set; }
        public DbSet<ProfilEntity> ProfilTable { get; set; }
        public DbSet<VoieTypeEntity> VoieTypeTable { get; set; }
        public DbSet<VoieEntity> VoieTable { get; set; }
        public DbSet<MaitriseTypeEntity> MaitriseTypeTable { get; set; }
        public DbSet<MaitriseEntity> MaitriseTable { get; set; }
        public DbSet<MaitriseMaitriseTypeEntity> MaitriseMaitriseTypeTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Jointure entre les classes et les alignements
            /*modelBuilder.Entity<VoieTypeEntity>()
                .HasKey(t => new { t.Id, t. });

            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(ca => ca.Classe)
                .WithMany("ClasseAlignements");

            modelBuilder.Entity<ClasseAlignement>()
                .HasOne(ca => ca.Alignement)
                .WithMany("ClasseAlignements");

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