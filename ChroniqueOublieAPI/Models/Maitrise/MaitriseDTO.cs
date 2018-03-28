using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Models.Voie;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Maitrise
{
    public class MaitriseDTO
    {
        public int Id { get; set; }
        public VoieDTO Voie { get; set; }
        public string Libelle { get; set; }
        public string Niveau { get; set; }
        public string Description { get; set; }
        public IEnumerable<MaitriseTypeDTO> Types { get; set; }
    }
}