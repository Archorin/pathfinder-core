using ChroniqueOublieAPI.Models.Interface;
using ChroniqueOublieAPI.Models.Voie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChroniqueOublieAPI.Service.Voie
{
    public class VoieService
    {
        private readonly IVoieDAOInterface voieDao;

        public VoieService(IVoieDAOInterface voieDao)
        {
            this.voieDao = voieDao;
        }

        public VoieDTO Create(VoieDTO maitriseTypeDto)
        {
            return this.voieDao.Create(maitriseTypeDto);
        }

        public VoieDTO ReadByName(VoieDTO maitriseTypeDto)
        {
            return this.voieDao.ReadByName(maitriseTypeDto);
        }

        public VoieDTO ReadById(VoieDTO maitriseTypeDto)
        {
            return this.voieDao.ReadById(maitriseTypeDto);
        }

        public VoieDTO Update(VoieDTO maitriseTypeDto)
        {
            return this.voieDao.Update(maitriseTypeDto);
        }

        public VoieDTO Delete(VoieDTO maitriseTypeDto)
        {
            return this.voieDao.Delete(maitriseTypeDto);
        }
    }
}