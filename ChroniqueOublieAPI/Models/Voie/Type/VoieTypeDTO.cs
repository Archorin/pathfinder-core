using System.ComponentModel.DataAnnotations.Schema;

namespace ChroniqueOublieAPI.Models.Voie.Type
{
    [Table("voie_type")]
    public class VoieTypeDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
    }
}