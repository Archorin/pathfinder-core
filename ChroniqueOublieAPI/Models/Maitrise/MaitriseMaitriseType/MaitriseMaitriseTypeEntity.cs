using ChroniqueOublieAPI.Models.Maitrise.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Maitrise.MaitriseMaitriseType
{
    [Table("maitrise_maitrise_type")]
    public class MaitriseMaitriseTypeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_maitrise")]
        [Column("id_maitrise")]
        public int MaitriseId { get; set; }

        public MaitriseEntity Maitrise { get; set; }

        [ForeignKey("id_maitrise_type")]
        [Column("id_maitrise_type")]
        public int MaitriseTypeId { get; set; }

        public MaitriseTypeEntity MaitriseType { get; set; }
    }
}