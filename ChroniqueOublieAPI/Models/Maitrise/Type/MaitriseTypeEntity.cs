using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Maitrise.Type
{
    [Table("maitrise_type")]
    public class MaitriseTypeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("libelle", TypeName = "varchar(10)"), Required]
        public string Libelle { get; set; }
    }
}