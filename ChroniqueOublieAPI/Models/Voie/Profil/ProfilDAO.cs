using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChroniqueOublieAPI.Models.Voie.Profil
{
    public class ProfilDAO : IProfilDAOInterface
    {
        private readonly ChroniqueOublieContext context;

        public ProfilDAO(ChroniqueOublieContext context)
        {
            this.context = context;
        }

        public ProfilDTO Create(ProfilDTO ProfilDto)
        {
            //Check si le type existe déjà en base
            ProfilDTO voieTypeExist = this.ReadByName(ProfilDto);
            if (null != voieTypeExist)
            {
                return null;
            }
            ProfilEntity profilEntity = Mapper.Map<ProfilEntity>(ProfilDto);
            this.context.ProfilTable.Add(profilEntity);
            this.context.SaveChanges();
            return Mapper.Map<ProfilDTO>(profilEntity);
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

        public IEnumerable<ProfilDTO> ReadAll()
        {
            IEnumerable<ProfilEntity> entities = this.context.ProfilTable;
            return Mapper.Map<IEnumerable<ProfilDTO>>(entities);
        }

        public ProfilDTO ReadByName(ProfilDTO voieTypeDto)
        {
            ProfilEntity profilEntity = this.context.ProfilTable.SingleOrDefault(m => m.Libelle == voieTypeDto.Libelle);
            return Mapper.Map<ProfilDTO>(profilEntity);
        }

        public ProfilDTO ReadById(ProfilDTO voieTypeDto)
        {
            ProfilEntity profilEntity = this.context.ProfilTable.SingleOrDefault(m => m.Id == voieTypeDto.Id);
            return Mapper.Map<ProfilDTO>(profilEntity);
        }

        public ProfilDTO Update(ProfilDTO voieTypeDto)
        {
            //Il faut que l'id type de voie existe en base
            ProfilDTO voieTypeExist = this.ReadById(voieTypeDto);
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
            ProfilEntity profilEntity = Mapper.Map<ProfilEntity>(voieTypeDto);
            this.context.Entry(profilEntity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.ReadById(Mapper.Map<ProfilDTO>(profilEntity));
        }

        public ProfilDTO Delete(ProfilDTO voieTypeDto)
        {
            //Il faut que l'id type de voie existe en base
            ProfilDTO voieTypeExist = this.ReadById(voieTypeDto);
            if (null == voieTypeExist)
            {
                return null;
            }
            ProfilEntity profilEntity = this.context.ProfilTable.SingleOrDefault(m => m.Id == voieTypeDto.Id);
            this.context.ProfilTable.Remove(profilEntity);
            this.context.SaveChanges();
            return Mapper.Map<ProfilDTO>(profilEntity);
        }
    }
}