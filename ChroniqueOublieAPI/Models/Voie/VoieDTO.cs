using ChroniqueOublieAPI.Models.Voie.Profil;
using ChroniqueOublieAPI.Models.Voie.Type;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Voie
{
    public class VoieDTO
    {
        public int Id { get; set; }
        public VoieTypeDTO Type { get; set; }
        public IEnumerable<ProfilDTO> Profils { get; set; }

        //public OuvrageDTO Ouvrage { get; set; }
        public string Libelle { get; set; }
    }
}