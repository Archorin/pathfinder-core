using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChroniqueOublieAPI.Models.Maitrise.Type
{
    public class MaitriseTypeDAO : IMaitriseTypeDAOInterface
    {
        private readonly ChroniqueOublieContext context;

        public MaitriseTypeDAO(ChroniqueOublieContext context)
        {
            this.context = context;
        }

        public MaitriseTypeDTO Create(MaitriseTypeDTO maitriseTypeDto)
        {
            MaitriseTypeEntity maitriseTypeEntity = Mapper.Map<MaitriseTypeEntity>(maitriseTypeDto);
            //Gere l'unicité des types
            MaitriseTypeDTO maitriseTypeExiste = this.ReadByName(maitriseTypeDto);
            if (null != maitriseTypeExiste)
            {
                return null;
            }
            this.context.MaitriseTypeTable.Add(maitriseTypeEntity);
            this.context.SaveChanges();
            return Mapper.Map<MaitriseTypeDTO>(maitriseTypeEntity);
        }

        public IEnumerable<MaitriseTypeDTO> FindAllByMaitriseId(MaitriseDTO maitriseDto)
        {
            IEnumerable<MaitriseTypeEntity> maitriseTypeEntites = from maitriseType in this.context.MaitriseTypeTable
                                                                  join maitriseMaitriseType in this.context.MaitriseMaitriseTypeTable on maitriseType equals maitriseMaitriseType.MaitriseType
                                                                  join maitrise in this.context.MaitriseTable on maitriseMaitriseType.Maitrise equals maitrise
                                                                  where maitrise.Id == maitriseDto.Id
                                                                  select maitriseType;
            return Mapper.Map<IEnumerable<MaitriseTypeDTO>>(maitriseTypeEntites);
        }

        public IEnumerable<MaitriseTypeDTO> ReadAll()
        {
            IEnumerable<MaitriseTypeEntity> entities = this.context.MaitriseTypeTable;
            return Mapper.Map<IEnumerable<MaitriseTypeDTO>>(entities);
        }

        public MaitriseTypeDTO ReadByName(MaitriseTypeDTO maitriseTypeDto)
        {
            if (null == maitriseTypeDto.Libelle)
            {
                return null;
            }
            MaitriseTypeEntity maitriseTypeEntity = this.context.MaitriseTypeTable.SingleOrDefault(m => m.Libelle == maitriseTypeDto.Libelle);
            return Mapper.Map<MaitriseTypeDTO>(maitriseTypeEntity);
        }

        public MaitriseTypeDTO ReadById(MaitriseTypeDTO maitriseTypeDto)
        {
            MaitriseTypeEntity maitriseTypeEntity = this.context.MaitriseTypeTable.SingleOrDefault(m => m.Id == maitriseTypeDto.Id);
            return Mapper.Map<MaitriseTypeDTO>(maitriseTypeEntity);
        }

        public MaitriseTypeDTO Update(MaitriseTypeDTO maitriseTypeDto)
        {
            //Si l'id du type que l'on souhaite modifier n'existe pas, on return
            MaitriseTypeDTO maitriseTypeExist = this.ReadById(maitriseTypeDto);
            if (null == maitriseTypeExist)
            {
                return null;
            }
            //Si le nom du type existe déjà, on return
            maitriseTypeExist = this.ReadByName(maitriseTypeDto);
            if (null != maitriseTypeExist)
            {
                return null;
            }
            MaitriseTypeEntity maitriseTypeEntity = Mapper.Map<MaitriseTypeEntity>(maitriseTypeDto);
            this.context.Entry(maitriseTypeEntity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.ReadById(Mapper.Map<MaitriseTypeDTO>(maitriseTypeEntity));
        }

        public MaitriseTypeDTO Delete(MaitriseTypeDTO maitriseTypeDto)
        {
            //Si l'id du type que l'on souhaite supprimer n'existe pas, on return
            MaitriseTypeDTO maitriseTypeExist = this.ReadById(maitriseTypeDto);
            if (null == maitriseTypeExist)
            {
                return null;
            }
            MaitriseTypeEntity maitriseTypeEntity = this.context.MaitriseTypeTable.SingleOrDefault(m => m.Id == maitriseTypeDto.Id);
            this.context.MaitriseTypeTable.Remove(maitriseTypeEntity);
            this.context.SaveChanges();
            return Mapper.Map<MaitriseTypeDTO>(maitriseTypeEntity);
        }
    }
}