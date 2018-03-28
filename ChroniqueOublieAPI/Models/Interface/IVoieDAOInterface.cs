using ChroniqueOublieAPI.Models.Voie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChroniqueOublieAPI.Models.Interface
{
    public interface IVoieDAOInterface
    {
        VoieDTO Create(VoieDTO VoieDto);

        VoieDTO ReadByName(VoieDTO voieTypeDto);

        VoieDTO ReadById(VoieDTO voieTypeDto);

        VoieDTO Update(VoieDTO voieTypeDto);

        VoieDTO Delete(VoieDTO voieTypeDto);
    }
}