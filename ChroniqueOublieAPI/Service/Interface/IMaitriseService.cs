using ChroniqueOublieAPI.Models.Maitrise;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Service.Interface
{
    public interface IMaitriseServiceInterface
    {
        MaitriseDTO Create(MaitriseDTO maitriseTypeDto);

        IEnumerable<MaitriseDTO> ReadAll();

        MaitriseDTO ReadByName(MaitriseDTO maitriseTypeDto);

        MaitriseDTO ReadById(MaitriseDTO maitriseTypeDto);

        MaitriseDTO Update(MaitriseDTO maitriseTypeDto);

        MaitriseDTO Delete(MaitriseDTO maitriseTypeDto);
    }
}