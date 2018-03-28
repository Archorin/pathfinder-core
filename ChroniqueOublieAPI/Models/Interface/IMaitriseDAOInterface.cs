using ChroniqueOublieAPI.Models.Maitrise;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Models.Interface
{
    public interface IMaitriseDAOInterface
    {
        MaitriseDTO Create(MaitriseDTO maitriseTypeDto);

        IEnumerable<MaitriseDTO> ReadAll();

        MaitriseDTO ReadByName(MaitriseDTO maitriseTypeDto);

        MaitriseDTO ReadById(MaitriseDTO maitriseTypeDto);

        MaitriseDTO Update(MaitriseDTO maitriseTypeDto);

        MaitriseDTO Delete(MaitriseDTO maitriseTypeDto);
    }
}