using ChroniqueOublieAPI.Models.Interface;
using ChroniqueOublieAPI.Models.Voie.Profil;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Service.Interface;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Voie
{
    public class ProfilService : IProfilServiceInterface
    {
        private readonly IProfilDAOInterface profilDao;

        public ProfilService(IProfilDAOInterface profilDao)
        {
            this.profilDao = profilDao;
        }

        public ProfilDTO Create(ProfilDTO maitriseTypeDto)
        {
            return this.profilDao.Create(maitriseTypeDto);
        }

        public IEnumerable<ProfilDTO> ReadAll()
        {
            return this.profilDao.ReadAll();
        }

        public ProfilDTO ReadByName(ProfilDTO maitriseTypeDto)
        {
            return this.profilDao.ReadByName(maitriseTypeDto);
        }

        public ProfilDTO ReadById(ProfilDTO maitriseTypeDto)
        {
            return this.profilDao.ReadById(maitriseTypeDto);
        }

        public ProfilDTO Update(ProfilDTO maitriseTypeDto)
        {
            return this.profilDao.Update(maitriseTypeDto);
        }

        public ProfilDTO Delete(ProfilDTO maitriseTypeDto)
        {
            return this.profilDao.Delete(maitriseTypeDto);
        }
    }
}