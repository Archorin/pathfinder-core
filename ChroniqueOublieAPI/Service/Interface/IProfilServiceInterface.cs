using ChroniqueOublieAPI.Models.Voie.Profil;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Interface
{
    public interface IProfilServiceInterface
    {
        ProfilDTO Create(ProfilDTO maitriseTypeDto);

        IEnumerable<ProfilDTO> ReadAll();

        ProfilDTO ReadByName(ProfilDTO maitriseTypeDto);

        ProfilDTO ReadById(ProfilDTO maitriseTypeDto);

        ProfilDTO Update(ProfilDTO maitriseTypeDto);

        ProfilDTO Delete(ProfilDTO maitriseTypeDto);
    }
}