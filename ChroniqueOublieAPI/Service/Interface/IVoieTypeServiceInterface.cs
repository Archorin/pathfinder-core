using ChroniqueOublieAPI.Models.Voie.Type;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Interface
{
    public interface IVoieTypeServiceInterface
    {
        VoieTypeDTO Create(VoieTypeDTO maitriseTypeDto);

        IEnumerable<VoieTypeDTO> ReadAll();

        VoieTypeDTO ReadByName(VoieTypeDTO maitriseTypeDto);

        VoieTypeDTO ReadById(VoieTypeDTO maitriseTypeDto);

        VoieTypeDTO Update(VoieTypeDTO maitriseTypeDto);

        VoieTypeDTO Delete(VoieTypeDTO maitriseTypeDto);
    }
}