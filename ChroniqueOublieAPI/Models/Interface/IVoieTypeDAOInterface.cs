using ChroniqueOublieAPI.Models.Voie.Type;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Interface
{
    public interface IVoieTypeDAOInterface
    {
        VoieTypeDTO Create(VoieTypeDTO maitriseTypeDto);

        //@TODO
        //IEnumerable<VoieTypeDTO> FindAllByVoieId(MaitriseDTO maitriseDto);

        IEnumerable<VoieTypeDTO> ReadAll();

        VoieTypeDTO ReadByName(VoieTypeDTO voieTypeDto);

        VoieTypeDTO ReadById(VoieTypeDTO voieTypeDto);

        VoieTypeDTO Update(VoieTypeDTO voieTypeDto);

        VoieTypeDTO Delete(VoieTypeDTO voieTypeDto);
    }
}