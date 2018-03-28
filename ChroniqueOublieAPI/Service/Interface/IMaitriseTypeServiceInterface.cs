using ChroniqueOublieAPI.Models.Maitrise.Type;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Interface
{
    public interface IMaitriseTypeServiceInterface
    {
        MaitriseTypeDTO Create(MaitriseTypeDTO maitriseTypeDto);

        IEnumerable<MaitriseTypeDTO> ReadAll();

        MaitriseTypeDTO ReadByName(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO ReadById(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO Update(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO Delete(MaitriseTypeDTO maitriseTypeDto);
    }
}