using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Service.Interface;
using ChroniqueOublieAPI.Models.Interface;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Maitrise
{
    public class MaitriseTypeService : IMaitriseTypeServiceInterface
    {
        private readonly IMaitriseTypeDAOInterface maitriseTypeDao;

        public MaitriseTypeService(IMaitriseTypeDAOInterface maitriseTypeDao)
        {
            this.maitriseTypeDao = maitriseTypeDao;
        }

        public MaitriseTypeDTO Create(MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeDao.Create(maitriseTypeDto);
        }

        public IEnumerable<MaitriseTypeDTO> ReadAll()
        {
            return this.maitriseTypeDao.ReadAll();
        }

        public MaitriseTypeDTO ReadByName(MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeDao.ReadByName(maitriseTypeDto);
        }

        public MaitriseTypeDTO ReadById(MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeDao.ReadById(maitriseTypeDto);
        }

        public MaitriseTypeDTO Update(MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeDao.Update(maitriseTypeDto);
        }

        public MaitriseTypeDTO Delete(MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeDao.Delete(maitriseTypeDto);
        }
    }
}