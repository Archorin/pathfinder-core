using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChroniqueOublieAPI.Models.Voie.Type
{
    public class VoieTypeDAO : IVoieTypeDAOInterface
    {
        private readonly ChroniqueOublieContext context;

        public VoieTypeDAO(ChroniqueOublieContext context)
        {
            this.context = context;
        }

        public VoieTypeDTO Create(VoieTypeDTO voieTypeDto)
        {
            //Check si le type existe déjà en base
            VoieTypeDTO voieTypeExist = this.ReadByName(voieTypeDto);
            if (null != voieTypeExist)
            {
                return null;
            }
            VoieTypeEntity voieTypeEntity = Mapper.Map<VoieTypeEntity>(voieTypeDto);
            this.context.VoieTypeTable.Add(voieTypeEntity);
            this.context.SaveChanges();
            return Mapper.Map<VoieTypeDTO>(voieTypeEntity);
        }

        //@TODO
        /*public IEnumerable<VoieTypeDTO> FindAllByVoieId(MaitriseDTO maitriseDto)
        {
            IEnumerable<MaitriseTypeEntity> maitriseTypeEntites = from maitriseType in this.context.MaitriseTypeTable
                       join maitriseMaitriseType in this.context.MaitriseMaitriseTypeTable on maitriseType equals maitriseMaitriseType.maitriseType
                       join maitrise in this.context.MaitriseTable on maitriseMaitriseType.maitrise equals maitrise
                       where maitrise.Id == maitriseDto.Id select maitriseType;
            return Mapper.Map<IEnumerable<VoieTypeDTO>>(maitriseTypeEntites);
        }*/

        public IEnumerable<VoieTypeDTO> ReadAll()
        {
            IEnumerable<VoieTypeEntity> entities = this.context.VoieTypeTable;
            return Mapper.Map<IEnumerable<VoieTypeDTO>>(entities);
        }

        public VoieTypeDTO ReadByName(VoieTypeDTO voieTypeDto)
        {
            VoieTypeEntity voieTypeEntity = this.context.VoieTypeTable.SingleOrDefault(m => m.Libelle == voieTypeDto.Libelle);
            return Mapper.Map<VoieTypeDTO>(voieTypeEntity);
        }

        public VoieTypeDTO ReadById(VoieTypeDTO voieTypeDto)
        {
            VoieTypeEntity voieTypeEntity = this.context.VoieTypeTable.SingleOrDefault(m => m.Id == voieTypeDto.Id);
            return Mapper.Map<VoieTypeDTO>(voieTypeEntity);
        }

        public VoieTypeDTO Update(VoieTypeDTO voieTypeDto)
        {
            //Il faut que l'id type de voie existe en base
            VoieTypeDTO voieTypeExist = this.ReadById(voieTypeDto);
            if (null == voieTypeExist)
            {
                return null;
            }
            //Il faut que le nom du type de voie n'existe pas en base
            voieTypeExist = this.ReadByName(voieTypeDto);
            if (null != voieTypeExist)
            {
                return null;
            }
            VoieTypeEntity voieTypeEntity = Mapper.Map<VoieTypeEntity>(voieTypeDto);
            this.context.Entry(voieTypeEntity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.ReadById(Mapper.Map<VoieTypeDTO>(voieTypeEntity));
        }

        public VoieTypeDTO Delete(VoieTypeDTO voieTypeDto)
        {
            //Il faut que l'id type de voie existe en base
            VoieTypeDTO voieTypeExist = this.ReadById(voieTypeDto);
            if (null == voieTypeExist)
            {
                return null;
            }
            VoieTypeEntity voieTypeEntity = this.context.VoieTypeTable.SingleOrDefault(m => m.Id == voieTypeDto.Id);
            this.context.VoieTypeTable.Remove(voieTypeEntity);
            this.context.SaveChanges();
            return Mapper.Map<VoieTypeDTO>(voieTypeEntity);
        }
    }
}