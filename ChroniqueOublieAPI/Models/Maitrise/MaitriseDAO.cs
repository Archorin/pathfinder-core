using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChroniqueOublieAPI.Models.Maitrise
{
    public class MaitriseDAO : IMaitriseDAOInterface
    {
        private readonly ChroniqueOublieContext context;

        public MaitriseDAO(ChroniqueOublieContext context)
        {
            this.context = context;
        }

        public MaitriseDTO Create(MaitriseDTO maitriseDto)
        {
            MaitriseEntity maitriseEntity = Mapper.Map<MaitriseEntity>(maitriseDto);
            this.context.MaitriseTable.Add(maitriseEntity);
            this.context.SaveChanges();
            return Mapper.Map<MaitriseDTO>(maitriseEntity);
        }

        public IEnumerable<MaitriseDTO> ReadAll()
        {
            IEnumerable<MaitriseEntity> entities = this.context.MaitriseTable;
            return Mapper.Map<IEnumerable<MaitriseDTO>>(entities);
        }

        public MaitriseDTO ReadByName(MaitriseDTO maitriseDto)
        {
            MaitriseEntity maitriseEntity = this.context.MaitriseTable.SingleOrDefault(m => m.Libelle == maitriseDto.Libelle);
            return Mapper.Map<MaitriseDTO>(maitriseEntity);
        }

        public MaitriseDTO ReadById(MaitriseDTO maitriseDto)
        {
            MaitriseEntity maitriseEntity = this.context.MaitriseTable.SingleOrDefault(m => m.Id == maitriseDto.Id);
            return Mapper.Map<MaitriseDTO>(maitriseEntity);
        }

        public MaitriseDTO Update(MaitriseDTO maitriseDto)
        {
            MaitriseDTO maitriseExist = this.ReadById(maitriseDto);
            if (null == maitriseExist) //Si la maitrise n'existe pas, on retourne une valeur null
            {
                return null;
            }
            MaitriseEntity maitriseEntity = Mapper.Map<MaitriseEntity>(maitriseDto);
            this.context.Entry(maitriseEntity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.ReadById(Mapper.Map<MaitriseDTO>(maitriseEntity));
        }

        public MaitriseDTO Delete(MaitriseDTO maitriseDto)
        {
            MaitriseDTO maitriseExist = this.ReadById(maitriseDto);
            if (null == maitriseExist) //Si la maitrise n'existe pas, on retourne une valeur null
            {
                return null;
            }
            MaitriseEntity maitriseEntity = this.context.MaitriseTable.SingleOrDefault(m => m.Id == maitriseDto.Id);
            this.context.MaitriseTable.Remove(maitriseEntity);
            this.context.SaveChanges();
            return Mapper.Map<MaitriseDTO>(maitriseEntity);
        }
    }
}