using ChroniqueOublieAPI.Models.Interface;
using ChroniqueOublieAPI.Models.Maitrise;
using ChroniqueOublieAPI.Service.Interface;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Maitrise.Interface
{
    public class MaitriseService : IMaitriseServiceInterface
    {
        private readonly IMaitriseDAOInterface maitriseDao;
        private readonly IMaitriseTypeServiceInterface maitriseTypeService;

        public MaitriseService(IMaitriseDAOInterface maitriseDao, IMaitriseTypeServiceInterface maitriseTypeService)
        {
            this.maitriseDao = maitriseDao;
            this.maitriseTypeService = maitriseTypeService;
        }

        public MaitriseDTO Create(MaitriseDTO maitriseDto)
        {
            return this.maitriseDao.Create(maitriseDto);
        }

        public IEnumerable<MaitriseDTO> ReadAll()
        {
            return this.maitriseDao.ReadAll();
        }

        public MaitriseDTO ReadByName(MaitriseDTO maitriseDto)
        {
            return this.maitriseDao.ReadByName(maitriseDto);
        }

        public MaitriseDTO ReadById(MaitriseDTO maitriseDto)
        {
            return this.maitriseDao.ReadById(maitriseDto);
        }

        public MaitriseDTO Update(MaitriseDTO maitriseTypeDto)
        {
            return this.maitriseDao.Update(maitriseTypeDto);
        }

        public MaitriseDTO Delete(MaitriseDTO maitriseDto)
        {
            return this.maitriseDao.Delete(maitriseDto);
        }
    }
}