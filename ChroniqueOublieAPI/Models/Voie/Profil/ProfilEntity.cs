using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Voie.Profil
{
    [Table("profil")]
    public class ProfilEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("libelle", TypeName = "varchar(10)"), Required]
        public string Libelle { get; set; }

        [Column("description_courte", TypeName = "varchar(10)"), Required]
        public string DescriptionCourte { get; set; }

        [Column("description", TypeName = "varchar(10)"), Required]
        public string Description { get; set; }
    }
}