using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChroniqueOublieAPI.Models.Voie
{
    public class VoieDAO : IVoieDAOInterface
    {
        private readonly ChroniqueOublieContext context;

        public VoieDAO(ChroniqueOublieContext context)
        {
            this.context = context;
        }

        public VoieDTO Create(VoieDTO VoieDto)
        {
            VoieEntity voieEntity = Mapper.Map<VoieEntity>(VoieDto);
            this.context.VoieTable.Add(voieEntity);
            this.context.SaveChanges();
            return Mapper.Map<VoieDTO>(voieEntity);
        }

        public VoieDTO ReadByName(VoieDTO voieTypeDto)
        {
            VoieEntity voieEntity = this.context.VoieTable.SingleOrDefault(m => m.Libelle == voieTypeDto.Libelle);
            return Mapper.Map<VoieDTO>(voieEntity);
        }

        public VoieDTO ReadById(VoieDTO voieTypeDto)
        {
            VoieEntity voieEntity = this.context.VoieTable.SingleOrDefault(m => m.Id == voieTypeDto.Id);
            return Mapper.Map<VoieDTO>(voieEntity);
        }

        public VoieDTO Update(VoieDTO voieDto)
        {
            VoieDTO voieExist = this.ReadById(voieDto);
            if (null == voieExist) //Si la voie n'existe pas, on retourne une valeur null
            {
                return null;
            }
            VoieEntity voieEntity = Mapper.Map<VoieEntity>(voieDto);
            this.context.Entry(voieEntity).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.ReadById(Mapper.Map<VoieDTO>(voieEntity));
        }

        public VoieDTO Delete(VoieDTO voieDto)
        {
            VoieDTO voieExist = this.ReadById(voieDto);
            if (null == voieExist) //Si la voie n'existe pas, on retourne une valeur null
            {
                return null;
            }
            VoieEntity voieEntity = this.context.VoieTable.SingleOrDefault(m => m.Id == voieDto.Id);
            this.context.VoieTable.Remove(voieEntity);
            this.context.SaveChanges();
            return Mapper.Map<VoieDTO>(voieEntity);
        }
    }
}