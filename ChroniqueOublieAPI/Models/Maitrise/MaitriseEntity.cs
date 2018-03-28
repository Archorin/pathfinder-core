using ChroniqueOublieAPI.Models.Voie;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Maitrise
{
    [Table("maitrise")]
    public class MaitriseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_voie")]
        [Column("id_voie")]
        public int VoieId { get; set; }

        public VoieEntity Voie { get; set; }

        [Column("libelle", TypeName = "varchar(10)"), Required]
        public string Libelle { get; set; }

        [Column("niveau", TypeName = "varchar(10)"), Required]
        public string Niveau { get; set; }

        [Column("description", TypeName = "varchar(10)"), Required]
        public string Description { get; set; }
    }
}