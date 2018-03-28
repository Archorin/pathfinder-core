using ChroniqueOublieAPI.Models.Voie.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Voie
{
    [Table("voie")]
    public class VoieEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_type")]
        [Column("id_type")]
        public int TypeId { get; set; }

        public VoieTypeEntity Type { get; set; }

        //[Column("id_ouvrage")]
        //public VoieTypeEntity Type { get; set; }

        [Column("libelle", TypeName = "varchar(10)"), Required]
        public string Libelle { get; set; }
    }
}