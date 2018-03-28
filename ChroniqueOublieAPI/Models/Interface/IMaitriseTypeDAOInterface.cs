using ChroniqueOublieAPI.Models.Maitrise.Type;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Interface
{
    public interface IMaitriseTypeDAOInterface
    {
        MaitriseTypeDTO Create(MaitriseTypeDTO maitriseTypeDto);

        IEnumerable<MaitriseTypeDTO> ReadAll();

        MaitriseTypeDTO ReadByName(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO ReadById(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO Update(MaitriseTypeDTO maitriseTypeDto);

        MaitriseTypeDTO Delete(MaitriseTypeDTO maitriseTypeDto);
    }
}