using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Voie.Type
{
    [Table("voie_type")]
    public class VoieTypeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("libelle", TypeName = "varchar(10)"), Required]
        public string Libelle { get; set; }
    }
}