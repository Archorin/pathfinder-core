using ChroniqueOublieAPI.Models.Voie.Profil;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Voie.VoieProfil
{
    [Table("voie_profil")]
    public class VoieProfilEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_voie")]
        [Column("id_voie")]
        public int VoieId { get; set; }

        public VoieEntity Voie { get; set; }

        [ForeignKey("id_profil")]
        [Column("id_profil")]
        public int ProfilId { get; set; }

        public ProfilEntity Profil { get; set; }
    }
}