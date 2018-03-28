using ChroniqueOublieAPI.Models.Voie.Profil;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Interface
{
    public interface IProfilDAOInterface
    {
        ProfilDTO Create(ProfilDTO ProfilDto);

        //@TODO
        // IEnumerable<VoieTypeDTO> FindAllByVoieId(MaitriseDTO maitriseDto);

        IEnumerable<ProfilDTO> ReadAll();

        ProfilDTO ReadByName(ProfilDTO voieTypeDto);

        ProfilDTO ReadById(ProfilDTO voieTypeDto);

        ProfilDTO Update(ProfilDTO voieTypeDto);

        ProfilDTO Delete(ProfilDTO voieTypeDto);
    }
}