using ChroniqueOublieAPI.Models.Interface;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Service.Interface;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Voie
{
    public class VoieTypeService : IVoieTypeServiceInterface
    {
        private readonly IVoieTypeDAOInterface voieTypeDao;

        public VoieTypeService(IVoieTypeDAOInterface voieTypeDao)
        {
            this.voieTypeDao = voieTypeDao;
        }

        public VoieTypeDTO Create(VoieTypeDTO maitriseTypeDto)
        {
            return this.voieTypeDao.Create(maitriseTypeDto);
        }

        public IEnumerable<VoieTypeDTO> ReadAll()
        {
            return this.voieTypeDao.ReadAll();
        }

        public VoieTypeDTO ReadByName(VoieTypeDTO maitriseTypeDto)
        {
            return this.voieTypeDao.ReadByName(maitriseTypeDto);
        }

        public VoieTypeDTO ReadById(VoieTypeDTO maitriseTypeDto)
        {
            return this.voieTypeDao.ReadById(maitriseTypeDto);
        }

        public VoieTypeDTO Update(VoieTypeDTO maitriseTypeDto)
        {
            return this.voieTypeDao.Update(maitriseTypeDto);
        }

        public VoieTypeDTO Delete(VoieTypeDTO maitriseTypeDto)
        {
            return this.voieTypeDao.Delete(maitriseTypeDto);
        }
    }
}