using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Maitrise.Type
{
    [Table("maitrise_type")]
    public class MaitriseTypeDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
    }
}